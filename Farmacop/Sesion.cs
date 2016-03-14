using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Farmacop
{
    public enum UserType {Administrador,Medico,Paciente}; //Tipos de usuarios

    public static class Sesion
    {
        static string email;
        public static string Email { get { return email; } set { email = value; } }

        static string name;
        public static string Name { get { return name; } set { name = value; } }

        static string firstSurname;
        public static string FirstSurname { get { return firstSurname; } set { firstSurname = value; } }

        static string secondSurname;
        public static string SecondSurname { get { return secondSurname; } set { secondSurname = value; } }

        static string passWord;
        public static string PassWord { get { return passWord; } set { passWord = value; } }

        static UserType type;
        public static UserType UserType { get { return type; } set { type = value; } }



    }
}
