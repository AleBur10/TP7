using System;

namespace TP7_Bursztyn_Witlis_Akselrad.Models
{
    public class pozo
    {
        private int _importe;
        private bool _valorSeguro;

        public pozo(int importe, bool valorSeguro)
        {
            _importe = importe;
            _valorSeguro = valorSeguro;
        }
    }
}