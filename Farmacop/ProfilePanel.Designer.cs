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
            this.txtNewPass2 = new System.Windows.Forms.TextBox();
            this.txtNewPass = new System.Windows.Forms.TextBox();
            this.txtOriginalPass = new System.Windows.Forms.TextBox();
            this.lblPassNow = new System.Windows.Forms.Label();
            this.lblNewPass = new System.Windows.Forms.Label();
            this.lblNewPass2 = new System.Windows.Forms.Label();
            this.btnModifyPass = new System.Windows.Forms.Button();
            this.PassBox.SuspendLayout();
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
            this.PassBox.Location = new System.Drawing.Point(25, 392);
            this.PassBox.Name = "PassBox";
            this.PassBox.Size = new System.Drawing.Size(502, 201);
            this.PassBox.TabIndex = 0;
            this.PassBox.TabStop = false;
            this.PassBox.Text = "Modificar contraseña";
            // 
            // txtNewPass2
            // 
            this.txtNewPass2.Location = new System.Drawing.Point(147, 132);
            this.txtNewPass2.Name = "txtNewPass2";
            this.txtNewPass2.Size = new System.Drawing.Size(287, 20);
            this.txtNewPass2.TabIndex = 2;
            this.txtNewPass2.UseSystemPasswordChar = true;
            // 
            // txtNewPass
            // 
            this.txtNewPass.Location = new System.Drawing.Point(147, 87);
            this.txtNewPass.Name = "txtNewPass";
            this.txtNewPass.Size = new System.Drawing.Size(287, 20);
            this.txtNewPass.TabIndex = 1;
            this.txtNewPass.UseSystemPasswordChar = true;
            // 
            // txtOriginalPass
            // 
            this.txtOriginalPass.Location = new System.Drawing.Point(147, 42);
            this.txtOriginalPass.Name = "txtOriginalPass";
            this.txtOriginalPass.Size = new System.Drawing.Size(287, 20);
            this.txtOriginalPass.TabIndex = 0;
            this.txtOriginalPass.UseSystemPasswordChar = true;
            // 
            // lblPassNow
            // 
            this.lblPassNow.AutoSize = true;
            this.lblPassNow.Location = new System.Drawing.Point(45, 45);
            this.lblPassNow.Name = "lblPassNow";
            this.lblPassNow.Size = new System.Drawing.Size(96, 13);
            this.lblPassNow.TabIndex = 3;
            this.lblPassNow.Text = "Contraseña actual:";
            // 
            // lblNewPass
            // 
            this.lblNewPass.AutoSize = true;
            this.lblNewPass.Location = new System.Drawing.Point(43, 90);
            this.lblNewPass.Name = "lblNewPass";
            this.lblNewPass.Size = new System.Drawing.Size(98, 13);
            this.lblNewPass.TabIndex = 4;
            this.lblNewPass.Text = "Nueva contraseña:";
            // 
            // lblNewPass2
            // 
            this.lblNewPass2.AutoSize = true;
            this.lblNewPass2.Location = new System.Drawing.Point(41, 135);
            this.lblNewPass2.Name = "lblNewPass2";
            this.lblNewPass2.Size = new System.Drawing.Size(100, 13);
            this.lblNewPass2.TabIndex = 5;
            this.lblNewPass2.Text = "Repetir contraseña:";
            // 
            // btnModifyPass
            // 
            this.btnModifyPass.Location = new System.Drawing.Point(177, 165);
            this.btnModifyPass.Name = "btnModifyPass";
            this.btnModifyPass.Size = new System.Drawing.Size(129, 23);
            this.btnModifyPass.TabIndex = 6;
            this.btnModifyPass.Text = "Modificar contraseña";
            this.btnModifyPass.UseVisualStyleBackColor = true;
            this.btnModifyPass.Click += new System.EventHandler(this.btnModifyPass_Click);
            // 
            // ProfilePanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.PassBox);
            this.Name = "ProfilePanel";
            this.Size = new System.Drawing.Size(989, 800);
            this.PassBox.ResumeLayout(false);
            this.PassBox.PerformLayout();
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
    }
}
