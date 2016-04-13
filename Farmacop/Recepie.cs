using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Farmacop
{
    public class Recepie
    {
        private int _id;
        private string _paciente;
        private string _medico;
        private string _fechaInicio;
        private string _fechaFin;
        private string _medicamento;
        private int _dosis;
        private List<Taken> _tomas;

        public Recepie(int id, string paciente, string medico, string fechaInicio, string fechaFin, string medicamento, int dosis)
        {
            Id = id;
            Paciente = paciente;
            Medico = medico;
            FechaInicio = fechaInicio;
            FechaFin = fechaFin;
            Medicamento = medicamento;
            Dosis = dosis;
        }

        private int Id
        {
            get
            {
                return _id;
            }

            set
            {
                _id = value;
            }
        }

        public string Paciente
        {
            get
            {
                return _paciente;
            }

            set
            {
                _paciente = value;
            }
        }

        public string Medico
        {
            get
            {
                return _medico;
            }

            set
            {
                _medico = value;
            }
        }

        public string FechaInicio
        {
            get
            {
                return _fechaInicio;
            }

            set
            {
                _fechaInicio = value;
            }
        }

        public string FechaFin
        {
            get
            {
                return _fechaFin;
            }

            set
            {
                _fechaFin = value;
            }
        }

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

        public int Dosis
        {
            get
            {
                return _dosis;
            }

            set
            {
                _dosis = value;
            }
        }

        private List<Taken> Tomas
        {
            get
            {
                return _tomas;
            }

            set
            {
                _tomas = value;
            }
        }

        public void SetRControl(List<Taken> taken)
        {
            this.Tomas = taken;
        }

        public List<Taken> GetControl()
        {
            return Tomas;
        }

        public int getId()
        {
            return Id;
        }
    }
}
