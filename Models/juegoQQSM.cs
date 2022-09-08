using System;
using Dapper;
using System.Linq;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace TP7_Bursztyn_Witlis_Akselrad.Models
{
    public static class juegoQQSM
    {
        private static string _connectionString = "Server=A-PHZ2-CIDI-038;DataBase=JuegoQQSM;Trusted_Connection=true;";
        private static int _preguntaActual;
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
            _preguntaActual = 1;
            _respuestaCorrectaActual = ' ';
            _posicionPozo = 1;
            _pozoAcumuladoSeguro = 5000;
            _pozoAcumulado = 0;
            _comodin5050 = true;
            _comodinDobleChance = true;
            _comodinSaltearPregunta = true;
            _ListaPozo.Add(new pozo(1000,false));
            _ListaPozo.Add(new pozo(2000,false));
            _ListaPozo.Add(new pozo(5000,false));
            _ListaPozo.Add(new pozo(10000,true));
            /*_ListaPozo.Add(20000);
            _ListaPozo.Add(30000);
            _ListaPozo.Add(50000);
            _ListaPozo.Add(100000);
            _ListaPozo.Add(130000);
            _ListaPozo.Add(150000);
            _ListaPozo.Add(180000);
            _ListaPozo.Add(210000);
            _ListaPozo.Add(250000);
            _ListaPozo.Add(350000);
            _ListaPozo.Add(400000);
            _ListaPozo.Add(500000);
            _ListaPozo.Add(750000);
            _ListaPozo.Add(1000000);
            _ListaPozo.Add(2000000);
            _ListaPozo.Add(5000000);*/
            string sql = "INSERT INTO Jugadores(Nombre,FechaHora,ComodinDobleChance,Comodin50,ComodinSaltear,PozoGanado) VALUES(@pNombre, @pFechaHora,1,1,1,0)";
            using (SqlConnection bd = new SqlConnection(_connectionString))
            {
                bd.Execute(sql, new { pNombre = nombre, pFechaHora = DateTime.Now });
                _player = bd.QueryFirstOrDefault<Jugador>("SELECT TOP 1 * FROM Jugadores ORDER BY IdJugador DESC");
            }

        }
        public static Pregunta ObtenerProximaPregunta()
        {
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
            return listaRespuestas;
        }
        /*
        public bool respuestaUsuario(char opcion, char opcionComodin = ' ')
        {
            bool acierto = false;
            if (opcion != null && opcionComodin != null)
            {
                using (sqlConnection bd = new sqlConnection(_connectionString))
                {
                    string sql = "UPDATE Jugador SET ComodinDobleChance = False WHERE idJugador = @_idJugador";
                    bd.Execute;
                }
            }
            if (opcion == _respuestaCorrectaActual)
            {
                if (_ListaPozo[_posicionPozo]._valorSeguro == true)
                {
                    _pozoAcumuladoSeguro == _posicionPozo;
                }
                _posicionPozo++;
                acierto = true;
            }
            return acierto;
        }
        
        public static List<Pozo> ListarPozo()
        {
            return _ListaPozo;
        }
        public static int DevolverPosicionPozo(int _posicionPozo)
        {
            return _posicionPozo;
        }
        public static char[] Descartar50()
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