using System.Net.NetworkInformation;
using System;
using Dapper;
using System.Linq;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace TP7_Bursztyn_Witlis_Akselrad.Models
{
    public static class juegoQQSM
    {
        private static string _connectionString = "Server=A-PHZ2-CIDI-022;DataBase=JuegoQQSM;Trusted_Connection=true;";
        public static int _preguntaActual;
        private static char _respuestaCorrectaActual;
        private static int _posicionPozo;
        private static int _pozoAcumuladoSeguro;
        private static int _pozoAcumulado;
        private static bool _comodin5050;
        private static bool _comodinDobleChance;
        private static bool _comodinSaltearPregunta;
        private static List<pozo> _ListaPozo;
        private static Jugador _player;
        public static void IniciarJuego(string nombre)
        {
            _ListaPozo = new List<pozo>();
            _preguntaActual = 0;
            _respuestaCorrectaActual = ' ';
            _posicionPozo = 0;
            _pozoAcumuladoSeguro = 5000;
            _pozoAcumulado = 0;
            _comodin5050 = true;
            _comodinDobleChance = true;
            _comodinSaltearPregunta = true;
            _ListaPozo.Add(new pozo(0, false));
            _ListaPozo.Add(new pozo(1000, false));
            _ListaPozo.Add(new pozo(2000, false));
            _ListaPozo.Add(new pozo(5000, false));
            _ListaPozo.Add(new pozo(10000, false));
            _ListaPozo.Add(new pozo(20000, true));
            _ListaPozo.Add(new pozo(30000, false));
            _ListaPozo.Add(new pozo(50000, false));
            _ListaPozo.Add(new pozo(100000, false));
            _ListaPozo.Add(new pozo(130000, false));
            _ListaPozo.Add(new pozo(150000, true));
            _ListaPozo.Add(new pozo(180000, false));
            _ListaPozo.Add(new pozo(210000, false));
            _ListaPozo.Add(new pozo(250000, false));
            _ListaPozo.Add(new pozo(350000, false));
            _ListaPozo.Add(new pozo(400000, true));
            _ListaPozo.Add(new pozo(500000, false));
            _ListaPozo.Add(new pozo(750000, false));
            _ListaPozo.Add(new pozo(1000000, false));
            _ListaPozo.Add(new pozo(2000000, false));
            _ListaPozo.Add(new pozo(5000000, true));
            string sql = "INSERT INTO Jugadores(Nombre,FechaHora,ComodinDobleChance,Comodin50,ComodinSaltear,PozoGanado) VALUES(@pNombre, @pFechaHora,1,1,1,0)";
            using (SqlConnection bd = new SqlConnection(_connectionString))
            {
                bd.Execute(sql, new { pNombre = nombre, pFechaHora = DateTime.Now });
                _player = bd.QueryFirstOrDefault<Jugador>("SELECT TOP 1 * FROM Jugadores ORDER BY IdJugador DESC");
            }

        }
        public static Pregunta ObtenerProximaPregunta()
        {
            _preguntaActual++;
            Pregunta preguntaActual = null;
            using (SqlConnection bd = new SqlConnection(_connectionString))
            {
                string sql = "SELECT * FROM PREGUNTAS WHERE idPregunta= @pPregunta";
                preguntaActual = bd.QueryFirstOrDefault<Pregunta>(sql, new { pPregunta = _preguntaActual });
            }
            return preguntaActual;
        }

        public static List<Respuesta> ObtenerRespuestas()
        {
            List<Respuesta> listaRespuestas = new List<Respuesta>();
            using (SqlConnection bd = new SqlConnection(_connectionString))
            {
                string sql = "SELECT * FROM RESPUESTAS WHERE idPregunta= @pIdPregunta";
                listaRespuestas = bd.Query<Respuesta>(sql, new { pIdPregunta = _preguntaActual }).ToList();
            }
            foreach (Respuesta item in listaRespuestas)
            {
                if (item.Correcta == true)
                {
                    _respuestaCorrectaActual = item.OpcionRespuesta;
                }
            }
            return listaRespuestas;
        }
        public static bool respuestaUsuario(char opcion, char opcionComodin = 'g')
        {
            bool acierto = false;
            // Valida si se uso el comodin. Si no lo uso todavia, lo cambia en la db. Si ya lo habia usado, no se toman las rtas como corercta 
            if (_comodinDobleChance == true && opcionComodin != 'g') // Si todavia no uso el comodin.
            {
                _comodinDobleChance = false;
                var id = _player.IdJugador;
                using (SqlConnection bd = new SqlConnection(_connectionString))
                {
                    string sql = "UPDATE Jugadores SET ComodinDobleChance=0 WHERE idJugador = @pidJugador";
                    bd.Execute(sql, new { pidJugador = id });
                }
            }
            if (opcion == _respuestaCorrectaActual || opcionComodin == _respuestaCorrectaActual) //si las opciones que manda el usuario son correctas
            {
                if (_ListaPozo[_posicionPozo].ValorSeguro == true)
                {
                    _pozoAcumuladoSeguro += _ListaPozo[_posicionPozo].Importe;
                }
                _posicionPozo++;
                acierto = true;
            }
            return acierto;
        }
        //incrementar posicion pozo. Si tiene pozo seguro recibe la guita del pozo seguro actual

        public static List<pozo> ListarPozo()
        {
            return _ListaPozo;
        }
        public static int DevolverImportePozoActual()
        {
            return _ListaPozo[_posicionPozo].Importe;
        }
        /* public static char[] Descartar50()
         {
             if (Comodin50 == true)
             {
                 using (SqlConnection bd = new SqlConnection(_connectionString))
                 {
                     string sql = "UPDATE jugador SET comodin50 = false WHERE idJugador = @_idJugador";   

                 }




             }
         }
         public static void saltearPregunta(Pregunta idPregunta)
         {
             if (_comodinSaltearPregunta==true)
             {

                 using (SqlConnection bd = new SqlConnection(_connectionString))
                 {
                     string sql = "UPDATE jugador SET ComodinSaltear = false WHERE idJugador = @_idJugador";

                 }
             }
         }
         public static jugador devloverJugador()
         {
             return _player;
         }*/
    }
}