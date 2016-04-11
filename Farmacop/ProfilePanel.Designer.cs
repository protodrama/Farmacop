namespace Farmacop
{
    partial class ProfilePanel
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.PassBox = new System.Windows.Forms.GroupBox();
            this.btnModifyPass = new System.Windows.Forms.Button();
            this.lblNewPass2 = new System.Windows.Forms.Label();
            this.lblNewPass = new System.Windows.Forms.Label();
            this.lblPassNow = new System.Windows.Forms.Label();
            this.txtNewPass2 = new System.Windows.Forms.TextBox();
            this.txtNewPass = new System.Windows.Forms.TextBox();
            this.txtOriginalPass = new System.Windows.Forms.TextBox();
            this.grpUserData = new System.Windows.Forms.GroupBox();
            this.lblTUser = new System.Windows.Forms.Label();
            this.lblFNac = new System.Windows.Forms.Label();
            this.lblApl2 = new System.Windows.Forms.Label();
            this.lblApl1 = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblAccount = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtbxFNac = new System.Windows.Forms.TextBox();
            this.txtbxSApl = new System.Windows.Forms.TextBox();
            this.txtbxFApl = new System.Windows.Forms.TextBox();
            this.txtbxName = new System.Windows.Forms.TextBox();
            this.btnModPData = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.PassBox.SuspendLayout();
            this.grpUserData.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // PassBox
            // 
            this.PassBox.Controls.Add(this.btnModifyPass);
            this.PassBox.Controls.Add(this.lblNewPass2);
            this.PassBox.Controls.Add(this.lblNewPass);
            this.PassBox.Controls.Add(this.lblPassNow);
            this.PassBox.Controls.Add(this.txtNewPass2);
            this.PassBox.Controls.Add(this.txtNewPass);
            this.PassBox.Controls.Add(this.txtOriginalPass);
            this.PassBox.Location = new System.Drawing.Point(25, 373);
            this.PassBox.Name = "PassBox";
            this.PassBox.Size = new System.Drawing.Size(758, 201);
            this.PassBox.TabIndex = 0;
            this.PassBox.TabStop = false;
            this.PassBox.Text = "Modificar contraseña";
            // 
            // btnModifyPass
            // 
            this.btnModifyPass.Location = new System.Drawing.Point(298, 163);
            this.btnModifyPass.Name = "btnModifyPass";
            this.btnModifyPass.Size = new System.Drawing.Size(129, 23);
            this.btnModifyPass.TabIndex = 8;
            this.btnModifyPass.Text = "Modificar contraseña";
            this.btnModifyPass.UseVisualStyleBackColor = true;
            this.btnModifyPass.Click += new System.EventHandler(this.btnModifyPass_Click);
            // 
            // lblNewPass2
            // 
            this.lblNewPass2.AutoSize = true;
            this.lblNewPass2.Location = new System.Drawing.Point(162, 133);
            this.lblNewPass2.Name = "lblNewPass2";
            this.lblNewPass2.Size = new System.Drawing.Size(100, 13);
            this.lblNewPass2.TabIndex = 5;
            this.lblNewPass2.Text = "Repetir contraseña:";
            // 
            // lblNewPass
            // 
            this.lblNewPass.AutoSize = true;
            this.lblNewPass.Location = new System.Drawing.Point(164, 88);
            this.lblNewPass.Name = "lblNewPass";
            this.lblNewPass.Size = new System.Drawing.Size(98, 13);
            this.lblNewPass.TabIndex = 4;
            this.lblNewPass.Text = "Nueva contraseña:";
            // 
            // lblPassNow
            // 
            this.lblPassNow.AutoSize = true;
            this.lblPassNow.Location = new System.Drawing.Point(166, 43);
            this.lblPassNow.Name = "lblPassNow";
            this.lblPassNow.Size = new System.Drawing.Size(96, 13);
            this.lblPassNow.TabIndex = 3;
            this.lblPassNow.Text = "Contraseña actual:";
            // 
            // txtNewPass2
            // 
            this.txtNewPass2.Location = new System.Drawing.Point(268, 130);
            this.txtNewPass2.Name = "txtNewPass2";
            this.txtNewPass2.Size = new System.Drawing.Size(287, 20);
            this.txtNewPass2.TabIndex = 7;
            this.txtNewPass2.UseSystemPasswordChar = true;
            // 
            // txtNewPass
            // 
            this.txtNewPass.Location = new System.Drawing.Point(268, 85);
            this.txtNewPass.Name = "txtNewPass";
            this.txtNewPass.Size = new System.Drawing.Size(287, 20);
            this.txtNewPass.TabIndex = 6;
            this.txtNewPass.UseSystemPasswordChar = true;
            // 
            // txtOriginalPass
            // 
            this.txtOriginalPass.Location = new System.Drawing.Point(268, 40);
            this.txtOriginalPass.Name = "txtOriginalPass";
            this.txtOriginalPass.Size = new System.Drawing.Size(287, 20);
            this.txtOriginalPass.TabIndex = 5;
            this.txtOriginalPass.UseSystemPasswordChar = true;
            // 
            // grpUserData
            // 
            this.grpUserData.Controls.Add(this.lblTUser);
            this.grpUserData.Controls.Add(this.lblFNac);
            this.grpUserData.Controls.Add(this.lblApl2);
            this.grpUserData.Controls.Add(this.lblApl1);
            this.grpUserData.Controls.Add(this.lblName);
            this.grpUserData.Controls.Add(this.lblAccount);
            this.grpUserData.Controls.Add(this.label6);
            this.grpUserData.Controls.Add(this.label5);
            this.grpUserData.Controls.Add(this.label4);
            this.grpUserData.Controls.Add(this.label3);
            this.grpUserData.Controls.Add(this.label2);
            this.grpUserData.Controls.Add(this.label1);
            this.grpUserData.Location = new System.Drawing.Point(25, 3);
            this.grpUserData.Name = "grpUserData";
            this.grpUserData.Size = new System.Drawing.Size(371, 364);
            this.grpUserData.TabIndex = 1;
            this.grpUserData.TabStop = false;
            this.grpUserData.Text = "Datos personales";
            // 
            // lblTUser
            // 
            this.lblTUser.AutoSize = true;
            this.lblTUser.Location = new System.Drawing.Point(157, 196);
            this.lblTUser.Name = "lblTUser";
            this.lblTUser.Size = new System.Drawing.Size(0, 13);
            this.lblTUser.TabIndex = 11;
            // 
            // lblFNac
            // 
            this.lblFNac.AutoSize = true;
            this.lblFNac.Location = new System.Drawing.Point(157, 161);
            this.lblFNac.Name = "lblFNac";
            this.lblFNac.Size = new System.Drawing.Size(0, 13);
            this.lblFNac.TabIndex = 10;
            // 
            // lblApl2
            // 
            this.lblApl2.AutoSize = true;
            this.lblApl2.Location = new System.Drawing.Point(157, 126);
            this.lblApl2.Name = "lblApl2";
            this.lblApl2.Size = new System.Drawing.Size(0, 13);
            this.lblApl2.TabIndex = 9;
            // 
            // lblApl1
            // 
            this.lblApl1.AutoSize = true;
            this.lblApl1.Location = new System.Drawing.Point(157, 91);
            this.lblApl1.Name = "lblApl1";
            this.lblApl1.Size = new System.Drawing.Size(0, 13);
            this.lblApl1.TabIndex = 8;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(157, 56);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(10, 13);
            this.lblName.TabIndex = 7;
            this.lblName.Text = " ";
            // 
            // lblAccount
            // 
            this.lblAccount.AutoSize = true;
            this.lblAccount.Location = new System.Drawing.Point(157, 231);
            this.lblAccount.Name = "lblAccount";
            this.lblAccount.Size = new System.Drawing.Size(0, 13);
            this.lblAccount.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(69, 196);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Tipo de cuenta:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(42, 161);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(109, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Fecha de nacimiento:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(59, 126);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Segundo apellido:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(73, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Primer apellido:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(104, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nombre:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(53, 231);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre de cuenta:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtbxFNac);
            this.groupBox1.Controls.Add(this.txtbxSApl);
            this.groupBox1.Controls.Add(this.txtbxFApl);
            this.groupBox1.Controls.Add(this.txtbxName);
            this.groupBox1.Controls.Add(this.btnModPData);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Location = new System.Drawing.Point(412, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(371, 364);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Modificar datos";
            // 
            // txtbxFNac
            // 
            this.txtbxFNac.Location = new System.Drawing.Point(148, 158);
            this.txtbxFNac.Name = "txtbxFNac";
            this.txtbxFNac.Size = new System.Drawing.Size(126, 20);
            this.txtbxFNac.TabIndex = 3;
            this.txtbxFNac.Click += new System.EventHandler(this.txtbxFNac_Click);
            this.txtbxFNac.Enter += new System.EventHandler(this.txtbxFNac_Enter);
            // 
            // txtbxSApl
            // 
            this.txtbxSApl.Location = new System.Drawing.Point(148, 123);
            this.txtbxSApl.Name = "txtbxSApl";
            this.txtbxSApl.Size = new System.Drawing.Size(126, 20);
            this.txtbxSApl.TabIndex = 2;
            // 
            // txtbxFApl
            // 
            this.txtbxFApl.Location = new System.Drawing.Point(148, 88);
            this.txtbxFApl.Name = "txtbxFApl";
            this.txtbxFApl.Size = new System.Drawing.Size(126, 20);
            this.txtbxFApl.TabIndex = 1;
            // 
            // txtbxName
            // 
            this.txtbxName.Location = new System.Drawing.Point(149, 56);
            this.txtbxName.Name = "txtbxName";
            this.txtbxName.Size = new System.Drawing.Size(125, 20);
            this.txtbxName.TabIndex = 0;
            // 
            // btnModPData
            // 
            this.btnModPData.Location = new System.Drawing.Point(126, 196);
            this.btnModPData.Name = "btnModPData";
            this.btnModPData.Size = new System.Drawing.Size(114, 23);
            this.btnModPData.TabIndex = 4;
            this.btnModPData.Text = "Modificar datos";
            this.btnModPData.UseVisualStyleBackColor = true;
            this.btnModPData.Click += new System.EventHandler(this.btnModPData_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(33, 161);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(109, 13);
            this.label7.TabIndex = 8;
            this.label7.Text = "Fecha de nacimiento:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(50, 126);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(92, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "Segundo apellido:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(64, 91);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(78, 13);
            this.label9.TabIndex = 6;
            this.label9.Text = "Primer apellido:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(95, 56);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(47, 13);
            this.label10.TabIndex = 5;
            this.label10.Text = "Nombre:";
            // 
            // ProfilePanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grpUserData);
            this.Controls.Add(this.PassBox);
            this.Name = "ProfilePanel";
            this.Size = new System.Drawing.Size(989, 800);
            this.PassBox.ResumeLayout(false);
            this.PassBox.PerformLayout();
            this.grpUserData.ResumeLayout(false);
            this.grpUserData.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox txtNewPass2;
        public System.Windows.Forms.TextBox txtNewPass;
        public System.Windows.Forms.TextBox txtOriginalPass;
        public System.Windows.Forms.GroupBox PassBox;
        private System.Windows.Forms.Label lblNewPass2;
        private System.Windows.Forms.Label lblNewPass;
        private System.Windows.Forms.Label lblPassNow;
        private System.Windows.Forms.Button btnModifyPass;
        private System.Windows.Forms.GroupBox grpUserData;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTUser;
        private System.Windows.Forms.Label lblFNac;
        private System.Windows.Forms.Label lblApl2;
        private System.Windows.Forms.Label lblApl1;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblAccount;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnModPData;
        private System.Windows.Forms.TextBox txtbxFNac;
        private System.Windows.Forms.TextBox txtbxSApl;
        private System.Windows.Forms.TextBox txtbxFApl;
        private System.Windows.Forms.TextBox txtbxName;
    }
}
