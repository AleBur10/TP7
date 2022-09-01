using System;

namespace TP7_Bursztyn_Witlis_Akselrad.Models
{
    public class Jugador
    {
        private int _idJugador;
        private string _nombre;
        private DateTime _fechaHora;
        private int _pozoGanado;
        private bool _comodinDobleChance;
        private bool _comodin50;
        private bool _comodinSaltear;

        public Jugador(int IdJugador, string Nombre, DateTime FechaHora, int PozoGanado, bool ComodinDobleChance, bool Comodin50, bool ComodinSaltear)
        {
            _idJugador = IdJugador;
            _nombre = Nombre;
            _fechaHora = FechaHora;
            _pozoGanado = PozoGanado;
            _comodinDobleChance = ComodinDobleChance;
            _comodin50 = Comodin50;
            _comodinSaltear = ComodinSaltear;
        }
        public Jugador() { }
        public int IdJugador
        {
            get { return _idJugador; }
            set { _idJugador = value; }
        }

        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        public DateTime FechaHora
        {
            get { return _fechaHora; }
            set { _fechaHora = value; }
        }
        public int PozoGanado
        {
            get { return _pozoGanado; }
            set { _pozoGanado = value; }
        }

        public bool ComodinDobleChance
        {
            get { return _comodinDobleChance; }
            set { _comodinDobleChance = value; }
        }
        public bool Comodin50
        {
            get { return _comodin50; }
            set { _comodin50 = value; }
        }

        public bool ComodinSaltear
        {
            get { return _comodinSaltear; }
            set { _comodinSaltear = value; }
        }

    }
}