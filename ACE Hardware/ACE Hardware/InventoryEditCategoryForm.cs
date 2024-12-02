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
    public partial class InventoryEditCategoryForm : Form
    {

        private MySqlConnection conn = new MySqlConnection();
        private string connstring = Program.connstring;

        public InventoryEditCategoryForm()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Program.inventoryEditCategoryAddFormInstance = new InventoryEditCategoryAddForm();
            Program.inventoryEditCategoryAddFormInstance.TextBox1.Text = "";
            Program.inventoryEditCategoryAddFormInstance.ShowDialog();
        }

        private void InventoryEditCategoryForm_Load(object sender, EventArgs e)
        {
            refreshcategory();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            string category;
            try
            {
                category = ListBox1.SelectedItem.ToString();

                switch (MessageBox.Show("Are you sure you want to delete this category(" + category + ")?\nDeleting categories will delete products included in the category","Confirm",MessageBoxButtons.YesNo))
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
                        deletecategory(category);
                        break;
                    case DialogResult.No:
                        break;
                    default:
                        break;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Please select category to delete");
            }
        }



        public void refreshcategory()
        {
            ListBox1.Items.Clear();
            Button2.Enabled = false;
            Button3.Enabled = false;

            try
            {
                conn.ConnectionString = connstring;
                conn.Open();

                MySqlCommand comm = new MySqlCommand();
                string query = "SELECT * FROM productcategorytbl ORDER BY productcategoryname";
                MySqlDataReader reader;

                comm.CommandText = query;
                comm.Connection = conn;
                reader = comm.ExecuteReader();


                while (reader.Read())
                    ListBox1.Items.Add(reader["productcategoryname"].ToString());
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

        private void InventoryEditCategoryForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.inventoryFormInstance.refreshcategoryanddatagrid();
            Program.inventoryFormInstance.loadcategory();
        }

        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Button2.Enabled = true;
            Button3.Enabled = true;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Program.inventoryEditCategoryEditFormInstance = new InventoryEditCategoryEditForm();
            Program.inventoryEditCategoryEditFormInstance.TextBox1.Text = "";
            Program.inventoryEditCategoryEditFormInstance.ShowDialog();
        }


        private void deletecategory(string category)
        {
            int categoryindex=0;
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
                string query = "DELETE FROM productcategorytbl WHERE productcategoryid = " + categoryindex;

                comm.CommandText = query;
                comm.Connection = conn;
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

            try
            {
                conn.ConnectionString = connstring;
                conn.Open();

                MySqlCommand comm = new MySqlCommand();
                string query = "DELETE FROM producttbl WHERE productcategoryid = " + categoryindex;

                comm.CommandText = query;
                comm.Connection = conn;
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

            try
            {
                conn.ConnectionString = connstring;
                conn.Open();

                MySqlCommand comm = new MySqlCommand();
                string query = "INSERT INTO logstbl(username,process,description,dateandtime) VALUES('" + Program.login.username + "','Inventory - Delete Category','Deleted category (" + category + ")',NOW())";

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

            MessageBox.Show("Deleted Successfully");
            refreshcategory();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
