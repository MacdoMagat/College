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
    public partial class InventoryEditCategoryEditForm : Form
    {

        private MySqlConnection conn = new MySqlConnection();
        private string connstring = Program.connstring;
        private string category;

        public InventoryEditCategoryEditForm()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (TextBox1.Text == "")
            {
                MessageBox.Show("New name must not be blank");
                return;
            }
            if (Program.inventoryEditCategoryFormInstance.ListBox1.Items.Contains(this.TextBox1.Text))
            {
                MessageBox.Show("Category already exists");
                return;
            }
            int categoryindex = 0;
            try
            {
                conn.ConnectionString = connstring;
                conn.Open();

                MySqlCommand comm = new MySqlCommand();
                string query = "SELECT * FROM productcategorytbl WHERE productcategoryname = '" + category + "'";
                MySqlDataReader reader;
                comm.Connection = conn;
                comm.CommandText = query;
                reader = comm.ExecuteReader();

                while (reader.Read())
                    categoryindex = System.Convert.ToInt32(reader["productcategoryid"].ToString());
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
                string query = "UPDATE productcategorytbl SET productcategoryname = '" + TextBox1.Text + "' WHERE productcategoryid = " + categoryindex;

                comm.CommandText = query;
                comm.Connection = conn;
                comm.ExecuteNonQuery();

                MessageBox.Show("Updated");
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
                string query = "INSERT INTO logstbl(username,process,description,dateandtime) VALUES('" + Program.login.username + "','Inventory - Edit Category','Edited category (" + category + ")',NOW())";

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


            this.Close();
            Program.inventoryEditCategoryFormInstance.refreshcategory();
        }

        private void InventoryEditCategoryEditForm_Load(object sender, EventArgs e)
        {
            category = Program.inventoryEditCategoryFormInstance.ListBox1.SelectedItem.ToString();
            Label4.Text = category;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
