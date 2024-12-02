using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Patient_Monitoring_System
{
    public partial class Main : Form
    {
        public static AdmitPatient.PatientTypeSelection patientTypeSelectionInstance = new AdmitPatient.PatientTypeSelection();
        public AdmitPatient.New.NewMain admitNewPatientMainInstance = new AdmitPatient.New.NewMain();
        public PatientMonitoring.PatientMonitoringHome patientMonitoringHomeInstance = new PatientMonitoring.PatientMonitoringHome();
        public Report.ReportFilter reportFilterInstance = new Report.ReportFilter();

        public Main()
        {
            InitializeComponent();
        }

       

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            pnlWorkArea.Controls.Clear();
            pnlWorkArea.Controls.Add(patientTypeSelectionInstance);
            patientTypeSelectionInstance.Show();
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            pnlWorkArea.Controls.Clear();
            pnlWorkArea.Controls.Add(patientMonitoringHomeInstance);
            patientMonitoringHomeInstance.Show();
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            if (leftPnl.Width == 200)
            {
                leftPnl.Visible = false;
                leftPnl.Width = 45;
                leftPanelCloseTransition.ShowSync(leftPnl);
            }
            else
            {
                leftPnl.Visible = false;
                leftPnl.Width = 200;
                leftPanelOpenTransition.ShowSync(leftPnl);
            }
        }

        private void Main_Load(object sender, EventArgs e)
        {
            patientTypeSelectionInstance.TopLevel = false;
            patientTypeSelectionInstance.Dock = DockStyle.Fill;
            patientMonitoringHomeInstance.TopLevel = false;
            patientMonitoringHomeInstance.Dock = DockStyle.Fill;
            reportFilterInstance.TopLevel = false;
            reportFilterInstance.Dock = DockStyle.Fill;
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            pnlWorkArea.Controls.Clear();
            pnlWorkArea.Controls.Add(reportFilterInstance);
            reportFilterInstance.cboPreriodicity.SelectedIndex = 4;
            reportFilterInstance.dtpFrom.Value = DateTime.Today;
            reportFilterInstance.dtpTo.Value = reportFilterInstance.dtpFrom.Value;
            reportFilterInstance.Show();
        }

        private void bunifuImageButton3_Click(object sender, EventArgs e)
        {
            
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Program.mainInstance.WindowState = FormWindowState.Minimized;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
