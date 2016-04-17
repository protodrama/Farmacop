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
    public partial class AddNewMed : Form
    {
        public AddNewMed()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string Name = "";
            string Type = cbbxType.Text;
            string NoCapName = txtNewMedNm.Text;
            try
            {
                if (!Type.Equals("") && !txtNewMedNm.Text.Trim().Equals(""))
                {

                    string FChar = NoCapName.Substring(0, 1);
                    string NameNoFChar = NoCapName.Substring(1, NoCapName.Length - 1);
                    Name = FChar.ToUpper() + NameNoFChar;
                    if (Sesion.DBConnection.InsertMedicament(Name, Type))
                    {
                        this.Close();
                    }
                    cbbxType.Text = "";
                    txtNewMedNm.Text = "";

                }
                else
                    MessageBox.Show("Debes introducir los datos del medicamento");
            }
            catch(Exception ex)
            {
                Sesion.GettingData = false;
                MessageBox.Show("Error al insertar el medicamento. Puede que ya exista.");
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
