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
        private string tomada;

        public Taken(string fecha, string hora, bool tomada)
        {
            Fecha = fecha;
            Hora = hora;
            if (tomada)
                Tomada = "SI";
            else
                Tomada = "NO";
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

        public string Tomada
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
