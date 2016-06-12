using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Farmacop
{
    //Clase que representa medicamento en la aplicación
    public class Medicament
    {
        private string _name;
        private string _type;

        public string Nombre
        {
            get
            {
                return _name;
            }

            set
            {
                _name = value;
            }
        }

        public string Tipo
        {
            get
            {
                return _type;
            }

            set
            {
                _type = value;
            }
        }

        public Medicament(string name, string type)
        {
            this.Nombre = name;
            this.Tipo = type;
        }
    }
}
