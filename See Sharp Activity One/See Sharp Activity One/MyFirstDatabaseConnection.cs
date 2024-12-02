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
    public partial class MyFirstDatabaseConnection : Form
    {

        OleDbConnection conn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=DBMoTo_Antiporda_Magat.mdb");
        
        public MyFirstDatabaseConnection()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtID.ForeColor == Color.Red)
            {
                MessageBox.Show("Please check if your ID only contain a number");
                return;
            }

            if (txtSal.ForeColor == Color.Red)
            {
                MessageBox.Show("Please check if your Salary onlycontain a number");
                return;
            }

            if (txtID.Text == "")
            {
                MessageBox.Show("Please input value on ID");
                return;
            }

            if (txtFN.Text == "")
            {
                MessageBox.Show("Please input value on First Name");
                return;
            }

            if (txtLN.Text == "")
            {
                MessageBox.Show("Please input value on Last Name");
                return;
            }

            if (txtPos.Text == "")
            {
                MessageBox.Show("Please input value on Position");
                return;
            }

            if (txtSal.Text == "")
            {
                MessageBox.Show("Please input value on Salary");
                return;
            }

            if (txtAddress.Text == "")
            {
                MessageBox.Show("Please input value on Address");
                return;
            }
            
            string contactno;
            contactno = txtCN.Text.Replace("(", "");
            contactno = contactno.Replace(")", "");
            contactno = contactno.Replace("+", "");
            contactno = contactno.Replace("-", "");

            if (contactno.Length < 12)
            {
                MessageBox.Show("Please complete your number");
                return;
            }

            if (checkIDDuplicate(txtID.Text))
            {
                MessageBox.Show("Duplicate in ID detected");
                return;
            }

            OleDbCommand comm = conn.CreateCommand();
            conn.Open();
            comm.CommandText = "INSERT INTO Employee_Tbl([EmpID], [Fname], [LName], [Position], [Salary], [ContactNo], [Address]) VALUES(" + txtID.Text + ",'" + txtFN.Text + "', '" + txtLN.Text + "', '" + txtPos.Text + "', " + txtSal.Text + ", " + contactno + ", '" + txtAddress.Text +"')";
            comm.Connection = conn;
            comm.ExecuteNonQuery();
            MessageBox.Show("Recorded");
            txtID.Text = "";
            txtFN.Text = "";
            txtLN.Text = "";
            txtAddress.Text = "";
            txtPos.Text = "";
            txtSal.Text = "";
            txtCN.Text = "";
            conn.Close();
        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {
            int id;
            if(int.TryParse(txtID.Text, out id) == false)
            {
                txtID.ForeColor = Color.Red;
            }
            else
            {
                txtID.ForeColor = Color.Black;
            }
        }

        public bool checkIDDuplicate(string id)
        {
            OleDbCommand comm = conn.CreateCommand();
            conn.Open();
            comm.Connection = conn;
            comm.CommandText = "SELECT * FROM Employee_Tbl WHERE [EmpID]=" + txtID.Text;
            OleDbDataReader reader = comm.ExecuteReader();

            int counter = 0;

            while (reader.Read())
            {
                counter++;
            } 
           
            conn.Close();

            if (counter > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void txtSal_TextChanged(object sender, EventArgs e)
        {
            double salary;
            if (double.TryParse(txtSal.Text, out salary) == false)
            {
                txtSal.ForeColor = Color.Red;
            }
            else
            {
                txtSal.ForeColor = Color.Black;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtID.Text = "";
            txtFN.Text = "";
            txtLN.Text = "";
            txtAddress.Text = "";
            txtPos.Text = "";
            txtSal.Text = "";
            txtCN.Text = "";
        }

     
    }
}
