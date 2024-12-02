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
    public partial class ExistingMain : Form
    {

        public AdmitPatient.Existing.PatientDetails patientDetailsInstance = new PatientDetails();
        public AdmitPatient.Existing.AdmissionDetails admissionDetailsInstance = new AdmissionDetails();
        public AdmitPatient.Existing.Confirmation confirmationInstance = new Confirmation();

        public ExistingMain()
        {
            InitializeComponent();
        }

        private void ExistingMain_Load(object sender, EventArgs e)
        {
            patientDetailsInstance.TopLevel = false;
            patientDetailsInstance.Dock = DockStyle.Fill;
            admissionDetailsInstance.TopLevel = false;
            admissionDetailsInstance.Dock = DockStyle.Fill;
            confirmationInstance.TopLevel = false;
            confirmationInstance.Dock = DockStyle.Fill;

            pnlWorkArea.Controls.Clear();
            pnlWorkArea.Controls.Add(patientDetailsInstance);
            patientDetailsInstance.Show();
        }
    }
}
