namespace Farmacop
{
    partial class AddUserForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddUserForm));
            this.ComboboxType = new System.Windows.Forms.ComboBox();
            this.lblType = new System.Windows.Forms.Label();
            this.lblBDate = new System.Windows.Forms.Label();
            this.lblSSurname = new System.Windows.Forms.Label();
            this.txtFNac = new System.Windows.Forms.TextBox();
            this.txtSApl = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnAccept = new System.Windows.Forms.Button();
            this.lblFSurname = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.txtFApl = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // ComboboxType
            // 
            this.ComboboxType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.ComboboxType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboboxType.Items.AddRange(new object[] {
            "Admin",
            "Medico",
            "Paciente"});
            this.ComboboxType.Location = new System.Drawing.Point(150, 238);
            this.ComboboxType.Name = "ComboboxType";
            this.ComboboxType.Size = new System.Drawing.Size(121, 21);
            this.ComboboxType.TabIndex = 5;
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Location = new System.Drawing.Point(62, 241);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(82, 13);
            this.lblType.TabIndex = 42;
            this.lblType.Text = "Tipo de cuenta:";
            // 
            // lblBDate
            // 
            this.lblBDate.AutoSize = true;
            this.lblBDate.Location = new System.Drawing.Point(38, 196);
            this.lblBDate.Name = "lblBDate";
            this.lblBDate.Size = new System.Drawing.Size(109, 13);
            this.lblBDate.TabIndex = 41;
            this.lblBDate.Text = "Fecha de nacimiento:";
            // 
            // lblSSurname
            // 
            this.lblSSurname.AutoSize = true;
            this.lblSSurname.Location = new System.Drawing.Point(52, 151);
            this.lblSSurname.Name = "lblSSurname";
            this.lblSSurname.Size = new System.Drawing.Size(92, 13);
            this.lblSSurname.TabIndex = 40;
            this.lblSSurname.Text = "Segundo apellido:";
            // 
            // txtFNac
            // 
            this.txtFNac.Location = new System.Drawing.Point(150, 193);
            this.txtFNac.Name = "txtFNac";
            this.txtFNac.Size = new System.Drawing.Size(287, 20);
            this.txtFNac.TabIndex = 4;
            this.txtFNac.Click += new System.EventHandler(this.txtFNac_Click);
            this.txtFNac.Enter += new System.EventHandler(this.txtFNac_Enter);
            // 
            // txtSApl
            // 
            this.txtSApl.Location = new System.Drawing.Point(150, 148);
            this.txtSApl.Name = "txtSApl";
            this.txtSApl.Size = new System.Drawing.Size(287, 20);
            this.txtSApl.TabIndex = 3;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(251, 288);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(129, 23);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnAccept
            // 
            this.btnAccept.Location = new System.Drawing.Point(92, 288);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(129, 23);
            this.btnAccept.TabIndex = 6;
            this.btnAccept.Text = "Aceptar";
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // lblFSurname
            // 
            this.lblFSurname.AutoSize = true;
            this.lblFSurname.Location = new System.Drawing.Point(66, 106);
            this.lblFSurname.Name = "lblFSurname";
            this.lblFSurname.Size = new System.Drawing.Size(78, 13);
            this.lblFSurname.TabIndex = 39;
            this.lblFSurname.Text = "Primer apellido:";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(97, 61);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(47, 13);
            this.lblName.TabIndex = 38;
            this.lblName.Text = "Nombre:";
            // 
            // txtFApl
            // 
            this.txtFApl.Location = new System.Drawing.Point(150, 103);
            this.txtFApl.Name = "txtFApl";
            this.txtFApl.Size = new System.Drawing.Size(287, 20);
            this.txtFApl.TabIndex = 2;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(150, 58);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(287, 20);
            this.txtName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(103, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 45;
            this.label1.Text = "Correo:";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(150, 13);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(287, 20);
            this.txtEmail.TabIndex = 0;
            // 
            // AddUserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(475, 338);
            this.ControlBox = false;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.ComboboxType);
            this.Controls.Add(this.lblType);
            this.Controls.Add(this.lblBDate);
            this.Controls.Add(this.lblSSurname);
            this.Controls.Add(this.txtFNac);
            this.Controls.Add(this.txtSApl);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.lblFSurname);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtFApl);
            this.Controls.Add(this.txtName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AddUserForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Agregar usuario";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox ComboboxType;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.Label lblBDate;
        private System.Windows.Forms.Label lblSSurname;
        private System.Windows.Forms.TextBox txtFNac;
        public System.Windows.Forms.TextBox txtSApl;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Label lblFSurname;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtFApl;
        public System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox txtEmail;
    }
}