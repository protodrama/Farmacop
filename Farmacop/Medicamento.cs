using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Farmacop
{
    public class Medicamento
    {
        private string _nombre;
        private string _tipo;

        public string Nombre
        {
            get
            {
                return _nombre;
            }

            set
            {
                _nombre = value;
            }
        }

        public string Tipo
        {
            get
            {
                return _tipo;
            }

            set
            {
                _tipo = value;
            }
        }

        public Medicamento(string nombre, string tipo)
        {
            this.Nombre = nombre;
            this.Tipo = tipo;
        }
    }
}
