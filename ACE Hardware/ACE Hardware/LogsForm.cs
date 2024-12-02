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
    public partial class LogsForm : Form
    {

        private MySqlConnection conn = new MySqlConnection();
        private string connstring = Program.connstring;

        public LogsForm()
        {
            InitializeComponent();
        }

        private void LogsForm_Load(object sender, EventArgs e)
        {
            ComboBox1.SelectedIndex = 0;
            ComboBox2.SelectedIndex = 0;
            ComboBox3.SelectedIndex = 0;

            refreshdatagrid(ComboBox1.Text, TextBox1.Text, ComboBox2.Text, ComboBox3.Text);
        }


        public void refreshdatagrid(string searchfor, string searchword, string process, string time)
        {

                conn.ConnectionString = connstring;
                conn.Open();

                string query = "SELECT * FROM logstbl WHERE ";
                if (searchfor == "Username")
                    query = query + "username LIKE '%" + searchword + "%' ";
                else if (searchfor == "Description")
                    query = query + "description LIKE '%" + searchword + "%' ";
                else
                    query = query + "username LIKE '%" + searchword + "%' ";

                if (process == "All")
                    query = query;
                else
                    query = query + "AND process = '" + process + "' ";

                if (time == "Today")
                    query = query + "AND YEAR(dateandtime) = '" + DateTime.Now.ToString("yyyy") + "' AND MONTH(dateandtime) = '" + DateTime.Now.ToString("MM") + "' AND DAY(dateandtime) = '" + DateTime.Now.ToString("dd") + "' ORDER BY dateandtime DESC";
                else if (time == "This Month")
                    query = query + "AND YEAR(dateandtime) = '" + DateTime.Now.ToString("yyyy") + "' AND MONTH(dateandtime) = '" + DateTime.Now.ToString("MM") + "' ORDER BY dateandtime DESC";
                else if (time == "This Year")
                    query = query + "AND YEAR(dateandtime) = '" + DateTime.Now.ToString("yyyy") + "' ORDER BY dateandtime DESC";
                else if (time == "All")
                    query = query + " ORDER BY dateandtime DESC";
                else
                    query = query + " ORDER BY dateandtime DESC";

                MySqlCommand comm = new MySqlCommand();
                MySqlDataReader reader;

                comm.Connection = conn;
                comm.CommandText = query;
                reader = comm.ExecuteReader();

                DataGridView1.Rows.Clear();

                while (reader.Read())
                    DataGridView1.Rows.Add(reader["username"].ToString(), reader["process"].ToString(), reader["description"].ToString(), reader["dateandtime"].ToString());

                conn.Close();

        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            refreshdatagrid(ComboBox1.Text, TextBox1.Text, ComboBox2.Text, ComboBox3.Text);
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            refreshdatagrid(ComboBox1.Text, TextBox1.Text, ComboBox2.Text, ComboBox3.Text);
        }

        private void ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            refreshdatagrid(ComboBox1.Text, TextBox1.Text, ComboBox2.Text, ComboBox3.Text);
        }

        private void ComboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            refreshdatagrid(ComboBox1.Text, TextBox1.Text, ComboBox2.Text, ComboBox3.Text);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Program.mainFormInstance.Show();
            this.Close();
        }

        private void LogsForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.mainFormInstance.Show();
        }
    }
}
