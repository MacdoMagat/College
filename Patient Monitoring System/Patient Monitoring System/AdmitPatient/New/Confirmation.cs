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
    public partial class Confirmation : Form
    {
        public Confirmation()
        {
            InitializeComponent();
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Saved");
            Program.newMainInstance.Close();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Program.newMainInstance.lblPatientDetails.BackColor = Color.SeaGreen;
            Program.newMainInstance.lblAdmissionDetails.BackColor = Color.MediumSlateBlue;
            Program.newMainInstance.lblConfirmation.BackColor = Color.SeaGreen;

            Program.newMainInstance.pnlWorkArea.Controls.Clear();
            Program.newMainInstance.pnlWorkArea.Controls.Add(Program.newMainInstance.admissionDetailsInstance);
            Program.newMainInstance.admissionDetailsInstance.Show();
        }
    }
}
