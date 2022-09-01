using System;

namespace TP7_Bursztyn_Witlis_Akselrad.Models
{
    public class Pregunta
    {
        private int _idPregunta;
        private string _textoPregunta;
        private int _nivelDificultad;

        public Pregunta(int IdPregunta, string TextoPregunta, int NivelDificultad)
        {
            _idPregunta = IdPregunta;
            _textoPregunta = TextoPregunta;
            _nivelDificultad = NivelDificultad;
        }
        public Pregunta() { }
        public int IdPregunta
        {
            get { return _idPregunta; }
            set { _idPregunta = value; }
        }

        public string TextoPregunta
        {
            get { return _textoPregunta; }
            set { _textoPregunta = value; }
        }

        public int NivelDificultad
        {
            get { return _nivelDificultad; }
            set { _nivelDificultad = value; }
        }

    }
}