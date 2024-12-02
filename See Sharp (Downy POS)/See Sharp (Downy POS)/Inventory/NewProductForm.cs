using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace See_Sharp__Downy_POS_.Inventory
{
    public partial class NewProductForm : Form
    {

        SqlConnection conn = new SqlConnection();
        String connstring = "Data Source=MACDO;Initial Catalog=downyDb;Integrated Security=True";

        public NewProductForm()
        {
            InitializeComponent();
        }

        public void formLoad()
        {
            try
            {
                conn.ConnectionString = connstring;
                conn.Open();
                SqlCommand comm = new SqlCommand();
                comm.Connection = conn;
                comm.CommandText = "SELECT * FROM productCategoryTbl";
                SqlDataReader reader;
                reader = comm.ExecuteReader();

                cboCategory.Items.Clear();

                while (reader.Read())
                {
                    cboCategory.Items.Add(reader["productCategoryName"].ToString());
                }
                cboCategory.Items.Add("Add New");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "An Error has occured! Please contact the programmer", MessageBoxButtons.OK);
            }
            finally
            {
                conn.Close();
                cboCategory.SelectedIndex = 0;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cboCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cboCategory.Text.Equals("Add New"))
            {
                txtNewCategory.Enabled = true;
                txtNewCategory.Visible = true;
            }
            else
            {
                txtNewCategory.Enabled = false;
                txtNewCategory.Visible = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int stock;
            double price;
           
            if (alreadyExist(txtName.Text))
            {
                MessageBox.Show("The name you have entered is not unique", "Name is not unique", MessageBoxButtons.OK);
                return;
            }
            if (!double.TryParse(txtPrice.Text, out price))
            {
                MessageBox.Show("Please check your input in price", "Possible wrong input", MessageBoxButtons.OK);
                return;
            }
            if (!int.TryParse(txtStock.Text, out stock))
            {
                MessageBox.Show("Please check your input in stock", "Possible wrong input", MessageBoxButtons.OK);
                return;
            }
            if (price < 1)
            {
                MessageBox.Show("Price cannot be a negative number or zero", "Invalid Price", MessageBoxButtons.OK);
                return;
            }
            if (stock < 0)
            {
                MessageBox.Show("Stock cannot be a negative number", "Invalid Stock", MessageBoxButtons.OK);
                return;
            }

            int categoryID = 0;

            if (cboCategory.Text.Equals("Add New"))
            {
                if (cboCategory.Items.Contains(txtNewCategory.Text))
                {
                    MessageBox.Show("Duplicate Category Detected", "Oh No!", MessageBoxButtons.OK);
                    return;
                }
                else
                {
                    addNewCategory(txtNewCategory.Text);
                    categoryID = getCategoryID(txtNewCategory.Text);
                }
            }
            else
            {
                categoryID = getCategoryID(cboCategory.Text);
            }
            
            try
            {
                conn.ConnectionString = connstring;
                conn.Open();
                SqlCommand comm = new SqlCommand();
                comm.Connection = conn;
                comm.CommandText = "INSERT INTO productTbl (productName, productPrice, productCategoryID, productStock) VALUES ('" + txtName.Text + "'," + txtPrice.Text + "," + categoryID + "," + txtStock.Text +")";
                comm.ExecuteNonQuery();
                MessageBox.Show("Product added", "Yey!", MessageBoxButtons.OK);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "An Error has occured! Please contact the programmer", MessageBoxButtons.OK);
            }
            finally
            {
                conn.Close();
            }
            LoginForm.main.inventoryRefresh();
        }

        public Boolean alreadyExist(String productName)
        {
            int counter = 0;
            try
            {
                conn.ConnectionString = connstring;
                conn.Open();
                SqlCommand comm = new SqlCommand();
                comm.Connection = conn;
                comm.CommandText = "SELECT * FROM productTbl WHERE productName = '" + productName + "'";
                SqlDataReader reader;
                reader = comm.ExecuteReader();

                while (reader.Read())
                {
                    counter += 1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "An Error has occured! Please contact the programmer", MessageBoxButtons.OK);
            }
            finally
            {
                conn.Close();
            }
            if (counter > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void addNewCategory(String newCategory)
        {
            try
            {
                conn.ConnectionString = connstring;
                conn.Open();
                SqlCommand comm = new SqlCommand();
                comm.Connection = conn;
                comm.CommandText = "INSERT INTO productCategoryTbl(productCategoryName) VALUES ('" + newCategory + "')";
                comm.ExecuteNonQuery();
                //MessageBox.Show("Product added", "Yey!", MessageBoxButtons.OK);
                //this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "An Error has occured! Please contact the programmer", MessageBoxButtons.OK);
            }
            finally
            {
                conn.Close();
            }
        }

        public int getCategoryID(String categoryName)
        {
            int categoryID = 0;
            try
            {
                conn.ConnectionString = connstring;
                conn.Open();
                SqlCommand comm = new SqlCommand();
                comm.Connection = conn;
                comm.CommandText = "SELECT * FROM productCategoryTbl WHERE productCategoryName = '" + categoryName + "'";
                SqlDataReader reader;
                reader = comm.ExecuteReader();

                while (reader.Read())
                {
                    categoryID = int.Parse(reader["productCategoryID"].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "An Error has occured! Please contact the programmer", MessageBoxButtons.OK);
            }
            finally
            {
                conn.Close();
            }
            return categoryID;
        }

    }
}
