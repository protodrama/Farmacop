using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Farmacop
{
    //Representa un mensaje en la aplicación
    public class Message
    {
        private string _writer;
        private string _reader;
        private string _matter;
        private string _text;
        private bool _readed;
        private int _id;

        public string Emisor
        {
            get
            {
                return _writer;
            }

            set
            {
                _writer = value;
            }
        }

        public string Receptor
        {
            get
            {
                return _reader;
            }

            set
            {
                _reader = value;
            }
        }

        public string Asunto
        {
            get
            {
                return _matter;
            }

            set
            {
                _matter = value;
            }
        }

        public string Mensaje
        {
            get
            {
                return _text;
            }

            set
            {
                _text = value;
            }
        }

        public bool IsReaded()
        {
            return _readed;
        }

        public int Id()
        {
            return _id;
        }

        public Message(int id, string writer, string reader, string subject, string text, bool readed)
        {
            this._id = id;
            this.Emisor = writer;
            this.Receptor = reader;
            this.Asunto = subject;
            this.Mensaje = text;
            this._readed = readed;
        }
    }
}
