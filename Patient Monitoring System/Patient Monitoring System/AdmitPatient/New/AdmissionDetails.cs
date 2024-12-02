using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Patient_Monitoring_System.AdmitPatient.New
{
    public partial class AdmissionDetails : Form
    {
        public AdmissionDetails()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Program.newMainInstance.lblPatientDetails.BackColor = Color.MediumSlateBlue;
            Program.newMainInstance.lblAdmissionDetails.BackColor = Color.SeaGreen;
            Program.newMainInstance.lblConfirmation.BackColor = Color.SeaGreen;


            Program.newMainInstance.pnlWorkArea.Controls.Clear();
            Program.newMainInstance.pnlWorkArea.Controls.Add(Program.newMainInstance.patientDetailsInstance);
            Program.newMainInstance.patientDetailsInstance.Show();
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            Program.newMainInstance.lblPatientDetails.BackColor = Color.SeaGreen;
            Program.newMainInstance.lblAdmissionDetails.BackColor = Color.SeaGreen;
            Program.newMainInstance.lblConfirmation.BackColor = Color.MediumSlateBlue;

            Program.newMainInstance.pnlWorkArea.Controls.Clear();
            Program.newMainInstance.pnlWorkArea.Controls.Add(Program.newMainInstance.confirmationInstance);
            Program.newMainInstance.confirmationInstance.Show();
        }
    }
}
