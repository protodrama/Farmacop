namespace Farmacop
{
    partial class FormControls
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
            this.txtMedic = new System.Windows.Forms.Label();
            this.txtPatient = new System.Windows.Forms.Label();
            this.lblMsg = new System.Windows.Forms.Label();
            this.lblMatter = new System.Windows.Forms.Label();
            this.lblPatient = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSendMsg = new System.Windows.Forms.Button();
            this.TakenGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.TakenGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // txtMedic
            // 
            this.txtMedic.AutoSize = true;
            this.txtMedic.Location = new System.Drawing.Point(121, 50);
            this.txtMedic.Name = "txtMedic";
            this.txtMedic.Size = new System.Drawing.Size(0, 13);
            this.txtMedic.TabIndex = 14;
            // 
            // txtPatient
            // 
            this.txtPatient.AutoSize = true;
            this.txtPatient.Location = new System.Drawing.Point(121, 23);
            this.txtPatient.Name = "txtPatient";
            this.txtPatient.Size = new System.Drawing.Size(0, 13);
            this.txtPatient.TabIndex = 13;
            // 
            // lblMsg
            // 
            this.lblMsg.AutoSize = true;
            this.lblMsg.Location = new System.Drawing.Point(51, 78);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(42, 13);
            this.lblMsg.TabIndex = 12;
            this.lblMsg.Text = "Tomas:";
            // 
            // lblMatter
            // 
            this.lblMatter.AutoSize = true;
            this.lblMatter.Location = new System.Drawing.Point(19, 50);
            this.lblMatter.Name = "lblMatter";
            this.lblMatter.Size = new System.Drawing.Size(74, 13);
            this.lblMatter.TabIndex = 11;
            this.lblMatter.Text = "Medicamento:";
            // 
            // lblPatient
            // 
            this.lblPatient.AutoSize = true;
            this.lblPatient.Location = new System.Drawing.Point(41, 23);
            this.lblPatient.Name = "lblPatient";
            this.lblPatient.Size = new System.Drawing.Size(52, 13);
            this.lblPatient.TabIndex = 10;
            this.lblPatient.Text = "Paciente:";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(249, 440);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 9;
            this.btnClose.Text = "Cerrar";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSendMsg
            // 
            this.btnSendMsg.Location = new System.Drawing.Point(94, 440);
            this.btnSendMsg.Name = "btnSendMsg";
            this.btnSendMsg.Size = new System.Drawing.Size(107, 23);
            this.btnSendMsg.TabIndex = 8;
            this.btnSendMsg.Text = "Mandar mensaje";
            this.btnSendMsg.UseVisualStyleBackColor = true;
            this.btnSendMsg.Click += new System.EventHandler(this.btnSendMsg_Click);
            // 
            // TakenGridView
            // 
            this.TakenGridView.AllowUserToAddRows = false;
            this.TakenGridView.AllowUserToDeleteRows = false;
            this.TakenGridView.AllowUserToResizeColumns = false;
            this.TakenGridView.AllowUserToResizeRows = false;
            this.TakenGridView.BackgroundColor = System.Drawing.SystemColors.Control;
            this.TakenGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TakenGridView.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.TakenGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.TakenGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TakenGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.TakenGridView.GridColor = System.Drawing.SystemColors.AppWorkspace;
            this.TakenGridView.Location = new System.Drawing.Point(65, 111);
            this.TakenGridView.MultiSelect = false;
            this.TakenGridView.Name = "TakenGridView";
            this.TakenGridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.TakenGridView.RowHeadersVisible = false;
            this.TakenGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.TakenGridView.ShowEditingIcon = false;
            this.TakenGridView.Size = new System.Drawing.Size(321, 312);
            this.TakenGridView.TabIndex = 15;
            // 
            // FormControls
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(445, 493);
            this.ControlBox = false;
            this.Controls.Add(this.TakenGridView);
            this.Controls.Add(this.txtMedic);
            this.Controls.Add(this.txtPatient);
            this.Controls.Add(this.lblMsg);
            this.Controls.Add(this.lblMatter);
            this.Controls.Add(this.lblPatient);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSendMsg);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormControls";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Control de tomas";
            ((System.ComponentModel.ISupportInitialize)(this.TakenGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label txtMedic;
        private System.Windows.Forms.Label txtPatient;
        private System.Windows.Forms.Label lblMsg;
        private System.Windows.Forms.Label lblMatter;
        private System.Windows.Forms.Label lblPatient;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSendMsg;
        private System.Windows.Forms.DataGridView TakenGridView;
    }
}