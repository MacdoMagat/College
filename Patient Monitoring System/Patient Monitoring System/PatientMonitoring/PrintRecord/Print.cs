using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Patient_Monitoring_System.PatientMonitoring.PrintRecord
{
    public partial class Print : Form
    {
        public Print()
        {
            InitializeComponent();
        }

        public void createReport(string firstName,
            string middleName,
            string lastName,
            string address,
            string contactNumber,
            string dateOfBirth,
            string disease,
            string diagnosis,
            string doctor,
            string dateAdmitted,
            string dateReleased,
            string bedNumber,
            string breakfast,
            string lunch,
            string dinner,
            DataTable foodIntakeRecord)
        {
            PatientMonitoring.PrintRecord.PatientRecord patientRecordInstance = new PatientRecord();

            patientRecordInstance.SetDataSource(foodIntakeRecord);
            patientRecordInstance.SetParameterValue("firstName", firstName);
            patientRecordInstance.SetParameterValue("middleName", middleName);
            patientRecordInstance.SetParameterValue("lastName", lastName);
            patientRecordInstance.SetParameterValue("address", address);
            patientRecordInstance.SetParameterValue("contactNumber", contactNumber);
            patientRecordInstance.SetParameterValue("dateOfBirth", dateOfBirth);
            patientRecordInstance.SetParameterValue("disease", disease);
            patientRecordInstance.SetParameterValue("diagnosis", diagnosis);
            patientRecordInstance.SetParameterValue("doctor", doctor);
            patientRecordInstance.SetParameterValue("dateAdmitted", dateAdmitted);
            patientRecordInstance.SetParameterValue("dateReleased", dateReleased);
            patientRecordInstance.SetParameterValue("bedNumber", bedNumber);
            patientRecordInstance.SetParameterValue("breakfast", breakfast);
            patientRecordInstance.SetParameterValue("lunch", lunch);
            patientRecordInstance.SetParameterValue("dinner", dinner);

            crystalReportViewer1.ReportSource = patientRecordInstance;
            //crystalReportViewer1.Refresh();
        }

    }
}
