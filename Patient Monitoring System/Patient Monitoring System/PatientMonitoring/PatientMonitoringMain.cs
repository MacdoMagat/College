using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Patient_Monitoring_System.PatientMonitoring
{
    public partial class PatientMonitoringMain : Form
    {

        private PatientMonitoring.PatientDetails patientDetailsInstance = new PatientDetails();
        private PatientMonitoring.FoodSchedule foodScheduleInstance = new FoodSchedule();
        private PatientMonitoring.AdmissionDetails admissionDetailsInstance = new AdmissionDetails();
        private PatientMonitoring.PrintRecord.Print printInstance;
        public PatientMonitoringMain()
        {
            InitializeComponent();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel4_Paint(object sender, PaintEventArgs e)
        {
                    }

        private void PatientMonitoringMain_Load(object sender, EventArgs e)
        {
            patientDetailsInstance.TopLevel = false;
            patientDetailsInstance.Dock = DockStyle.Fill;
            admissionDetailsInstance.TopLevel = false;
            admissionDetailsInstance.Dock = DockStyle.Fill;
            foodScheduleInstance.TopLevel = false;
            foodScheduleInstance.Dock = DockStyle.Fill;

            pnlDetail.Controls.Clear();
            pnlDetail.Controls.Add(patientDetailsInstance);
            patientDetailsInstance.Show();

            dtpDAFrom.Value = DateTime.Today.AddDays(-7);
            dtpDATo.Value = DateTime.Today;
            dtpDRTo.Value = DateTime.Today;
            dtpDRFrom.Value = DateTime.Today.AddDays(-7);
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            pnlDetail.Controls.Clear();
            pnlDetail.Controls.Add(patientDetailsInstance);
            patientDetailsInstance.Show();
        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            pnlDetail.Controls.Clear();
            pnlDetail.Controls.Add(admissionDetailsInstance);
            admissionDetailsInstance.Show();
        }

        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
            pnlDetail.Controls.Clear();
            pnlDetail.Controls.Add(foodScheduleInstance);
            foodScheduleInstance.Show();
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            if (pnlFilter.Width == 275)
            {
                pnlFilter.Visible = false;
                pnlFilter.Width = 45;
                leftPanelCloseTransition.ShowSync(pnlFilter);
            }
            else
            {
                pnlFilter.Visible = false;
                pnlFilter.Width = 275;
                leftPanelOpenTransition.ShowSync(pnlFilter);
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void chkDAAll_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDAAll.Checked)
            {
                dtpDAFrom.Enabled = false;
                dtpDATo.Enabled = false;
                dtpDAFrom.Visible = false;
                dtpDATo.Visible = false;
                lblDATo.Visible = false;
                lblDAFrom.Visible = false;
            }
            else
            {
                dtpDAFrom.Enabled = true;
                dtpDATo.Enabled = true;
                dtpDAFrom.Visible = true;
                dtpDATo.Visible = true;
                lblDAFrom.Visible = true;
                lblDATo.Visible = true;
            }
        }

        private void chkDRAll_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDRAll.Checked)
            {
                dtpDRFrom.Enabled = false;
                dtpDRTo.Enabled = false;
                dtpDRFrom.Visible = false;
                dtpDRTo.Visible = false;
                lblDRFrom.Visible = false;
                lblDRTo.Visible = false;
            }
            else
            {
                dtpDRFrom.Enabled = true;
                dtpDRTo.Enabled = true;
                dtpDRFrom.Visible = true;
                dtpDRTo.Visible = true;
                lblDRFrom.Visible = true;
                lblDRTo.Visible = true;
            }
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {

        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            DataTable table = new DataTable();
            table.Columns.Add("Food");
            table.Columns.Add("Time");
            table.Columns.Add("Date");

            table.Rows.Add("Food", "5:00 AM", "January 8, 2012");
            table.Rows.Add("Food", "5:00 AM", "January 8, 2012");
            table.Rows.Add("Food", "5:00 AM", "January 8, 2012");
            table.Rows.Add("Food", "5:00 AM", "January 8, 2012");
            table.Rows.Add("Food", "5:00 AM", "January 8, 2012");
            table.Rows.Add("Food", "5:00 AM", "January 8, 2012");

            printInstance = new PrintRecord.Print();
            printInstance.createReport("Dummy", "Dummy", "Dummy", "Dummy", "Dummy", "Dummy", "Dummy", "Dummy", "Dummy", "Dummy", "Dummy", "Dummy", "Dummy", "Dummy", "Dummy",
                table);
            printInstance.ShowDialog();
        }
    }
}
