using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Farmacop
{
    public class Message
    {
        private string _transmitter;
        private string _receiver;
        private string _matter;
        private string _text;
        private bool _readed;
        private int _id;

        public string Emisor
        {
            get
            {
                return _transmitter;
            }

            set
            {
                _transmitter = value;
            }
        }

        public string Receptor
        {
            get
            {
                return _receiver;
            }

            set
            {
                _receiver = value;
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

        public Message(int id, string transmitter, string receiver, string subject, string text, bool readed)
        {
            this._id = id;
            this.Emisor = transmitter;
            this.Receptor = receiver;
            this.Asunto = subject;
            this.Mensaje = text;
            this._readed = readed;
        }
    }
}
