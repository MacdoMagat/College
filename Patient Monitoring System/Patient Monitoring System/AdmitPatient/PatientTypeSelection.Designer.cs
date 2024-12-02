namespace Patient_Monitoring_System.AdmitPatient
{
    partial class PatientTypeSelection
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PatientTypeSelection));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnNewPatient = new Bunifu.Framework.UI.BunifuTileButton();
            this.btnExistingPatient = new Bunifu.Framework.UI.BunifuTileButton();
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.bunifuElipse2 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.btnNewPatient, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnExistingPatient, 3, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 285F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(655, 360);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // btnNewPatient
            // 
            this.btnNewPatient.BackColor = System.Drawing.Color.SeaGreen;
            this.btnNewPatient.color = System.Drawing.Color.SeaGreen;
            this.btnNewPatient.colorActive = System.Drawing.Color.MediumSeaGreen;
            this.btnNewPatient.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNewPatient.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnNewPatient.Font = new System.Drawing.Font("Century Gothic", 15.75F);
            this.btnNewPatient.ForeColor = System.Drawing.Color.White;
            this.btnNewPatient.Image = ((System.Drawing.Image)(resources.GetObject("btnNewPatient.Image")));
            this.btnNewPatient.ImagePosition = 20;
            this.btnNewPatient.ImageZoom = 50;
            this.btnNewPatient.LabelPosition = 100;
            this.btnNewPatient.LabelText = "New Patient";
            this.btnNewPatient.Location = new System.Drawing.Point(113, 43);
            this.btnNewPatient.Margin = new System.Windows.Forms.Padding(6);
            this.btnNewPatient.Name = "btnNewPatient";
            this.btnNewPatient.Size = new System.Drawing.Size(188, 273);
            this.btnNewPatient.TabIndex = 0;
            this.btnNewPatient.Click += new System.EventHandler(this.bunifuTileButton1_Click);
            // 
            // btnExistingPatient
            // 
            this.btnExistingPatient.BackColor = System.Drawing.Color.SeaGreen;
            this.btnExistingPatient.color = System.Drawing.Color.SeaGreen;
            this.btnExistingPatient.colorActive = System.Drawing.Color.MediumSeaGreen;
            this.btnExistingPatient.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExistingPatient.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnExistingPatient.Font = new System.Drawing.Font("Century Gothic", 15.75F);
            this.btnExistingPatient.ForeColor = System.Drawing.Color.White;
            this.btnExistingPatient.Image = ((System.Drawing.Image)(resources.GetObject("btnExistingPatient.Image")));
            this.btnExistingPatient.ImagePosition = 20;
            this.btnExistingPatient.ImageZoom = 50;
            this.btnExistingPatient.LabelPosition = 100;
            this.btnExistingPatient.LabelText = "Existing Patient";
            this.btnExistingPatient.Location = new System.Drawing.Point(353, 43);
            this.btnExistingPatient.Margin = new System.Windows.Forms.Padding(6);
            this.btnExistingPatient.Name = "btnExistingPatient";
            this.btnExistingPatient.Size = new System.Drawing.Size(188, 273);
            this.btnExistingPatient.TabIndex = 1;
            this.btnExistingPatient.Click += new System.EventHandler(this.btnExistingPatient_Click);
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 30;
            this.bunifuElipse1.TargetControl = this.btnNewPatient;
            // 
            // bunifuElipse2
            // 
            this.bunifuElipse2.ElipseRadius = 30;
            this.bunifuElipse2.TargetControl = this.btnExistingPatient;
            // 
            // PatientTypeSelection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(655, 360);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PatientTypeSelection";
            this.Text = "PatientTypeSelection";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Bunifu.Framework.UI.BunifuTileButton btnNewPatient;
        private Bunifu.Framework.UI.BunifuTileButton btnExistingPatient;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse2;
    }
}