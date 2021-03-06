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
    //Formulario para agregar un nuevo medicamento
    public partial class AddNewMed : Form
    {
        public AddNewMed()
        {
            InitializeComponent();
        }

        //Agrega el medicamento si no existe y si se han indicado todos los datos
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
                    if (Session.DBConnection.InsertMedicament(Name, Type))
                    {
                        this.Close();
                    }
                    cbbxType.Text = "";
                    txtNewMedNm.Text = "";
                    MessageBox.Show("El medicamento ya existe.");
                }
                else
                    MessageBox.Show("Debes introducir los datos del medicamento");
            }
            catch(Exception ex)
            {
                Session.GettingData = false;
                MessageBox.Show("Error al insertar el medicamento. Puede que ya exista.");
                this.Close();
            }
        }

        //Cierra el formulario
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
