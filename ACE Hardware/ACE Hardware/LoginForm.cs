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
    public partial class LoginForm : Form
    {

        private MySqlConnection conn = new MySqlConnection();
        private string connstring = Program.connstring;
        public string type;
        public string username;

        public LoginForm()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {

            try
            {
                conn.ConnectionString = connstring;
                conn.Open();

                MySqlCommand comm = new MySqlCommand();
                string query = "SELECT * FROM usertbl WHERE username='" + TextBox1.Text + "' AND userpassword='" + TextBox2.Text + "'";
                MySqlDataReader reader;

                comm.Connection = conn;
                comm.CommandText = query;
                reader = comm.ExecuteReader();

                int counter = 0;

                while (reader.Read())
                    counter = counter + 1;
                if (counter > 0)
                {
                    type = reader["usertype"].ToString();
                    username = reader["username"].ToString();
                    Program.mainFormInstance.Show();
                    this.Hide();
                }
                else
                    MessageBox.Show("Please check your username and password");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                conn.Close();
            }
            if (type == "Employee")
            {
                Program.mainFormInstance.Button1.Enabled = true;
                Program.mainFormInstance.Button2.Enabled = false;
                Program.mainFormInstance.Button3.Enabled = false;
                Program.mainFormInstance.Button4.Enabled = false;
                Program.mainFormInstance.Button5.Enabled = false;
                Program.mainFormInstance.Button6.Enabled = true;

                try
                {
                    conn.ConnectionString = connstring;
                    conn.Open();

                    MySqlCommand comm = new MySqlCommand();
                    string query = "INSERT INTO logstbl(username,process,description,dateandtime) VALUES('" + username + "','Login','Logged in',NOW())";

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
            }
            else if (type == "Administrator")
            {
                Program.mainFormInstance.Button1.Enabled = true;
                Program.mainFormInstance.Button2.Enabled = true;
                Program.mainFormInstance.Button3.Enabled = true;
                Program.mainFormInstance.Button4.Enabled = true;
                Program.mainFormInstance.Button5.Enabled = true;
                Program.mainFormInstance.Button6.Enabled = true;

                try
                {
                    conn.ConnectionString = connstring;
                    conn.Open();

                    MySqlCommand comm = new MySqlCommand();
                    string query = "INSERT INTO logstbl(username,process,description,dateandtime) VALUES('" + username + "','Login','Logged In',NOW())";

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
            }
        }
    }
}
