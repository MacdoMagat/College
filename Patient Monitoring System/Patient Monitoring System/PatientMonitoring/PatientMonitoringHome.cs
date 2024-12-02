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
    public partial class PatientMonitoringHome : Form
    {
        public PatientMonitoringHome()
        {
            InitializeComponent();
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            Program.patientMonitoringInstance = new PatientMonitoringMain();
            Program.patientMonitoringInstance.ShowDialog();
        }
    }
}
