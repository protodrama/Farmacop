namespace Farmacop
{
    partial class MessageForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MessageForm));
            this.btnAnsw = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblSender = new System.Windows.Forms.Label();
            this.lblMatter = new System.Windows.Forms.Label();
            this.lblMsg = new System.Windows.Forms.Label();
            this.txtMatter = new System.Windows.Forms.Label();
            this.txtSender = new System.Windows.Forms.Label();
            this.txtMsg = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnAnsw
            // 
            this.btnAnsw.Location = new System.Drawing.Point(113, 265);
            this.btnAnsw.Name = "btnAnsw";
            this.btnAnsw.Size = new System.Drawing.Size(75, 23);
            this.btnAnsw.TabIndex = 0;
            this.btnAnsw.Text = "Responder";
            this.btnAnsw.UseVisualStyleBackColor = true;
            this.btnAnsw.Click += new System.EventHandler(this.btnAnsw_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(246, 265);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Cerrar";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblSender
            // 
            this.lblSender.AutoSize = true;
            this.lblSender.Location = new System.Drawing.Point(39, 23);
            this.lblSender.Name = "lblSender";
            this.lblSender.Size = new System.Drawing.Size(41, 13);
            this.lblSender.TabIndex = 2;
            this.lblSender.Text = "Emisor:";
            // 
            // lblMatter
            // 
            this.lblMatter.AutoSize = true;
            this.lblMatter.Location = new System.Drawing.Point(39, 50);
            this.lblMatter.Name = "lblMatter";
            this.lblMatter.Size = new System.Drawing.Size(43, 13);
            this.lblMatter.TabIndex = 3;
            this.lblMatter.Text = "Asunto:";
            // 
            // lblMsg
            // 
            this.lblMsg.AutoSize = true;
            this.lblMsg.Location = new System.Drawing.Point(39, 78);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(50, 13);
            this.lblMsg.TabIndex = 4;
            this.lblMsg.Text = "Mensaje:";
            // 
            // txtMatter
            // 
            this.txtMatter.AutoSize = true;
            this.txtMatter.Location = new System.Drawing.Point(96, 50);
            this.txtMatter.Name = "txtMatter";
            this.txtMatter.Size = new System.Drawing.Size(0, 13);
            this.txtMatter.TabIndex = 6;
            // 
            // txtSender
            // 
            this.txtSender.AutoSize = true;
            this.txtSender.Location = new System.Drawing.Point(96, 23);
            this.txtSender.Name = "txtSender";
            this.txtSender.Size = new System.Drawing.Size(0, 13);
            this.txtSender.TabIndex = 5;
            // 
            // txtMsg
            // 
            this.txtMsg.Location = new System.Drawing.Point(42, 105);
            this.txtMsg.Multiline = true;
            this.txtMsg.Name = "txtMsg";
            this.txtMsg.ReadOnly = true;
            this.txtMsg.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMsg.Size = new System.Drawing.Size(354, 146);
            this.txtMsg.TabIndex = 7;
            // 
            // MessageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(442, 317);
            this.ControlBox = false;
            this.Controls.Add(this.txtMsg);
            this.Controls.Add(this.txtMatter);
            this.Controls.Add(this.txtSender);
            this.Controls.Add(this.lblMsg);
            this.Controls.Add(this.lblMatter);
            this.Controls.Add(this.lblSender);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnAnsw);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MessageForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Mensaje";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAnsw;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblSender;
        private System.Windows.Forms.Label lblMatter;
        private System.Windows.Forms.Label lblMsg;
        private System.Windows.Forms.Label txtMatter;
        private System.Windows.Forms.Label txtSender;
        private System.Windows.Forms.TextBox txtMsg;
    }
}