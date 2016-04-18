﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Farmacop
{
    public partial class ModRecepieForm : Form
    {
        Recepie RecToMod = null;
        DataGridViewButtonColumn BtnDeleteColumn;
        List<RecepieTimeSelect> SelecTimeControl = new List<RecepieTimeSelect>();
        List<string> timeShowing = new List<string>();
        List<string> newTime = new List<string>();
        List<string> deletedTime = new List<string>();
        MonthCalendar mCalendar;
        bool FInic = true;

        public ModRecepieForm(Recepie recepie)
        {
            InitializeComponent();
            this.RecToMod = recepie;
            txtPatName.Text = RecToMod.Paciente;
            txtDs.Text = "" + RecToMod.Dosis;
            txtFInic.Text = RecToMod.FechaInicio;
            txtFEnd.Text = RecToMod.FechaFin;
            GetMedNames();
            timeShowing = RecToMod.GetTimes();
            SetTableData();
            SetTableColumn();
        }

        public void GetMedNames()
        {
            cbbxMed.Items.Clear();
            List<Medicament> medList = Sesion.DBConnection.GetAllMedicaments();
            List<string> algList = Sesion.DBConnection.GetUserAlg(RecToMod.Paciente);
            List<string> medNames = new List<string>();

            foreach (Medicament temp in medList)
                if (!algList.Contains(temp.Nombre))
                    medNames.Add(temp.Nombre);

            cbbxMed.Items.AddRange(medNames.ToArray());
            cbbxMed.SelectedItem = RecToMod.Medicamento;
        }

        public void SetTableData()
        {
            List<Hour> TimeData = new List<Hour>();
            foreach(string temp in timeShowing)
            {
                TimeData.Add(new Hour(temp));
            }
            TimeDataGrid.DataSource = TimeData;
        }

        public void SetTableColumn()
        {
            BtnDeleteColumn = new DataGridViewButtonColumn()
            {
                Name = "Delete",
                HeaderText = "Eliminar",
                Text = "Eliminar",
                UseColumnTextForButtonValue = true
            };
            TimeDataGrid.Columns.Add(BtnDeleteColumn);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            
        }

        private void btnAddMed_Click(object sender, EventArgs e)
        {
            new AddNewMed().ShowDialog();
            GetMedNames();
        }

        public class Hour
        {
            private string _hora;

            public string Hora
            {
                get
                {
                    return _hora;
                }

                set
                {
                    _hora = value;
                }
            }

            public Hour(string time)
            {
                this.Hora = time;
            }
        }

        public void AddTimeSelect()
        {
            RecepieTimeSelect SelectTemp = new RecepieTimeSelect();
            SelecTimeControl.Add(SelectTemp);
            TimeContainer.Controls.Add(SelectTemp);
        }

        private void btnAddAlg_Click(object sender, EventArgs e)
        {
            AddTimeSelect();
        }

        private void TimeDataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (TimeDataGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                if (DialogResult.Yes == MessageBox.Show("¿Desea eliminar la hora seleccionada?", "Eliminando", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    string temp = timeShowing[e.RowIndex];
                    deletedTime.Add(temp);
                    timeShowing.Remove(temp);
                    SetTableData();
                }
            }
        }

        private void txtDs_KeyPress(object sender, KeyPressEventArgs e)
        {
            string allowed = "0123456789\b";
            if (!allowed.Contains(e.KeyChar))
                e.Handled = true;
        }

        private void txtFInic_Enter(object sender, EventArgs e)
        {
            FInic = true;
            mCalendar = new MonthCalendar()
            {
                Left = 160,
                Top = 150
            };
            mCalendar.MouseLeave += MCalendar_MouseLeave;
            mCalendar.DateSelected += MCalendar_DateSelected;
            this.Controls.Add(mCalendar);
            mCalendar.BringToFront();
            mCalendar.Focus();
            txtFInic.Enabled = false;
        }

        private void txtFEnd_Enter(object sender, EventArgs e)
        {
            FInic = false;
            mCalendar = new MonthCalendar()
            {
                Left = 160,
                Top = 150
            };
            mCalendar.MouseLeave += MCalendar_MouseLeave;
            mCalendar.DateSelected += MCalendar_DateSelected;
            this.Controls.Add(mCalendar);
            mCalendar.BringToFront();
            mCalendar.Focus();
            txtFEnd.Enabled = false;
        }

        private void MCalendar_Leave(object sender, EventArgs e)
        {
            this.Controls.Remove(mCalendar);
            txtFInic.Enabled = true;
            txtFEnd.Enabled = true;
        }

        private void MCalendar_DateSelected(object sender, DateRangeEventArgs e)
        {
            txtFInic.Enabled = true;
            txtFEnd.Enabled = true;
            if (FInic)
                txtFInic.Text = mCalendar.SelectionRange.Start.ToString("dd/MM/yyyy");
            else
                txtFEnd.Text = mCalendar.SelectionRange.Start.ToString("dd/MM/yyyy");
            try
            {
                if (FInic)
                {
                    DateTime Date = DateTime.Parse(txtFInic.Text);
                    if (Date.Date < DateTime.Now.Date)
                        throw new Exception("Fecha fuera de rango (Fecha actual como mínimo).");
                    else
                        txtFEnd.Text = "";
                }
                else
                {
                    DateTime Date = DateTime.Parse(txtFEnd.Text);
                    if (Date.Date < DateTime.Parse(txtFInic.Text).Date)
                        throw new Exception("La fecha de fin debe ser igual o superior a la fecha de inicio.");
                }

            }
            catch (Exception ex)
            {
                if (FInic)
                {
                    MessageBox.Show(ex.Message, "Error");
                    txtFInic.Text = DateTime.Now.ToShortDateString();
                }
                else
                {
                    MessageBox.Show(ex.Message, "Error");
                    txtFEnd.Text = "";
                }
            }
            this.Controls.Remove(mCalendar);
        }

        private void MCalendar_MouseLeave(object sender, EventArgs e)
        {
            this.Controls.Remove(mCalendar);
            txtFInic.Enabled = true;
            txtFEnd.Enabled = true;
        }
    }
}