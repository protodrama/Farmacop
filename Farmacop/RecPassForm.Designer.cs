namespace Farmacop
{
    partial class RecPassForm
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
            this.ImgTick = new System.Windows.Forms.PictureBox();
            this.lblEmailMsg = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnAccept = new System.Windows.Forms.Button();
            this.lblAccount = new System.Windows.Forms.Label();
            this.txtAccount = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.ImgTick)).BeginInit();
            this.SuspendLayout();
            // 
            // ImgTick
            // 
            this.ImgTick.Location = new System.Drawing.Point(365, 29);
            this.ImgTick.Name = "ImgTick";
            this.ImgTick.Size = new System.Drawing.Size(20, 20);
            this.ImgTick.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ImgTick.TabIndex = 26;
            this.ImgTick.TabStop = false;
            // 
            // lblEmailMsg
            // 
            this.lblEmailMsg.AutoSize = true;
            this.lblEmailMsg.Location = new System.Drawing.Point(72, 55);
            this.lblEmailMsg.Name = "lblEmailMsg";
            this.lblEmailMsg.Size = new System.Drawing.Size(0, 13);
            this.lblEmailMsg.TabIndex = 25;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(216, 83);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(129, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnAccept
            // 
            this.btnAccept.Location = new System.Drawing.Point(57, 83);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(129, 23);
            this.btnAccept.TabIndex = 1;
            this.btnAccept.Text = "Aceptar";
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // lblAccount
            // 
            this.lblAccount.AutoSize = true;
            this.lblAccount.Location = new System.Drawing.Point(24, 32);
            this.lblAccount.Name = "lblAccount";
            this.lblAccount.Size = new System.Drawing.Size(44, 13);
            this.lblAccount.TabIndex = 22;
            this.lblAccount.Text = "Cuenta:";
            // 
            // txtAccount
            // 
            this.txtAccount.Location = new System.Drawing.Point(71, 29);
            this.txtAccount.Name = "txtAccount";
            this.txtAccount.Size = new System.Drawing.Size(287, 20);
            this.txtAccount.TabIndex = 0;
            this.txtAccount.Leave += new System.EventHandler(this.txtAccount_Leave);
            // 
            // RecPassForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(411, 136);
            this.ControlBox = false;
            this.Controls.Add(this.ImgTick);
            this.Controls.Add(this.lblEmailMsg);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.lblAccount);
            this.Controls.Add(this.txtAccount);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "RecPassForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Recuperar contraseña";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RecPassForm_FormClosing);
            this.Load += new System.EventHandler(this.RecPassForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ImgTick)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox ImgTick;
        private System.Windows.Forms.Label lblEmailMsg;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Label lblAccount;
        public System.Windows.Forms.TextBox txtAccount;
    }
}