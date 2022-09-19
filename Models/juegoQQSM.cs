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
            _pozoAcumuladoSeguro = 0;
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

        public static int GetIDPreguntaActual()
        {
            return _preguntaActual;
        }
        public static Pregunta VolverUnaPreguntaAtras()
        {
            _preguntaActual--;
            Pregunta preguntaActual = null;
            using (SqlConnection bd = new SqlConnection(_connectionString))
            {
                string sql = "SELECT * FROM PREGUNTAS WHERE idPregunta= @pPregunta";
                preguntaActual = bd.QueryFirstOrDefault<Pregunta>(sql, new { pPregunta = _preguntaActual });
            }
            return preguntaActual;
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
        public static int DevolverImportePozoActual(bool acerto)
        {
            if (acerto == true)
            {
                if (_ListaPozo[_posicionPozo].ValorSeguro == true)
                {
                    _pozoAcumuladoSeguro = _ListaPozo[_posicionPozo].Importe;
                }
                return _ListaPozo[_posicionPozo].Importe;
            }
            else
            {
                return _pozoAcumuladoSeguro;
            }
        }
        public static int DevolverImportePozoActualRetirado()
        {
            return _ListaPozo[_posicionPozo].Importe;
        }
        public static bool ChequearSiUso5050()
        {
            bool usado = false;
            using (SqlConnection bd = new SqlConnection(_connectionString))
            {
                string sql = "SELECT Comodin50 FROM Jugadores WHERE idJugador = @pidJugador ";
                usado = bd.QueryFirstOrDefault<bool>(sql, new { pidJugador = _player.IdJugador });
            }
            return usado;
        }
        public static bool ChequearSiUsoDobleChance()
        {
            bool usado = false;
            using (SqlConnection bd = new SqlConnection(_connectionString))
            {
                string sql = "SELECT ComodinDobleChance FROM Jugadores WHERE idJugador = @pidJugador ";
                usado = bd.QueryFirstOrDefault<bool>(sql, new { pidJugador = _player.IdJugador });
            }
            return usado;
        }
        public static bool ChequearSiUsoSaltear()
        {
            bool usado = false;
            using (SqlConnection bd = new SqlConnection(_connectionString))
            {
                string sql = "SELECT ComodinSaltear FROM Jugadores WHERE idJugador = @pidJugador ";
                usado = bd.QueryFirstOrDefault<bool>(sql, new { pidJugador = _player.IdJugador });
            }
            return usado;
        }
        public static List<Respuesta> Usar5050()
        {
            // validar si fue usado
            // cambiarlo en la db
            // usarlo
            var usado = ChequearSiUso5050();


            var id = _player.IdJugador;
            using (SqlConnection bd = new SqlConnection(_connectionString))
            {
                string sql = "UPDATE Jugadores SET Comodin50=0 WHERE idJugador = @pidJugador";
                bd.Execute(sql, new { pidJugador = id });
            }
            var rtas = ObtenerRespuestas();

            if (usado)
            {
                return rtas;
            }
            else
            {
            List<Respuesta> nuevas = new List<Respuesta>();
            var i = 0;
            var primeraVez = true;
            #region crea nuevas respuestas
            foreach (var rta in rtas)
            {
                if (primeraVez == false && rta.Correcta == false)
                {
                    nuevas.Add(rta);
                    if (nuevas.Count == 2)
                    {
                        break;
                    }
                }
                if (rta.Correcta == true)
                {
                    nuevas.Add(rta);
                    primeraVez = false;
                    i = rta.IdRespuesta;
                }
                else
                {
                    i = rta.IdRespuesta;
                    primeraVez = false;
                }
            }
            while (nuevas.Count > 2)
            {
                foreach (var rta in nuevas)
                {
                    if (rta.Correcta == true)
                    {
                        nuevas.RemoveAt(nuevas.Count - 2);
                        break;
                    }
                    else
                    {
                        nuevas.RemoveAt(nuevas.Count - 1);
                        break;
                    }
                }
            }
            return nuevas;
            #endregion
            }
        }
    }
}
