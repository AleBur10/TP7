using System;

namespace TP7_Bursztyn_Witlis_Akselrad.Models
{
    public static class juegoQQSM
    {
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

        public static void IniciarJuego(string nombre, DateTime FechaHora)
        {
            _preguntaActual=1;
            _respuestaCorrectaActual= ' ';
            _posicionPozo=1;
            _pozoAcumuladoSeguro=5000;
            _pozoAcumulado=0;
            _comodin5050=true;
            _comodinDobleChance=true;
            _comodinSaltearPregunta=true;
            
             string sql="INSERT INTO Jugadores(idJugador, Nombre, FechaHora) VALUES(@idJugador, @Nombre, @FechaHora)";
        }

    }
}