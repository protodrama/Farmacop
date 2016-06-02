using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Farmacop
{
    public class RecControl
    {
        private string _fecha;
        private string _hora;
        private string tomada;

        public RecControl(string date, string time, bool done)
        {
            Fecha = date;
            Hora = time;
            if (done)
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
