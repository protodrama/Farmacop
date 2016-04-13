using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Farmacop
{
    public class Taken
    {
        private string _fecha;
        private string _hora;
        private bool tomada;

        public Taken(string fecha, string hora, bool tomada)
        {
            Fecha = fecha;
            Hora = hora;
            Tomada = tomada;
        }

        public string Fecha
        {
            get
            {
                return _fecha;
            }

            set
            {
                _fecha = value;
            }
        }

        public string Hora
        {
            get
            {
                return _hora;
            }

            set
            {
                _hora = value;
            }
        }

        public bool Tomada
        {
            get
            {
                return tomada;
            }

            set
            {
                tomada = value;
            }
        }
    }
}
