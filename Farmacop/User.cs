using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Farmacop
{
    public class User
    {
        private string _nombre;
        private string _fapellido;
        private string _sapellido;
        private string _account;
        private string _fechaN;
        private string _tipo;
        private bool _habilitado;
        private List<string> _alergias;

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

        public string Apellidos
        {
            get
            {
                return _fapellido + " " + _sapellido;
            }
        }

        public string Cuenta
        {
            get
            {
                return _account;
            }

            set
            {
                _account = value;
            }
        }

        public string Nacimiento
        {
            get
            {
                return _fechaN;
            }

            set
            {
                _fechaN = value;
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

        private bool Habilitado
        {
            get
            {
                return _habilitado;
            }

            set
            {
                _habilitado = value;
            }
        }

        public List<string> Alergias
        {
            get
            {
                return _alergias;
            }

            set
            {
                _alergias = value;
            }
        }

        public User() { }

        public User(string name, string surname,string ssurname, string email, string birthDate, string type, bool enabled)
        {
            this.Nombre = name;
            this._fapellido = surname;
            this._sapellido = ssurname;
            this.Cuenta = email;
            this.Nacimiento = birthDate;
            this.Tipo = type;
            this.Habilitado = enabled;
        }

        public bool IsEnabled()
        {
            return Habilitado;
        }

        public string GetFApl()
        {
            return _fapellido;
        }

        public string GetSApl()
        {
            return _sapellido;
        }

        public List<Alergia> GetAlgList()
        {
            List<Alergia> AlgList = new List<Alergia>();
            foreach (string alg in Alergias)
                AlgList.Add(new Alergia(alg));
            return AlgList;
        }
    }
}
