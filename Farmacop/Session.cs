using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Net.Mail;
using System.Net;

namespace Farmacop
{
    public enum UserType {Admin,Medico,Paciente}; //Tipos de usuarios

    public static class Session
    {
        #region Fields
        public static List<Medicament> MedList;
        public static List<User> UserList;
        public static List<Message> SendedMessages;
        public static List<Message> ReceivedMessages;
        public static List<Prescription> Recepies;
        public static bool GettingData = false;

        public static DAO DBConnection;

        static string email;
        public static string Email { get { return email; } set { email = value; } }

        static string account;
        public static string Account { get { return account; } set { account = value; } }

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

        static string fNac;
        public static string FNac { get { return fNac; } set { fNac = value; } }

        public static string Apikey
        {
            get
            {
                return apikey;
            }

            set
            {
                apikey = value;
            }
        }
        static string apikey;

        #endregion

        #region Static Methods
        static public string StringToMD5(string value)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] TextoEnBytes = Encoding.UTF8.GetBytes(value);

            byte[] CriptoBytes = md5.ComputeHash(TextoEnBytes);
            StringBuilder Cripto = new StringBuilder();

            for (int i = 0; i < CriptoBytes.Length; i++)
            {
                Cripto.Append(CriptoBytes[i].ToString("x2"));
            }

            return Cripto.ToString();
        }             
        #endregion


    }
}
