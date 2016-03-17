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
            this.PassBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // PassBox
            // 
            this.PassBox.Controls.Add(this.txtNewPass2);
            this.PassBox.Controls.Add(this.txtNewPass);
            this.PassBox.Controls.Add(this.txtOriginalPass);
            this.PassBox.Location = new System.Drawing.Point(26, 374);
            this.PassBox.Name = "PassBox";
            this.PassBox.Size = new System.Drawing.Size(502, 247);
            this.PassBox.TabIndex = 0;
            this.PassBox.TabStop = false;
            this.PassBox.Text = "Contraseña";
            // 
            // txtNewPass2
            // 
            this.txtNewPass2.Location = new System.Drawing.Point(146, 147);
            this.txtNewPass2.Name = "txtNewPass2";
            this.txtNewPass2.Size = new System.Drawing.Size(287, 20);
            this.txtNewPass2.TabIndex = 2;
            this.txtNewPass2.UseSystemPasswordChar = true;
            // 
            // txtNewPass
            // 
            this.txtNewPass.Location = new System.Drawing.Point(146, 100);
            this.txtNewPass.Name = "txtNewPass";
            this.txtNewPass.Size = new System.Drawing.Size(287, 20);
            this.txtNewPass.TabIndex = 1;
            this.txtNewPass.UseSystemPasswordChar = true;
            // 
            // txtOriginalPass
            // 
            this.txtOriginalPass.Location = new System.Drawing.Point(146, 55);
            this.txtOriginalPass.Name = "txtOriginalPass";
            this.txtOriginalPass.Size = new System.Drawing.Size(287, 20);
            this.txtOriginalPass.TabIndex = 0;
            this.txtOriginalPass.UseSystemPasswordChar = true;
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
    }
}
