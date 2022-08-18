using System;

namespace TP7_Bursztyn_Witlis_Akselrad.Models
{
    public class Respuesta
    {
        private int _idRespuesta;
        private int _idPregunta;
        private char _opcionRespuesta;
        private string _textoRespuesta;
        private bool _correcta;

        public Respuesta(int IdRespuesta, int IdPregunta, char OpcionRespuesta, string TextoRespuesta, bool Correcta)
        {
            _idRespuesta = IdRespuesta;
            _idPregunta = IdPregunta;
            _opcionRespuesta = OpcionRespuesta;
            _textoRespuesta = TextoRespuesta;
            _correcta = Correcta;
        }
        public Respuesta(){}
        public int IdRespuesta
        {
            get { return _idRespuesta; }
            set { _idRespuesta = value; }
        }

        public int IdPregunta
        {
            get { return _idPregunta; }
            set { _idPregunta = value; }
        }
        
        public char OpcionRespuesta
        {
            get { return _opcionRespuesta; }
            set { _opcionRespuesta = value; }
        }
        public string TextoRespuesta
        {
            get { return _textoRespuesta; }
            set { _textoRespuesta = value; }
        }
        
        public bool Correcta
        {
            get { return _correcta; }
            set { _correcta = value; }
        }
        
    }
}