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
    public partial class AdminForm : Form
    {

        private MySqlConnection conn = new MySqlConnection();
        private string connstring = Program.connstring;
        private bool addclicked = false;
        private bool editclicked = false;

        public AdminForm()
        {
            InitializeComponent();
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {
            try
            {
                conn.ConnectionString = connstring;
                conn.Open();

                MySqlCommand comm = new MySqlCommand();
                string query = "SELECT * FROM usertbl";
                MySqlDataReader reader;

                comm.Connection = conn;
                comm.CommandText = query;
                reader = comm.ExecuteReader();

                while (reader.Read())
                    DataGridView1.Rows.Add(reader["id"].ToString(), reader["name"].ToString(), reader["usertype"].ToString(), reader["username"].ToString(), reader["userpassword"].ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                conn.Close();
            }
            Button1.Enabled = false;
            Button2.Enabled = false;
            Button4.Enabled = false;
            Button5.Enabled = false;
            TextBox1.Enabled = false;
            TextBox2.Enabled = false;
            TextBox3.Enabled = false;
            ComboBox1.Enabled = false;
        }



        public void searchuser(string searchstring, bool administrator, bool employee)
        {
            try
            {
                conn.ConnectionString = connstring;
                conn.Open();

                string query;
                MySqlCommand comm = new MySqlCommand();
                if (administrator & employee)
                    query = "SELECT * FROM usertbl WHERE name LIKE '%" + searchstring + "%'";
                else if (administrator & !employee)
                    query = "SELECT * FROM usertbl WHERE name LIKE '%" + searchstring + "%' AND usertype = 'Administrator'";
                else if (!administrator & employee)
                    query = "SELECT * FROM usertbl WHERE name LIKE '%" + searchstring + "%' AND usertype = 'Employee'";
                else
                    query = "SELECT * FROM usertbl WHERE name LIKE '%" + searchstring + "%'";

                MySqlDataReader reader;

                comm.Connection = conn;
                comm.CommandText = query;
                reader = comm.ExecuteReader();

                DataGridView1.Rows.Clear();

                while (reader.Read())
                    DataGridView1.Rows.Add(reader["id"].ToString(), reader["name"].ToString(), reader["usertype"].ToString(), reader["username"].ToString(), reader["userpassword"].ToString());
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

        private void TextBox4_TextChanged(object sender, EventArgs e)
        {
            searchuser(TextBox4.Text, CheckBox1.Checked, CheckBox2.Checked);
        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (!CheckBox2.Checked)
                CheckBox1.Checked = true;
            searchuser(TextBox4.Text, CheckBox1.Checked, CheckBox2.Checked);
        }

        private void CheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (!CheckBox1.Checked)
                CheckBox2.Checked = true;
            searchuser(TextBox4.Text, CheckBox1.Checked, CheckBox2.Checked);
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void DataGridView1_Click(object sender, EventArgs e)
        {
            string id;
            try
            {
                id = DataGridView1.CurrentRow.Cells[0].Value.ToString();
            }
            catch (Exception ex)
            {
                Button1.Enabled = false;
                Button2.Enabled = false;
                Button4.Enabled = false;
                Button5.Enabled = false;
                TextBox1.Enabled = false;
                TextBox2.Enabled = false;
                TextBox3.Enabled = false;
                ComboBox1.Enabled = false;

                Label7.Text = "";
                TextBox1.Text = "";
                ComboBox1.Items.Clear();
                TextBox2.Text = "";
                TextBox3.Text = "";
                Label7.Text = "Please select a user";
                return;
            }

            try
            {
                conn.ConnectionString = connstring;
                conn.Open();

                MySqlCommand comm = new MySqlCommand();
                string query = "SELECT * FROM usertbl WHERE id=" + id;
                MySqlDataReader reader;

                comm.CommandText = query;
                comm.Connection = conn;
                reader = comm.ExecuteReader();

                while (reader.Read())
                {
                    Label7.Text = reader["id"].ToString();
                    TextBox1.Text = reader["name"].ToString();

                    ComboBox1.Items.Clear();
                    ComboBox1.Items.Add("Administrator");
                    ComboBox1.Items.Add("Employee");
                    if (reader["usertype"].ToString() == "Administrator")
                        ComboBox1.SelectedIndex = 0;
                    else if (reader["usertype"].ToString() == "Employee")
                        ComboBox1.SelectedIndex = 1;
                    else
                        ComboBox1.SelectedIndex = 0;

                    TextBox2.Text = reader["username"].ToString();
                    TextBox3.Text = reader["userpassword"].ToString();
                }

                Button4.Enabled = true;
                Button5.Enabled = true;
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

        private void Button3_Click(object sender, EventArgs e)
        {
            addclicked = true;
            editclicked = false;
            Label7.Text = "To be generated";
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";
            TextBox1.Enabled = true;
            TextBox2.Enabled = true;
            TextBox3.Enabled = true;
            ComboBox1.Enabled = true;
            ComboBox1.Items.Clear();
            ComboBox1.Items.Add("Administrator");
            ComboBox1.Items.Add("Employee");
            DataGridView1.Enabled = false;
            Button1.Enabled = true;
            Button2.Enabled = true;
            Button3.Enabled = false;
            Button4.Enabled = false;
            Button5.Enabled = false;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (addclicked)
            {
                Label7.Text = "Please select a user";
                TextBox1.Text = "";
                TextBox2.Text = "";
                TextBox3.Text = "";
                TextBox1.Enabled = false;
                TextBox2.Enabled = false;
                TextBox3.Enabled = false;
                ComboBox1.Enabled = false;
                ComboBox1.Items.Clear();
                DataGridView1.Enabled = true;
                Button1.Enabled = false;
                Button2.Enabled = false;
                Button3.Enabled = true;
                Button4.Enabled = false;
                Button5.Enabled = false;
            }
            else if (editclicked)
            {
                Button3.Enabled = true;
                Button4.Enabled = true;
                Button5.Enabled = true;
                Button1.Enabled = false;
                Button2.Enabled = false;
                TextBox1.Enabled = false;
                TextBox2.Enabled = false;
                TextBox3.Enabled = false;
                ComboBox1.Enabled = false;
                DataGridView1.Enabled = true;
            }
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            editclicked = true;
            addclicked = false;
            TextBox1.Enabled = true;
            TextBox2.Enabled = true;
            TextBox3.Enabled = true;
            ComboBox1.Enabled = true;
            Button3.Enabled = false;
            Button4.Enabled = false;
            Button5.Enabled = false;
            Button1.Enabled = true;
            Button2.Enabled = true;
            DataGridView1.Enabled = false;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (TextBox1.Text == "")
            {
                MessageBox.Show("Please input name");
                return;
            }
            if (TextBox2.Text == "")
            {
                MessageBox.Show("Please input username");
                return;
            }
            if (TextBox3.Text == "")
            {
                MessageBox.Show("Please input password");
                return;
            }
            if (ComboBox1.Text == "")
            {
                MessageBox.Show("Please choose type");
                return;
            }
            bool usernamealreadyexisted = false;
            try
            {
                conn.ConnectionString = connstring;
                conn.Open();

                MySqlCommand comm = new MySqlCommand();
                string query = "SELECT * FROM usertbl";
                MySqlDataReader reader;

                comm.Connection = conn;
                comm.CommandText = query;
                reader = comm.ExecuteReader();

                while (reader.Read())
                {
                    if (reader["username"] == TextBox2.Text)
                    {
                        usernamealreadyexisted = true;
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                conn.Close();
            }

            if (usernamealreadyexisted)
            {
                MessageBox.Show("Username already in use");
                return;
            }

            if (addclicked)
            {
                try
                {
                    conn.ConnectionString = connstring;
                    conn.Open();

                    MySqlCommand comm = new MySqlCommand();
                    string query = "INSERT INTO usertbl(username,userpassword,usertype,name) VALUES('" + TextBox2.Text + "','" + TextBox3.Text + "','" + ComboBox1.Text + "','" + TextBox1.Text + "')";

                    comm.Connection = conn;
                    comm.CommandText = query;
                    comm.ExecuteNonQuery();

                    MessageBox.Show("Added Successfully");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    return;
                }
                finally
                {
                    conn.Close();
                }

                try
                {
                    conn.ConnectionString = connstring;
                    conn.Open();

                    MySqlCommand comm = new MySqlCommand();
                    string query = "INSERT INTO logstbl(username,process,description,dateandtime) VALUES('" + Program.login.username + "','Admin - New Account','New account added (username is " + TextBox2.Text + ")',NOW())";

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

                Label7.Text = "Please select a user";
                TextBox1.Text = "";
                TextBox2.Text = "";
                TextBox3.Text = "";
                ComboBox1.Items.Clear();

                TextBox1.Enabled = false;
                TextBox2.Enabled = false;
                TextBox3.Enabled = false;
                ComboBox1.Items.Clear();

                Button3.Enabled = true;
                Button1.Enabled = false;
                Button2.Enabled = false;
                Button4.Enabled = false;
                Button5.Enabled = false;
                ComboBox1.Enabled = false;

                DataGridView1.Enabled = true;

                searchuser(TextBox4.Text, CheckBox1.Checked, CheckBox2.Checked);
            }
            else if (editclicked)
            {
                try
                {
                    conn.ConnectionString = connstring;
                    conn.Open();

                    MySqlCommand comm = new MySqlCommand();
                    string query = "UPDATE usertbl SET username='" + TextBox2.Text + "', userpassword='" + TextBox3.Text + "', usertype='" + ComboBox1.Text + "', name='" + TextBox1.Text + "' WHERE id=" + Label7.Text;
                    comm.CommandText = query;
                    comm.Connection = conn;
                    comm.ExecuteNonQuery();

                    MessageBox.Show("Updated successfully");
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                finally
                {
                    conn.Close();
                }

                try
                {
                    conn.ConnectionString = connstring;
                    conn.Open();

                    MySqlCommand comm = new MySqlCommand();
                    string query = "INSERT INTO logstbl(username,process,description,dateandtime) VALUES('" + Program.login.username + "','Admin - Edit Account','Account edited (username is " + TextBox2.Text + ")',NOW())";

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

                Button1.Enabled = false;
                Button2.Enabled = false;
                Button3.Enabled = true;
                Button4.Enabled = false;
                Button5.Enabled = false;

                DataGridView1.Enabled = true;

                searchuser(TextBox4.Text, CheckBox1.Checked, CheckBox2.Checked);
            }
        }

        private void Button5_Click(object sender, EventArgs e)
        {
        

            switch (MessageBox.Show("Are you sure you want to delete this user?","Confirm",MessageBoxButtons.YesNo))
            {
                case DialogResult.None:
                    break;
                case DialogResult.OK:
                    break;
                case DialogResult.Cancel:
                    break;
                case DialogResult.Abort:
                    break;
                case DialogResult.Retry:
                    break;
                case DialogResult.Ignore:
                    break;
                case DialogResult.Yes:
                    deleteuser(Label7.Text);
                    break;
                case DialogResult.No:
                    break;
                default:
                    break;
            }
        }


        public void deleteuser(string id)
        {
            try
            {
                conn.ConnectionString = connstring;
                conn.Open();

                MySqlCommand comm = new MySqlCommand();
                string query = "DELETE FROM usertbl WHERE id=" + id;
                comm.CommandText = query;
                comm.Connection = conn;
                comm.ExecuteNonQuery();

                MessageBox.Show("Deleted successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return;
            }
            finally
            {
                conn.Close();
            }

            try
            {
                conn.ConnectionString = connstring;
                conn.Open();

                MySqlCommand comm = new MySqlCommand();
                string query = "INSERT INTO logstbl(username,process,description,dateandtime) VALUES('" + Program.login.username + "','Admin - Delete Account','Deleted account (" + TextBox2.Text + ")',NOW())";

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

            Label7.Text = "Please select a user";
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";
            ComboBox1.Items.Clear();
            TextBox1.Enabled = false;
            TextBox2.Enabled = false;
            TextBox3.Enabled = false;
            ComboBox1.Enabled = false;

            Button1.Enabled = false;
            Button2.Enabled = false;
            Button3.Enabled = true;
            Button4.Enabled = false;
            Button5.Enabled = false;

            DataGridView1.Enabled = true;

            searchuser(TextBox4.Text, CheckBox1.Checked, CheckBox2.Checked);
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            Program.mainFormInstance.Show();
            this.Close();
        }

        private void AdminForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.mainFormInstance.Show();
        }
    }
}
