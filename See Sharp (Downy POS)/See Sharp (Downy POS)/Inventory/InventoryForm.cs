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

namespace See_Sharp__Downy_POS_
{
    public partial class InventoryForm : Form
    {

        SqlConnection conn = new SqlConnection();
        String connstring = "Data Source=MACDO;Initial Catalog=downyDb;Integrated Security=True";
        int selectedID;
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

        public void refreshCboCategory()
        {
            cboCategory.Items.Clear();
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


        private void cboCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            categorySelected();
        }

        public void categorySelected()
        {
            txtName.Text = "";
            txtPrice.Text = "";
            txtStock.Text = "";
            try
            {
                conn.ConnectionString = connstring;
                conn.Open();
                SqlCommand comm = new SqlCommand();
                comm.Connection = conn;
                comm.CommandText = "SELECT * FROM productTbl LEFT JOIN productCategoryTbl ON productTbl.productCategoryID = productCategoryTbl.productCategoryID WHERE productCategoryName = '" + cboCategory.Text + "'";
                SqlDataReader reader;
                reader = comm.ExecuteReader();

                dtgProducts.Rows.Clear();

                while (reader.Read())
                {
                    dtgProducts.Rows.Add(reader["productName"].ToString(), reader["productPrice"].ToString(), reader["productStock"].ToString());
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
        }

        private void dtgProducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dtgProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                conn.ConnectionString = connstring;
                conn.Open();
                SqlCommand comm = new SqlCommand();
                comm.Connection = conn;
                comm.CommandText = "SELECT * FROM productTbl WHERE productName = '" + dtgProducts.Rows[dtgProducts.SelectedCells[0].RowIndex].Cells[0].Value.ToString() + "'";
                SqlDataReader reader;
                reader = comm.ExecuteReader();

                while (reader.Read())
                {
                    //dtgProducts.Rows.Add(reader["productName"].ToString(), reader["productPrice"].ToString(), reader["productStock"].ToString());
                    txtName.Text = reader["productName"].ToString();
                    txtPrice.Text = reader["productPrice"].ToString();
                    txtStock.Text = reader["productStock"].ToString();
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
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if(btnEdit.Text == "Edit")
            {
                if (txtName.Text.Equals(""))
                {
                    MessageBox.Show("Please select a product to edit", "No product selected", MessageBoxButtons.OK);
                    return;
                }
                selectedID = getID(dtgProducts.Rows[dtgProducts.SelectedCells[0].RowIndex].Cells[0].Value.ToString());
                cboCategory.Enabled = false;
                dtgProducts.Enabled = false;
                txtName.Enabled = true;
                txtPrice.Enabled = true;
                txtStock.Enabled = true;
                btnAddProduct.Enabled = false;
                btnAddStock.Enabled = false;
                btnRemoveProduct.Enabled = false;
                btnRemoveStock.Enabled = false; 
                btnEdit.Text = "Save";
            }
            else if(btnEdit.Text == "Save")
            {
                int stock;
                double price;
                if (!txtName.Text.Equals(dtgProducts.Rows[dtgProducts.SelectedCells[0].RowIndex].Cells[0].Value.ToString())){
                    if (alreadyExist(txtName.Text))
                    {
                        MessageBox.Show("The name you have entered is not unique", "Name is not unique", MessageBoxButtons.OK);
                        return;
                    }
                }
                if (!double.TryParse(txtPrice.Text,out price))
                {
                    MessageBox.Show("Please check your input in price", "Possible wrong input", MessageBoxButtons.OK);
                    return;
                }
                    if (!int.TryParse(txtStock.Text,out stock))
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
                try
                {
                    conn.ConnectionString = connstring;
                    conn.Open();
                    SqlCommand comm = new SqlCommand();
                    comm.Connection = conn;
                    comm.CommandText = "UPDATE productTbl SET productName = '" + txtName.Text + "', productPrice = " + price + ", productStock = " + stock + " WHERE productID = " + selectedID;
                    comm.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "An Error has occured! Please contact the programmer", MessageBoxButtons.OK);
                }
                finally
                {
                    conn.Close();
                }
                cboCategory.Enabled = true;
                dtgProducts.Enabled = true;
                txtName.Enabled = false;
                txtPrice.Enabled = false;
                txtStock.Enabled = false;
                btnAddProduct.Enabled = true;
                btnAddStock.Enabled = true;
                btnRemoveProduct.Enabled = true;
                btnRemoveStock.Enabled = true;
                btnEdit.Text = "Edit";
                categorySelected();
            }
            
        }


        public int getID(String productName)
        {
            int id = 0;
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
                    id = int.Parse(reader["productID"].ToString());
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
            return id;
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

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            Inventory.NewProductForm AddNew = new Inventory.NewProductForm();
            AddNew.formLoad();
            AddNew.ShowDialog();
        }

        private void btnRemoveProduct_Click(object sender, EventArgs e)
        {
            if (txtName.Text.Equals(""))
            {
                MessageBox.Show("Please select a product to remove first");
                return;
            }
            Boolean decisionContinue = false;
            switch (MessageBox.Show("Are you sure you want to remove " + txtName.Text,"Remove Confirmation",MessageBoxButtons.YesNo))
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
                    decisionContinue = true;
                    break;
                case DialogResult.No:
                    decisionContinue = false;
                    break;
                default:
                    break;
            }
            if (decisionContinue)
            {
                try
                {
                    conn.ConnectionString = connstring;
                    conn.Open();
                    SqlCommand comm = new SqlCommand();
                    comm.Connection = conn;
                    comm.CommandText = "DELETE FROM productTbl WHERE productName = '" + txtName.Text + "'";
                    comm.ExecuteNonQuery();
                    MessageBox.Show("Product removed", "Wala na :(", MessageBoxButtons.OK);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "An Error has occured! Please contact the programmer", MessageBoxButtons.OK);
                }
                finally
                {
                    conn.Close();
                }
                categorySelected();
            }
        }

        private void btnAddStock_Click(object sender, EventArgs e)
        {
            if (txtName.Text.Equals(""))
            {
                MessageBox.Show("Please select a product to add stock to", "No product selected", MessageBoxButtons.OK);
                return;
            }
            Inventory.StockForm stock = new Inventory.StockForm();
            stock.lblTitle.Text = "Add Stock";
            stock.productName = txtName.Text;
            stock.lblCurrentStock.Text = txtStock.Text;
            stock.btnAction.Text = "Add";
            stock.ShowDialog();
        }

        private void btnRemoveStock_Click(object sender, EventArgs e)
        {
            if (txtName.Text.Equals(""))
            {
                MessageBox.Show("Please select a product to add stock to", "No product selected", MessageBoxButtons.OK);
                return;
            }
            Inventory.StockForm stock = new Inventory.StockForm();
            stock.lblTitle.Text = "Remove Stock";
            stock.productName = txtName.Text;
            stock.lblCurrentStock.Text = txtStock.Text;
            stock.btnAction.Text = "Remove";
            stock.ShowDialog();
        }
    }
}
