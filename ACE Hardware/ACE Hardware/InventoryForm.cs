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
    public partial class InventoryForm : Form
    {

        private MySqlConnection conn = new MySqlConnection();
        private string connstring = Program.connstring;
        private bool newclicked;
        private bool editclicked;

        public InventoryForm()
        {
            InitializeComponent();
        }

        private void InventoryForm_Load(object sender, EventArgs e)
        {
            try
            {
                conn.ConnectionString = connstring;
                conn.Open();

                MySqlCommand comm = new MySqlCommand();
                string query = "SELECT * FROM producttbl LEFT JOIN productcategorytbl ON producttbl.productcategoryid = productcategorytbl.productcategoryid";
                MySqlDataReader reader;

                comm.CommandText = query;
                comm.Connection = conn;
                reader = comm.ExecuteReader();

                while (reader.Read())
                    DataGridView1.Rows.Add(reader["productid"].ToString(), reader["productname"].ToString(), reader["productquantity"].ToString(), reader["productcategoryname"].ToString(), reader["productprice"].ToString());
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
                string query = "SELECT * FROM productcategorytbl ORDER BY productcategoryname";
                MySqlDataReader reader;

                comm.CommandText = query;
                comm.Connection = conn;
                reader = comm.ExecuteReader();

                ComboBox1.Items.Add("All");
                while (reader.Read())
                    ComboBox1.Items.Add(reader["productcategoryname"].ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                conn.Close();
            }
            ComboBox1.SelectedIndex = 0;
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            searchitem(TextBox1.Text, ComboBox1.Text);
        }

        public void searchitem(string productname, string productcategory)
        {
            try
            {
                conn.ConnectionString = connstring;
                conn.Open();

                MySqlCommand comm = new MySqlCommand();
                string query;
                if (productcategory.Equals("All"))
                    query = "SELECT * FROM producttbl LEFT JOIN productcategorytbl ON producttbl.productcategoryid = productcategorytbl.productcategoryid WHERE producttbl.productname LIKE '%" + productname + "%'";
                else
                    query = "SELECT * FROM producttbl LEFT JOIN productcategorytbl ON producttbl.productcategoryid = productcategorytbl.productcategoryid WHERE producttbl.productname LIKE '%" + productname + "%' AND productcategorytbl.productcategoryname = '" + productcategory + "'";
                MySqlDataReader reader;

                comm.CommandText = query;
                comm.Connection = conn;
                reader = comm.ExecuteReader();

                DataGridView1.Rows.Clear();
                while (reader.Read())
                    DataGridView1.Rows.Add(reader["productid"].ToString(), reader["productname"].ToString(), reader["productquantity"].ToString(), reader["productcategoryname"].ToString(), reader["productprice"].ToString());
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

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            searchitem(TextBox1.Text, ComboBox1.Text);
        }


        public void loadcategory()
        {
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

                ComboBox2.Items.Clear();

                while (reader.Read())
                    ComboBox2.Items.Add(reader["productcategoryname"].ToString());
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

        private void DataGridView1_Click(object sender, EventArgs e)
        {
            string category = "";
            try
            {
                string idselected = DataGridView1.CurrentRow.Cells[0].Value.ToString();

                conn.ConnectionString = connstring;
                conn.Open();

                MySqlCommand comm = new MySqlCommand();
                string query = "SELECT * FROM producttbl LEFT JOIN productcategorytbl ON producttbl.productcategoryid = productcategorytbl.productcategoryid WHERE productid = '" + idselected + "'";
                MySqlDataReader reader;

                comm.CommandText = query;
                comm.Connection = conn;
                reader = comm.ExecuteReader();

                while (reader.Read())
                {
                    Label8.Text = reader["productid"].ToString();
                    TextBox2.Text = reader["productname"].ToString();
                    TextBox3.Text = reader["productquantity"].ToString();
                    TextBox4.Text = reader["productprice"].ToString();
                    category = reader["productcategoryname"].ToString();
                }
            }
            catch (Exception ex)
            {

            }

            finally
            {
                conn.Close();
            }
            loadcategory();
            if (!(category == ""))
                ComboBox2.SelectedItem = category;
            else
            {
                MessageBox.Show("Please select product");
                ComboBox2.SelectedIndex = 0;
            }
            Button4.Enabled = true;
            Button5.Enabled = true;
            Button6.Enabled = true;
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            Program.inventoryAddQuantityFormInstance = new InventoryAddQuantityForm();
            Program.inventoryAddQuantityFormInstance.ShowDialog();
            Program.inventoryAddQuantityFormInstance.TextBox1.Text = "";
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            switch (MessageBox.Show("Are you sure you want to delete this product(" + TextBox2.Text + ")?","Confirm",MessageBoxButtons.YesNo))
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
                    deleteproduct(Label8.Text);
                    break;
                case DialogResult.No:
                    break;
                default:
                    break;
            }
        }

        public void deleteproduct(object id)
        {
            try
            {
                conn.ConnectionString = connstring;
                conn.Open();

                MySqlCommand comm = new MySqlCommand();
                string query = "INSERT INTO logstbl(username,process,description,dateandtime) VALUES('" + Program.login.username + "','Inventory - Delete Product','Delete product (" + TextBox2.Text + ")',NOW())";

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
            try
            {
                conn.ConnectionString = connstring;
                conn.Open();

                MySqlCommand comm = new MySqlCommand();
                string query = "DELETE FROM producttbl WHERE productid = '" + id + "'";

                comm.CommandText = query;
                comm.Connection = conn;
                comm.ExecuteNonQuery();

                MessageBox.Show("Deleted Successfully");

                Label8.Text = "Please select product";
                TextBox2.Text = "";
                TextBox3.Text = "";
                TextBox4.Text = "";
                ComboBox2.Items.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                finally
                {
                    conn.Close();
                    searchitem(TextBox1.Text, ComboBox1.Text);
                }
                Button4.Enabled = false;
                Button5.Enabled = false;
                Button6.Enabled = false;
            }

        public void iteminfo(string id)
        {
            string category = "";
            try
            {
                string idselected = id;

                conn.ConnectionString = connstring;
                conn.Open();

                MySqlCommand comm = new MySqlCommand();
                string query = "SELECT * FROM producttbl LEFT JOIN productcategorytbl ON producttbl.productcategoryid = productcategorytbl.productcategoryid WHERE productid = '" + idselected + "'";
                MySqlDataReader reader;

                comm.CommandText = query;
                comm.Connection = conn;
                reader = comm.ExecuteReader();

                while (reader.Read())
                {
                    Label8.Text = reader["productid"].ToString();
                    TextBox2.Text = reader["productname"].ToString();
                    TextBox3.Text = reader["productquantity"].ToString();
                    TextBox4.Text = reader["productprice"].ToString();
                    category = reader["productcategoryname"].ToString();
                }
            }
            catch (Exception ex)
            {
            }

            finally
            {
                conn.Close();
            }
            loadcategory();
            if (!(category == ""))
                ComboBox2.SelectedItem = category;
            else
            {
                MessageBox.Show("Please select product");
                ComboBox2.SelectedIndex = 0;
            }
            Button4.Enabled = true;
            Button5.Enabled = true;
            Button6.Enabled = true;
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            Button1.Enabled = true;
            Button2.Enabled = true;
            Button3.Enabled = false;
            Button4.Enabled = false;
            Button5.Enabled = false;
            Button6.Enabled = false;
            DataGridView1.Enabled = false;
            ComboBox2.Enabled = true;
            TextBox2.Enabled = true;
            TextBox3.Enabled = true;
            TextBox4.Enabled = true;

            Label8.Text = "To be generated";
            TextBox2.Text = "";
            TextBox3.Text = "";
            TextBox4.Text = "";


            loadcategory();

            newclicked = true;
            editclicked = false;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Button1.Enabled = false;
            Button2.Enabled = false;
            Button3.Enabled = true;
            Button4.Enabled = true;
            Button5.Enabled = true;
            Button6.Enabled = true;
            DataGridView1.Enabled = true;
            ComboBox2.Enabled = false;
            TextBox2.Enabled = false;
            TextBox3.Enabled = false;
            TextBox4.Enabled = false;

            if (newclicked)
            {
                Label8.Text = "Please select product";
                Button6.Enabled = false;
                Button4.Enabled = false;
                Button5.Enabled = false;
                ComboBox2.Items.Clear();
            }
            else if (editclicked)
            {
            }
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            Button1.Enabled = true;
            Button2.Enabled = true;
            Button3.Enabled = false;
            Button4.Enabled = false;
            Button5.Enabled = false;
            Button6.Enabled = false;
            DataGridView1.Enabled = false;
            ComboBox2.Enabled = true;
            TextBox2.Enabled = true;
            TextBox3.Enabled = true;
            TextBox4.Enabled = true;

            newclicked = false;
            editclicked = true;
        }



















        private void Button1_Click(object sender, EventArgs e)
        {
            if (TextBox2.Text == "")
            {
                MessageBox.Show("Please enter product name");
                return;
            }
            try
            {
                double dummy = System.Convert.ToDouble(TextBox3.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please use only numbers on quantity");
                return;
            }
            try
            {
                double dummy = System.Convert.ToDouble(TextBox4.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please use only numbers on price");
                return;
            }
            if (ComboBox2.Text == "")
            {
                MessageBox.Show("Please select category");
                return;
            }

            if (newclicked)
            {
                bool nameexists = false;
                try
                {
                    conn.ConnectionString = connstring;
                    conn.Open();

                    MySqlCommand comm = new MySqlCommand();
                    string query = "SELECT * FROM producttbl";
                    MySqlDataReader reader;

                    comm.CommandText = query;
                    comm.Connection = conn;
                    reader = comm.ExecuteReader();

                    while (reader.Read())
                    {
                        if (reader["productname"].ToString().Equals(TextBox2.Text))
                        {
                            nameexists = true;
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
                if (nameexists)
                {
                    MessageBox.Show("Product name already exists");
                    return;
                }

                int categoryindex=0;
                try
                {
                    conn.ConnectionString = connstring;
                    conn.Open();

                    MySqlCommand comm = new MySqlCommand();
                    string query = "SELECT * FROM productcategorytbl WHERE productcategoryname = '" + ComboBox2.Text + "'";
                    MySqlDataReader reader;
                    comm.Connection = conn;
                    comm.CommandText = query;
                    reader = comm.ExecuteReader();

                    while (reader.Read())
                    {
                        categoryindex = System.Convert.ToInt32(reader["productcategoryid"].ToString());
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
                try
                {
                    conn.ConnectionString = connstring;
                    conn.Open();

                    MySqlCommand comm = new MySqlCommand();
                    string query = "INSERT INTO producttbl(productname,productcategoryid,productquantity,productprice) VALUES ('" + TextBox2.Text + "'," + categoryindex + "," + TextBox3.Text + "," + TextBox4.Text + ")";

                    comm.CommandText = query;
                    comm.Connection = conn;
                    comm.ExecuteNonQuery();

                    MessageBox.Show("Saved");
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
                    string query = "INSERT INTO logstbl(username,process,description,dateandtime) VALUES('" + Program.login.username + "','Inventory - New Product','Added new product (" + TextBox2.Text + ")',NOW())";

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
                Button4.Enabled = true;
                Button5.Enabled = true;
                Button6.Enabled = true;
                DataGridView1.Enabled = true;
                ComboBox2.Enabled = false;
                TextBox2.Enabled = false;
                TextBox3.Enabled = false;
                TextBox4.Enabled = false;

                Label8.Text = "Please select product";
                Button6.Enabled = false;
                Button4.Enabled = false;
                Button5.Enabled = false;
                TextBox2.Text = "";
                TextBox3.Text = "";
                TextBox4.Text = "";
                ComboBox2.Items.Clear();

                searchitem(TextBox1.Text, ComboBox1.Text);
            }
            else if (editclicked)
            {
                int categoryindex=0;
                try
                {
                    conn.ConnectionString = connstring;
                    conn.Open();

                    MySqlCommand comm = new MySqlCommand();
                    string query = "SELECT * FROM productcategorytbl WHERE productcategoryname = '" + ComboBox2.Text + "'";
                    MySqlDataReader reader;
                    comm.Connection = conn;
                    comm.CommandText = query;
                    reader = comm.ExecuteReader();

                    while (reader.Read())
                    {
                        categoryindex = System.Convert.ToInt32(reader["productcategoryid"].ToString());
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
                try
                {
                    conn.ConnectionString = connstring;
                    conn.Open();

                    MySqlCommand comm = new MySqlCommand();
                    // Dim query As String = "INSERT INTO producttbl(productname,productcategoryid,productquantity,productprice) VALUES ('" & TextBox2.Text & "'," & categoryindex & "," & TextBox3.Text & "," & TextBox4.Text & ")"
                    string query = "UPDATE producttbl SET productname = '" + TextBox2.Text + "', productcategoryid = " + categoryindex + ", productquantity = " + TextBox3.Text + ", productprice = " + TextBox4.Text + " WHERE productid = " + Label8.Text;

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
                    string query = "INSERT INTO logstbl(username,process,description,dateandtime) VALUES('" + Program.login.username + "','Inventory - Edit Product','Edit Product (" + TextBox2.Text + ")',NOW())";

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
                Button4.Enabled = true;
                Button5.Enabled = true;
                Button6.Enabled = true;
                DataGridView1.Enabled = true;
                ComboBox2.Enabled = false;
                TextBox2.Enabled = false;
                TextBox3.Enabled = false;
                TextBox4.Enabled = false;

                Label8.Text = "Please select product";
                Button6.Enabled = false;
                Button4.Enabled = false;
                Button5.Enabled = false;
                TextBox2.Text = "";
                TextBox3.Text = "";
                TextBox4.Text = "";
                ComboBox2.Items.Clear();

                searchitem(TextBox1.Text, ComboBox1.Text);
            }
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            Program.mainFormInstance.Show();
            this.Close();
        }

        private void InventoryForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.mainFormInstance.Show();
        }

        private void Button8_Click(object sender, EventArgs e)
        {
            //InventoryEditCategoryForm.ShowDialog();
            Program.inventoryEditCategoryFormInstance = new InventoryEditCategoryForm();
            Program.inventoryEditCategoryFormInstance.ShowDialog();
        }


        public void refreshcategoryanddatagrid()
        {
            ComboBox1.Items.Clear();
            DataGridView1.Rows.Clear();

            try
            {
                conn.ConnectionString = connstring;
                conn.Open();

                MySqlCommand comm = new MySqlCommand();
                string query = "SELECT * FROM producttbl LEFT JOIN productcategorytbl ON producttbl.productcategoryid = productcategorytbl.productcategoryid";
                MySqlDataReader reader;

                comm.CommandText = query;
                comm.Connection = conn;
                reader = comm.ExecuteReader();

                while (reader.Read())
                    DataGridView1.Rows.Add(reader["productid"].ToString(), reader["productname"].ToString(), reader["productquantity"].ToString(), reader["productcategoryname"].ToString(), reader["productprice"].ToString());
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
                string query = "SELECT * FROM productcategorytbl ORDER BY productcategoryname";
                MySqlDataReader reader;

                comm.CommandText = query;
                comm.Connection = conn;
                reader = comm.ExecuteReader();

                ComboBox1.Items.Add("All");
                while (reader.Read())
                    ComboBox1.Items.Add(reader["productcategoryname"].ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                conn.Close();
            }
            ComboBox1.SelectedIndex = 0;
        }

    }
}
