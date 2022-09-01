using System;
using Dapper;
using System.Linq;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace TP7_Bursztyn_Witlis_Akselrad.Models
{
    public static class juegoQQSM
    {
        private static string _connectionString = "Server=A-CIDI-122;DataBase=JuegoQQSM;Trusted_Connection=true;";
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
            _preguntaActual = 1;
            _respuestaCorrectaActual = ' ';
            _posicionPozo = 1;
            _pozoAcumuladoSeguro = 5000;
            _pozoAcumulado = 0;
            _comodin5050 = true;
            _comodinDobleChance = true;
            _comodinSaltearPregunta = true;
            string sql = "INSERT INTO Jugadores(Nombre,FechaHora,idJugador) VALUES(@idJugador, @Nombre, @FechaHora)";
            using (SqlConnection bd = new SqlConnection(_connectionString))
            {
                bd.Execute(sql, new { pNombre = nombre, pFechaHora = DateTime.Now });
            }
            _player.Nombre = nombre;
            _player.FechaHora = DateTime.Now;

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

        public static List<> ObtenerRespuestas()
        {

        }

    }
}