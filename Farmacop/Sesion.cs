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

    public static class Sesion
    {
        #region Fields
        public static string HOST = "jfrodriguez.pw";
        public static string DB = "Farmacop_DB";
        public static string USER = "clientuser";
        public static string PASS = "hx3CfFQFdrRJVRsd";
        public static List<Medicament> MedList;
        public static List<User> UserList;
        public static List<Message> SendedMessages;
        public static List<Message> ReceivedMessages;
        public static List<Recepie> Recepies;
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
        #endregion

        #region Static Methods
        static public bool Connect()
        {
            return DBConnection.Connect(HOST, DB, USER, PASS);
        }

        static public void Disconnect()
        {
            DBConnection.Disconnect();
        }

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

        static public void SendEmail(string subject, string body, string mailto)
        {

            MailMessage email = new MailMessage();
            email.To.Add(new MailAddress(mailto));
            email.From = new MailAddress("farmacop_norep@hotmail.com");
            email.Subject = subject;
            email.Body = body;
            email.IsBodyHtml = false;
            email.Priority = MailPriority.Normal;

            SmtpClient smtp = new SmtpClient("smtp.live.com");
            smtp.Port = 25;
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential("farmacop_norep@hotmail.com", "juanfran15");

            smtp.Send(email);
            email.Dispose();
        }
        #endregion


    }
}
