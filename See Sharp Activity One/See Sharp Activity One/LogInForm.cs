using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace See_Sharp_Activity_One
{
    public partial class LogInForm : Form
    {

        OleDbConnection conn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=DBMoTo_Antiporda_Magat.mdb");

        public LogInForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OleDbCommand comm = conn.CreateCommand();
            conn.Open();
            comm.Connection = conn;
            comm.CommandText = "SELECT * FROM User_Tbl WHERE Username='" + txtUN.Text + "' AND Pword='" + txtPW.Text + "'";
            OleDbDataReader reader = comm.ExecuteReader();

            int counter = 0;

            while (reader.Read())
            {
                counter++;
            }

            conn.Close();

            if (counter > 0)
            {
                MyFirstDatabaseConnection AddEmp = new MyFirstDatabaseConnection();
                AddEmp.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Please check your username and password");
            }
        }
    }
}
