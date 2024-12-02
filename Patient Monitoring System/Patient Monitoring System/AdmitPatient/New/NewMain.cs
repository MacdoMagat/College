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
    public partial class NewMain : Form
    {
        public AdmitPatient.New.PatientDetails patientDetailsInstance = new PatientDetails();
        public AdmitPatient.New.AdmissionDetails admissionDetailsInstance = new AdmissionDetails();
        public AdmitPatient.New.Confirmation confirmationInstance = new Confirmation();
        public NewMain()
        {
            InitializeComponent();
        }

        private void NewMain_Load(object sender, EventArgs e)
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
