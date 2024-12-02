using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Patient_Monitoring_System
{
    static class Program
    {
        public static Main mainInstance;
        public static AdmitPatient.New.NewMain newMainInstance;
        public static AdmitPatient.Existing.ExistingMain existingMainInstance;
        public static PatientMonitoring.PatientMonitoringMain patientMonitoringInstance;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
       
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(mainInstance = new Main());
            //Application.Run(new PatientMonitoring.PatientMonitoringMain());
        }
    }
}
