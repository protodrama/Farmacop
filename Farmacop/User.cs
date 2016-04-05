using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Farmacop
{
    public class User
    {
        private string _nombre;
        private string _apellidos;
        private string _email;
        private string _fechaN;
        private string _tipo;
        private bool _deshabilitada;

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
                return _apellidos;
            }

            set
            {
                _apellidos = value;
            }
        }

        public string Email
        {
            get
            {
                return _email;
            }

            set
            {
                _email = value;
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

        private bool Deshabilitado
        {
            get
            {
                return _deshabilitada;
            }

            set
            {
                _deshabilitada = value;
            }
        }

        public User() { }

        public User(string name, string surname, string email, string birthDate, string type, bool enabled)
        {
            this.Nombre = name;
            this.Apellidos = surname;
            this.Email = email;
            this.Nacimiento = birthDate;
            this.Tipo = type;
            this.Deshabilitado = enabled;
        }

        public bool IsEnabled()
        {
            return Deshabilitado;
        }
    }
}
