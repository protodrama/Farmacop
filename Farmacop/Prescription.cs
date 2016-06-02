using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Farmacop
{
    public class Prescription
    {
        private int _id;
        private string _paciente;
        private string _medico;
        private string _fechaInicio;
        private string _fechaFin;
        private string _medicamento;
        private int _dosis;
        private List<RecControl> _tomas;
        private List<string> _horas;

        public Prescription(int id, string patient, string medic, string startdate, string enddate, string medicament, int ammount)
        {
            Id = id;
            Paciente = patient;
            Medico = medic;
            FechaInicio = startdate;
            FechaFin = enddate;
            Medicamento = medicament;
            Dosis = ammount;
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

        private List<RecControl> Tomas
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

        private List<string> Horas
        {
            get
            {
                return _horas;
            }

            set
            {
                _horas = value;
            }
        }

        public void SetRControl(List<RecControl> taken)
        {
            this.Tomas = taken;
        }

        public List<RecControl> GetControl()
        {
            return Tomas;
        }

        public int getId()
        {
            return Id;
        }

        public void SetTimes(List<string> horas)
        {
            this.Horas = horas;
        }

        public List<string> GetTimes()
        {
            return Horas;
        }
    }
}
