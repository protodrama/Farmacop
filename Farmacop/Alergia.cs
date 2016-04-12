using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Farmacop
{
    public class Alergia
    {
        private string _medicamento;

        public string Medicamento
        {
            get
            {
                return _medicamento;
            }

            set
            {
                _medicamento = value;
            }
        }

        public Alergia(string medicament)
        {
            Medicamento = medicament;
        }

    }
}
