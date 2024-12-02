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
    public partial class MainForm : Form
    {

        private MySqlConnection conn = new MySqlConnection();
        private string connstring = Program.connstring;

        public MainForm()
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
                string query = "INSERT INTO logstbl(username,process,description,dateandtime) VALUES('" + Program.login.username + "','Open POS','Opened POS',NOW())";

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
            Program.posFormInstance = new POSForm();
            Program.posFormInstance.Show();
            this.Hide();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                conn.ConnectionString = connstring;
                conn.Open();

                MySqlCommand comm = new MySqlCommand();
                string query = "INSERT INTO logstbl(username,process,description,dateandtime) VALUES('" + Program.login.username + "','Open Inventory','Opened Inventory',NOW())";

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
            Program.inventoryFormInstance = new InventoryForm();
            Program.inventoryFormInstance.Show();
            this.Hide();
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            Program.exitFormInstance = new ExitForm();
            Program.exitFormInstance.ShowDialog();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
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

        private void Button5_Click(object sender, EventArgs e)
        {
            try
            {
                conn.ConnectionString = connstring;
                conn.Open();

                MySqlCommand comm = new MySqlCommand();
                string query = "INSERT INTO logstbl(username,process,description,dateandtime) VALUES('" + Program.login.username + "','Open Admin','Opened Admin',NOW())";

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
            Program.adminFormInstance = new AdminForm();
            Program.adminFormInstance.Show();
            this.Hide();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            try
            {
                conn.ConnectionString = connstring;
                conn.Open();

                MySqlCommand comm = new MySqlCommand();
                string query = "INSERT INTO logstbl(username,process,description,dateandtime) VALUES('" + Program.login.username + "','Open Reports','Opened Reports',NOW())";

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
            Program.reportsFormInstance = new ReportsForm();
            Program.reportsFormInstance.Show();
            this.Hide();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            try
            {
                conn.ConnectionString = connstring;
                conn.Open();

                MySqlCommand comm = new MySqlCommand();
                string query = "INSERT INTO logstbl(username,process,description,dateandtime) VALUES('" + Program.login.username + "','Open Logs','Opened Logs',NOW())";

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
            Program.logsFormInstance = new LogsForm();
            Program.logsFormInstance.Show();
            this.Hide();
        }
    }
}
