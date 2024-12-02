namespace Patient_Monitoring_System.AdmitPatient.New
{
    partial class NewMain
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
            this.pnlWorkArea = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.lblNextOne = new System.Windows.Forms.Label();
            this.lblNextTwo = new System.Windows.Forms.Label();
            this.lblPatientDetails = new System.Windows.Forms.Label();
            this.lblAdmissionDetails = new System.Windows.Forms.Label();
            this.lblConfirmation = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlWorkArea
            // 
            this.pnlWorkArea.BackColor = System.Drawing.Color.White;
            this.pnlWorkArea.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlWorkArea.Location = new System.Drawing.Point(0, 62);
            this.pnlWorkArea.Margin = new System.Windows.Forms.Padding(0);
            this.pnlWorkArea.Name = "pnlWorkArea";
            this.pnlWorkArea.Size = new System.Drawing.Size(900, 378);
            this.pnlWorkArea.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.pnlWorkArea, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 62F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(900, 440);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 5;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.Controls.Add(this.lblNextOne, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblNextTwo, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblPatientDetails, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblAdmissionDetails, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblConfirmation, 4, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 62F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(900, 62);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // lblNextOne
            // 
            this.lblNextOne.AutoSize = true;
            this.lblNextOne.BackColor = System.Drawing.Color.SeaGreen;
            this.lblNextOne.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNextOne.Font = new System.Drawing.Font("Century Gothic", 15F);
            this.lblNextOne.ForeColor = System.Drawing.Color.White;
            this.lblNextOne.Location = new System.Drawing.Point(266, 0);
            this.lblNextOne.Margin = new System.Windows.Forms.Padding(0);
            this.lblNextOne.Name = "lblNextOne";
            this.lblNextOne.Size = new System.Drawing.Size(50, 62);
            this.lblNextOne.TabIndex = 0;
            this.lblNextOne.Text = ">";
            this.lblNextOne.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblNextTwo
            // 
            this.lblNextTwo.AutoSize = true;
            this.lblNextTwo.BackColor = System.Drawing.Color.SeaGreen;
            this.lblNextTwo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNextTwo.Font = new System.Drawing.Font("Century Gothic", 15F);
            this.lblNextTwo.ForeColor = System.Drawing.Color.White;
            this.lblNextTwo.Location = new System.Drawing.Point(582, 0);
            this.lblNextTwo.Margin = new System.Windows.Forms.Padding(0);
            this.lblNextTwo.Name = "lblNextTwo";
            this.lblNextTwo.Size = new System.Drawing.Size(50, 62);
            this.lblNextTwo.TabIndex = 1;
            this.lblNextTwo.Text = ">";
            this.lblNextTwo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPatientDetails
            // 
            this.lblPatientDetails.AutoSize = true;
            this.lblPatientDetails.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.lblPatientDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPatientDetails.Font = new System.Drawing.Font("Century Gothic", 15F);
            this.lblPatientDetails.ForeColor = System.Drawing.Color.White;
            this.lblPatientDetails.Location = new System.Drawing.Point(0, 0);
            this.lblPatientDetails.Margin = new System.Windows.Forms.Padding(0);
            this.lblPatientDetails.Name = "lblPatientDetails";
            this.lblPatientDetails.Size = new System.Drawing.Size(266, 62);
            this.lblPatientDetails.TabIndex = 2;
            this.lblPatientDetails.Text = "Patient Details";
            this.lblPatientDetails.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAdmissionDetails
            // 
            this.lblAdmissionDetails.AutoSize = true;
            this.lblAdmissionDetails.BackColor = System.Drawing.Color.SeaGreen;
            this.lblAdmissionDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAdmissionDetails.Font = new System.Drawing.Font("Century Gothic", 15F);
            this.lblAdmissionDetails.ForeColor = System.Drawing.Color.White;
            this.lblAdmissionDetails.Location = new System.Drawing.Point(316, 0);
            this.lblAdmissionDetails.Margin = new System.Windows.Forms.Padding(0);
            this.lblAdmissionDetails.Name = "lblAdmissionDetails";
            this.lblAdmissionDetails.Size = new System.Drawing.Size(266, 62);
            this.lblAdmissionDetails.TabIndex = 3;
            this.lblAdmissionDetails.Text = "Admission Details";
            this.lblAdmissionDetails.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblConfirmation
            // 
            this.lblConfirmation.AutoSize = true;
            this.lblConfirmation.BackColor = System.Drawing.Color.SeaGreen;
            this.lblConfirmation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblConfirmation.Font = new System.Drawing.Font("Century Gothic", 15F);
            this.lblConfirmation.ForeColor = System.Drawing.Color.White;
            this.lblConfirmation.Location = new System.Drawing.Point(632, 0);
            this.lblConfirmation.Margin = new System.Windows.Forms.Padding(0);
            this.lblConfirmation.Name = "lblConfirmation";
            this.lblConfirmation.Size = new System.Drawing.Size(268, 62);
            this.lblConfirmation.TabIndex = 4;
            this.lblConfirmation.Text = "Confirmation";
            this.lblConfirmation.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // NewMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 440);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "NewMain";
            this.Text = "Admit Patient";
            this.Load += new System.EventHandler(this.NewMain_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        public System.Windows.Forms.Panel pnlWorkArea;
        public System.Windows.Forms.Label lblNextOne;
        public System.Windows.Forms.Label lblNextTwo;
        public System.Windows.Forms.Label lblPatientDetails;
        public System.Windows.Forms.Label lblAdmissionDetails;
        public System.Windows.Forms.Label lblConfirmation;
    }
}