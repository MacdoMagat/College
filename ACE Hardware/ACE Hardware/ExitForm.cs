using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ACE_Hardware
{
    public partial class ExitForm : Form
    {

        private MySqlConnection conn = new MySqlConnection();
        private string connstring = Program.connstring;

        public ExitForm()
        {
            InitializeComponent();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                conn.ConnectionString = connstring;
                conn.Open();

                MySqlCommand comm = new MySqlCommand();
                string query = "INSERT INTO logstbl(username,process,description,dateandtime) VALUES('" + Program.login.username + "','Logout','Logout',NOW())";

                comm.Connection = conn;
                comm.CommandText = query;
                comm.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
               MessageBox.Show(ex.ToString());
            }
            finally
            {
                conn.Close();
            }

            Program.login.TextBox1.Text = "";
            Program.login.TextBox2.Text = "";
            Program.login.type = "";
            Program.login.Show();
            this.Close();
            Program.mainFormInstance.Hide();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                conn.ConnectionString = connstring;
                conn.Open();

                MySqlCommand comm = new MySqlCommand();
                string query = "INSERT INTO logstbl(username,process,description,dateandtime) VALUES('" + Program.login.username + "','Logout','Logout',NOW())";

                comm.Connection = conn;
                comm.CommandText = query;
                comm.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                conn.Close();
            }
            Application.Exit();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
