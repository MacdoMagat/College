using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Patient_Monitoring_System.AdmitPatient.Existing
{
    public partial class PatientDetails : Form
    {
        public PatientDetails()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Program.existingMainInstance.Close();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            Program.existingMainInstance.pnlWorkArea.Controls.Clear();
            Program.existingMainInstance.pnlWorkArea.Controls.Add(Program.existingMainInstance.admissionDetailsInstance);
            Program.existingMainInstance.admissionDetailsInstance.Show();

            Program.existingMainInstance.lblAdmissionDetails.BackColor = Color.MediumSlateBlue;
            Program.existingMainInstance.lblConfirmation.BackColor = Color.SeaGreen;
            Program.existingMainInstance.lblPatientDetails.BackColor = Color.SeaGreen;
        }
    }
}
