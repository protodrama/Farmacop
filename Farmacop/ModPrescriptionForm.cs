using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Farmacop
{
    public partial class ModPrescriptionForm : Form
    {
        Prescription RecToMod = null;
        DataGridViewButtonColumn BtnDeleteColumn;
        List<PrescTimeSelect> SelecTimeControl = new List<PrescTimeSelect>();
        List<string> timeShowing = new List<string>();
        List<string> newTime = new List<string>();
        List<string> deletedTime = new List<string>();
        MonthCalendar mCalendar;
        bool FInic = true;

        public ModPrescriptionForm(Prescription prescription)
        {
            try
            {
                InitializeComponent();
                this.RecToMod = prescription;
                txtPatName.Text = RecToMod.Paciente;
                txtDs.Text = "" + RecToMod.Dosis;
                txtFInic.Text = RecToMod.FechaInicio;
                txtFEnd.Text = RecToMod.FechaFin;
                lblmedicament.Text = RecToMod.Medicamento;
                RecToMod.SetTimes(ReadControlData(Session.DBConnection.GetAllHours(RecToMod.getId())));
                timeShowing = RecToMod.GetTimes();
                SetTableData();
                SetTableColumn();
                txtDs.Focus();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error al cargar los datos de la receta");
                this.Close();
            }
        }

        public List<string> ReadControlData(string data)
        {
            try
            {
                List<string> thelist = new List<string>();
                JObject jobject = JObject.Parse(data);
                JToken jdata = jobject["data"];

                for (int i = 0; i < jdata.Count<JToken>(); i++)
                {
                    string rtemp = int.Parse(jdata[i]["Hora"].ToString()).ToString("00") + ":"
                        + int.Parse(jdata[i]["Minuto"].ToString()).ToString("00");
                    thelist.Add(rtemp);
                }

                return thelist;
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }

        public List<string> ReadAlg(string data)
        {
            List<string> thelist = new List<string>();
            JObject jobject = JObject.Parse(data);
            JToken jdata = jobject["data"];

            for (int i = 0; i < jdata.Count<JToken>(); i++)
            {
                string temp = jdata[i]["Nombre"].ToString();
                thelist.Add(temp);
            }

            return thelist;
        }

        public List<Medicament> ReadData(string jsondata)
        {
            List<Medicament> thelist = new List<Medicament>();
            JObject jobject = JObject.Parse(jsondata);
            JToken jdata = jobject["data"];

            for (int i = 0; i < jdata.Count<JToken>(); i++)
            {
                Medicament temp = new Medicament(jdata[i]["Nombre"].ToString(), jdata[i]["Tipo"].ToString());
                thelist.Add(temp);
            }

            return thelist;
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

        private void btnMod_Click(object sender, EventArgs e)
        {
            if (CheckData())
            {
                int ds = int.Parse(txtDs.Text);
                if (ds > 0)
                {
                    foreach (PrescTimeSelect tmp in SelecTimeControl)
                    {
                        if (!newTime.Contains(tmp.Time))
                            newTime.Add(tmp.Time);
                    }
                    List<string> allRecepieTime = new List<string>();
                    allRecepieTime.AddRange(newTime.ToArray());
                    allRecepieTime.AddRange(timeShowing.ToArray());

                    if (allRecepieTime.Count > 0)
                    {
                        try
                        {
                            this.Cursor = Cursors.AppStarting;
                            if (Session.DBConnection.ModRecepie(RecToMod.getId(), RecToMod.Paciente, RecToMod.Medicamento, DateTime.Parse(txtFInic.Text).ToString("yyyy-MM-dd"),
                                DateTime.Parse(txtFEnd.Text).ToString("yyyy-MM-dd"), txtDs.Text, newTime, deletedTime, allRecepieTime))
                            {
                                MessageBox.Show("Receta modificada correctamente");
                                this.Cursor = Cursors.Default;
                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show("Error al modificar la receta");
                                this.Cursor = Cursors.Default;
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                            this.Cursor = Cursors.Default;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Una receta debe tener al menos una hora de toma");
                        this.Close();
                    }
                }
                else
                    MessageBox.Show("La dosis no puede ser 0");

            }
            else
            {
                MessageBox.Show("Debes introducir datos para todos los campos");
            }
        }

        public void AddTimeSelect()
        {
            PrescTimeSelect SelectTemp = new PrescTimeSelect();
            SelecTimeControl.Add(SelectTemp);
            TimeContainer.Controls.Add(SelectTemp);
        }

        private void btnAddTime_Click(object sender, EventArgs e)
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

        public bool CheckData()
        {
            if (!txtDs.Text.Trim().Equals("") && !txtFInic.Text.Trim().Equals("") && !txtFEnd.Text.Trim().Equals(""))
                return true;
            else
                return false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (SelecTimeControl.Count > 0) {
                PrescTimeSelect SelectTemp = SelecTimeControl[SelecTimeControl.Count - 1];
                SelecTimeControl.Remove(SelectTemp);
                TimeContainer.Controls.Remove(SelectTemp);
            }
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
                    txtFInic.Text = RecToMod.FechaInicio;
                }
                else
                {
                    MessageBox.Show(ex.Message, "Error");
                    txtFEnd.Text = RecToMod.FechaFin;
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
    }
}
