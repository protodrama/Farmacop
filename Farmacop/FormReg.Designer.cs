namespace Farmacop
{
    partial class FormReg
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormReg));
            this.btnAccept = new System.Windows.Forms.Button();
            this.lblNewPass2 = new System.Windows.Forms.Label();
            this.lblNewPass = new System.Windows.Forms.Label();
            this.lblAccount = new System.Windows.Forms.Label();
            this.txtNewPass2 = new System.Windows.Forms.TextBox();
            this.txtNewPass = new System.Windows.Forms.TextBox();
            this.txtAccount = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblEmailMsg = new System.Windows.Forms.Label();
            this.ImgTick = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.ImgTick)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAccept
            // 
            this.btnAccept.Location = new System.Drawing.Point(97, 139);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(129, 23);
            this.btnAccept.TabIndex = 3;
            this.btnAccept.Text = "Aceptar";
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // lblNewPass2
            // 
            this.lblNewPass2.AutoSize = true;
            this.lblNewPass2.Location = new System.Drawing.Point(24, 105);
            this.lblNewPass2.Name = "lblNewPass2";
            this.lblNewPass2.Size = new System.Drawing.Size(100, 13);
            this.lblNewPass2.TabIndex = 12;
            this.lblNewPass2.Text = "Repetir contraseña:";
            // 
            // lblNewPass
            // 
            this.lblNewPass.AutoSize = true;
            this.lblNewPass.Location = new System.Drawing.Point(60, 60);
            this.lblNewPass.Name = "lblNewPass";
            this.lblNewPass.Size = new System.Drawing.Size(64, 13);
            this.lblNewPass.TabIndex = 11;
            this.lblNewPass.Text = "Contraseña:";
            // 
            // lblAccount
            // 
            this.lblAccount.AutoSize = true;
            this.lblAccount.Location = new System.Drawing.Point(83, 15);
            this.lblAccount.Name = "lblAccount";
            this.lblAccount.Size = new System.Drawing.Size(44, 13);
            this.lblAccount.TabIndex = 10;
            this.lblAccount.Text = "Cuenta:";
            // 
            // txtNewPass2
            // 
            this.txtNewPass2.Location = new System.Drawing.Point(130, 102);
            this.txtNewPass2.Name = "txtNewPass2";
            this.txtNewPass2.Size = new System.Drawing.Size(287, 20);
            this.txtNewPass2.TabIndex = 2;
            this.txtNewPass2.UseSystemPasswordChar = true;
            // 
            // txtNewPass
            // 
            this.txtNewPass.Location = new System.Drawing.Point(130, 57);
            this.txtNewPass.Name = "txtNewPass";
            this.txtNewPass.Size = new System.Drawing.Size(287, 20);
            this.txtNewPass.TabIndex = 1;
            this.txtNewPass.UseSystemPasswordChar = true;
            // 
            // txtAccount
            // 
            this.txtAccount.Location = new System.Drawing.Point(130, 12);
            this.txtAccount.Name = "txtAccount";
            this.txtAccount.Size = new System.Drawing.Size(287, 20);
            this.txtAccount.TabIndex = 0;
            this.txtAccount.Leave += new System.EventHandler(this.txtAccount_Leave);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(256, 139);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(129, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblEmailMsg
            // 
            this.lblEmailMsg.AutoSize = true;
            this.lblEmailMsg.Location = new System.Drawing.Point(131, 38);
            this.lblEmailMsg.Name = "lblEmailMsg";
            this.lblEmailMsg.Size = new System.Drawing.Size(0, 13);
            this.lblEmailMsg.TabIndex = 15;
            // 
            // ImgTick
            // 
            this.ImgTick.Location = new System.Drawing.Point(424, 12);
            this.ImgTick.Name = "ImgTick";
            this.ImgTick.Size = new System.Drawing.Size(20, 20);
            this.ImgTick.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ImgTick.TabIndex = 16;
            this.ImgTick.TabStop = false;
            // 
            // FormReg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(479, 178);
            this.ControlBox = false;
            this.Controls.Add(this.ImgTick);
            this.Controls.Add(this.lblEmailMsg);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.lblNewPass2);
            this.Controls.Add(this.lblNewPass);
            this.Controls.Add(this.lblAccount);
            this.Controls.Add(this.txtNewPass2);
            this.Controls.Add(this.txtNewPass);
            this.Controls.Add(this.txtAccount);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormReg";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Activación";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormReg_FormClosing);
            this.Load += new System.EventHandler(this.FormReg_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ImgTick)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Label lblNewPass2;
        private System.Windows.Forms.Label lblNewPass;
        private System.Windows.Forms.Label lblAccount;
        private System.Windows.Forms.TextBox txtNewPass2;
        public System.Windows.Forms.TextBox txtNewPass;
        public System.Windows.Forms.TextBox txtAccount;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblEmailMsg;
        private System.Windows.Forms.PictureBox ImgTick;
    }
}