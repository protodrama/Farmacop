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
    public partial class AddRecepie : Form
    {
        List<string> Users;
        List<RecepieTimeSelect> ListTime = new List<RecepieTimeSelect>();
        MonthCalendar mCalendar;
        bool FInic = true;

        public AddRecepie()
        {
            InitializeComponent();
            GetData();
            GetMedNames();
        }

        public void GetData()
        {
            List<string> names = Sesion.DBConnection.GetAllUsersNameAccount();
            Users = names;
            var source = new AutoCompleteStringCollection();
            source.AddRange(names.ToArray());
            txtTargetUser.AutoCompleteCustomSource = source;
            txtTargetUser.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtTargetUser.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtFInic.Text = DateTime.Now.ToShortDateString();
            RecepieTimeSelect select = new RecepieTimeSelect();
            ListTime.Add(select);
            TimeContainer.Controls.Add(select);
        }

        public void GetMedNames()
        {
            cbbxMed.Items.Clear();
            List<Medicament> medlist = Sesion.DBConnection.GetAllMedicaments();
            foreach (Medicament temp in medlist)
                cbbxMed.Items.Add(temp.Nombre);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!txtDs.Text.Trim().Equals("") && !txtFInic.Text.Trim().Equals("") && !txtFEnd.Text.Trim().Equals("") && !cbbxMed.Text.Trim().Equals(""))
            {
                List<string> time = new List<string>();
                foreach (RecepieTimeSelect temp in ListTime)
                {
                    if (!time.Contains(temp.Time))
                        time.Add(temp.Time);
                }
                string hours = string.Empty;
                foreach (string tmp in time)
                    hours += "\n" + tmp;
                string msg = @"¿Desea crear una receta para el usuario " + txtTargetUser.Text + "?\nMedicamento: " + cbbxMed.Text +
                    "\nDosis: " + txtDs.Text + "\nFecha de inicio: " + txtFInic.Text + "\nFecha fin: " + txtFEnd.Text + "\nHorario de tomas:" + hours;
                if (DialogResult.Yes == MessageBox.Show(msg,"Creando receta",MessageBoxButtons.YesNo,MessageBoxIcon.Question))
                {
                    try
                    {
                        if (Sesion.DBConnection.AddRecepie(txtTargetUser.Text, Sesion.Account, cbbxMed.Text, txtFInic.Text, txtFEnd.Text, txtDs.Text, time))
                        {
                            MessageBox.Show("Receta añadida correctamente");
                            this.Close();
                        }
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                }
            }
            else
                MessageBox.Show("Debes indicar un valor para todos los campos");
        }

        private void txtTargetUser_TextChanged(object sender, EventArgs e)
        {
            if (Users.Contains(txtTargetUser.Text))
            {
                GetMedNames();
                btnAdd.Enabled = true;
                grpRecData.Visible = true;
                List<string> Alerg = Sesion.DBConnection.GetUserAlg(txtTargetUser.Text);
                foreach (string temp in Alerg)
                    cbbxMed.Items.Remove(temp);
            }
            else
            {
                btnAdd.Enabled = false;
                grpRecData.Visible = false;
                GetMedNames();
            }
        }

        private void btnAddMed_Click(object sender, EventArgs e)
        {
            new AddNewMed().ShowDialog();
            GetMedNames();
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
            if(FInic)
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

        private void btnAddAlg_Click(object sender, EventArgs e)
        {
            RecepieTimeSelect select = new RecepieTimeSelect();
            ListTime.Add(select);
            TimeContainer.Controls.Add(select);
        }
    }
}
