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
    public partial class POSForm : Form
    {

        SqlConnection conn = new SqlConnection();
        String connstring = "Data Source=MACDO;Initial Catalog=downyDb;Integrated Security=True";

        public POSForm()
        {
            InitializeComponent();
        }
       
        public void POSClicked()
        {
            //MessageBox.Show("Test");

            flpCategory.Controls.Clear();
            flpProduct.Controls.Clear();

            Button allButton = new Button();
            allButton.Name = "All";
            allButton.Text = "All";
            allButton.Size = new Size(200, 44);
            allButton.ForeColor = Color.White;
            allButton.Font = new Font("Century Gothic", 12);
            allButton.FlatStyle = FlatStyle.Flat;
            allButton.FlatAppearance.BorderSize = 0;
            allButton.BackColor = Color.FromArgb(255, 6, 69, 133);
            allButton.Click += new EventHandler(menuClicked);
            flpCategory.Controls.Add(allButton);

            try
            {
                conn.ConnectionString = connstring;
                conn.Open();
                SqlCommand comm = new SqlCommand();
                comm.Connection = conn;
                comm.CommandText = "SELECT * FROM productCategoryTbl";
                SqlDataReader reader;
                reader = comm.ExecuteReader();

                while (reader.Read())
                {
                    Button myButton = new Button();
                    myButton.Name = reader["productCategoryID"].ToString();
                    myButton.Text = reader["productCategoryName"].ToString();
                    myButton.Size = new Size(200, 44);
                    myButton.ForeColor = Color.White;
                    myButton.Font = new Font("Century Gothic", 12);
                    myButton.FlatStyle = FlatStyle.Flat;
                    myButton.FlatAppearance.BorderSize = 0;
                    myButton.BackColor = Color.FromArgb(255, 6, 69, 133);
                    myButton.Click += new EventHandler(menuClicked);
                    flpCategory.Controls.Add(myButton);
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





            try
            {
                conn.ConnectionString = connstring;
                conn.Open();
                SqlCommand comm = new SqlCommand();
                comm.Connection = conn;
                comm.CommandText = "SELECT * FROM productTbl";
                SqlDataReader reader;
                reader = comm.ExecuteReader();

                while (reader.Read())
                {
                    Button myButton = new Button();
                    myButton.Name = reader["productID"].ToString();
                    myButton.Text = reader["productName"].ToString() + "\nP " + reader["productPrice"].ToString() + "\nStock: " + reader["productStock"].ToString();
                    myButton.Size = new Size(200, 144);
                    myButton.ForeColor = Color.White;
                    myButton.Font = new Font("Century Gothic", 12);
                    myButton.FlatStyle = FlatStyle.Flat;
                    myButton.FlatAppearance.BorderSize = 0;
                    myButton.BackColor = Color.FromArgb(255, 6, 69, 133);
                    myButton.Click += new EventHandler(productClicked);
                    flpProduct.Controls.Add(myButton);
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

            btnClear.PerformClick();
        }


        private void POSForm_Load_1(object sender, EventArgs e)
        {

            //Button allButton = new Button();
            //allButton.Name = "All";
            //allButton.Text = "All";
            //allButton.Size = new Size(200, 44);
            //allButton.ForeColor = Color.White;
            //allButton.Font = new Font("Century Gothic", 12);
            //allButton.FlatStyle = FlatStyle.Flat;
            //allButton.FlatAppearance.BorderSize = 0;
            //allButton.BackColor = Color.FromArgb(255, 6, 69, 133);
            //allButton.Click += new EventHandler(menuClicked);
            //flpCategory.Controls.Add(allButton);

            //try
            //{
            //    conn.ConnectionString = connstring;
            //    conn.Open();
            //    SqlCommand comm = new SqlCommand();
            //    comm.Connection = conn;
            //    comm.CommandText = "SELECT * FROM productCategoryTbl";
            //    SqlDataReader reader;
            //    reader = comm.ExecuteReader();
               
            //    while (reader.Read())
            //    {
            //        Button myButton = new Button();
            //        myButton.Name = reader["productCategoryID"].ToString();
            //        myButton.Text = reader["productCategoryName"].ToString();
            //        myButton.Size = new Size(200, 44);
            //        myButton.ForeColor = Color.White;
            //        myButton.Font = new Font("Century Gothic", 12);
            //        myButton.FlatStyle = FlatStyle.Flat;
            //        myButton.FlatAppearance.BorderSize = 0;
            //        myButton.BackColor = Color.FromArgb(255, 6, 69, 133);
            //        myButton.Click += new EventHandler(menuClicked);
            //        flpCategory.Controls.Add(myButton);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.ToString(), "An Error has occured! Please contact the programmer", MessageBoxButtons.OK);
            //}
            //finally
            //{
            //    conn.Close();
            //}





            //try
            //{
            //    conn.ConnectionString = connstring;
            //    conn.Open();
            //    SqlCommand comm = new SqlCommand();
            //    comm.Connection = conn;
            //    comm.CommandText = "SELECT * FROM productTbl";
            //    SqlDataReader reader;
            //    reader = comm.ExecuteReader();

            //    while (reader.Read())
            //    {
            //        Button myButton = new Button();
            //        myButton.Name = reader["productID"].ToString();
            //        myButton.Text = reader["productName"].ToString() + "\nP " + reader["productPrice"].ToString() + "\nStock: " + reader["productStock"].ToString();
            //        myButton.Size = new Size(200, 144);
            //        myButton.ForeColor = Color.White;
            //        myButton.Font = new Font("Century Gothic", 12);
            //        myButton.FlatStyle = FlatStyle.Flat;
            //        myButton.FlatAppearance.BorderSize = 0;
            //        myButton.BackColor = Color.FromArgb(255, 6, 69, 133);
            //        myButton.Click += new EventHandler(productClicked);
            //        flpProduct.Controls.Add(myButton);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.ToString(), "An Error has occured! Please contact the programmer", MessageBoxButtons.OK);
            //}
            //finally
            //{
            //    conn.Close();
            //}







            ////for (int i = 0; i < 5; i++)
            ////{
            ////    Button myButton = new Button();
            ////    myButton.Name = i.ToString();
            ////    myButton.Text = "Button number " + i;
            ////    myButton.Size = new Size(200, 44);
            ////    myButton.ForeColor = Color.White;
            ////    myButton.Font = new Font("Century Gothic", 12);
            ////    myButton.FlatStyle = FlatStyle.Flat;
            ////    myButton.BackColor = Color.FromArgb(255, 6, 69, 133);
            ////    myButton.Click += new EventHandler(menuClicked);
            ////    flpCategory.Controls.Add(myButton);
            ////}
        }

        public void menuClicked(object sender, EventArgs e)
        {
            Button dummyButton = (Button)sender;
            flpProduct.Controls.Clear();
            try
            {
                conn.ConnectionString = connstring;
                conn.Open();
                SqlCommand comm = new SqlCommand();
                comm.Connection = conn;
                if (dummyButton.Name.ToString().Equals("All"))
                {
                    comm.CommandText = "SELECT * FROM productTbl";
                }
                else
                {
                    comm.CommandText = "SELECT * FROM productTbl WHERE productCategoryID = " + dummyButton.Name.ToString();
                }
                SqlDataReader reader;
                reader = comm.ExecuteReader();

                while (reader.Read())
                {
                    Button myButton = new Button();
                    myButton.Name = reader["productID"].ToString();
                    myButton.Text = reader["productName"].ToString() + "\nP " + reader["productPrice"].ToString() + "\nStock: " + reader["productStock"].ToString();
                    myButton.Size = new Size(200, 144);
                    myButton.ForeColor = Color.White;
                    myButton.Font = new Font("Century Gothic", 12);
                    myButton.FlatStyle = FlatStyle.Flat;
                    myButton.BackColor = Color.FromArgb(255, 6, 69, 133);
                    myButton.Click += new EventHandler(productClicked);
                    flpProduct.Controls.Add(myButton);
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

        public void productClicked(object sender, EventArgs e)
        {
            Button myButton = (Button)sender;

            try
            {
                conn.ConnectionString = connstring;
                conn.Open();
                SqlCommand comm = new SqlCommand();
                comm.Connection = conn;
                comm.CommandText = "SELECT * FROM productTbl WHERE productID = " + myButton.Name.ToString();
                SqlDataReader reader;
                reader = comm.ExecuteReader();

                String name = "";
                String price = "";
                String stock = "";
                while (reader.Read())
                {
                    name = reader["productName"].ToString();
                    price = reader["productPrice"].ToString();
                    stock = reader["productStock"].ToString();
                }

                if(int.Parse(stock) == 0)
                {
                    MessageBox.Show("Out of stock", "No Stock", MessageBoxButtons.OK);
                }

                Boolean itemAlreadyListed = false;
                Boolean quantityWillExceedStock = false;
                foreach (DataGridViewRow row in dtgItems.Rows)
                {
                    if (row.Cells[0].Value.ToString().Equals(name))
                    {
                        if (int.Parse(stock) < (int.Parse(row.Cells[1].Value.ToString()) + 1))
                        {
                            quantityWillExceedStock = true;
                            MessageBox.Show("Quantity cannot exceed stock", "No more stock", MessageBoxButtons.OK);
                        }
                        else
                        {
                            row.Cells[1].Value = int.Parse(row.Cells[1].Value.ToString()) + 1;
                            row.Cells[2].Value = int.Parse(row.Cells[1].Value.ToString()) * int.Parse(price);
                            itemAlreadyListed = true;
                        }
                    }
                }
               
                if (!itemAlreadyListed & !quantityWillExceedStock)
                {
                    dtgItems.Rows.Add(name, "1", price);
                }

                btnRemove.Enabled = true;

                int sum = 0;
                foreach(DataGridViewRow row in dtgItems.Rows)
                {
                    sum += int.Parse(row.Cells[2].Value.ToString());
                }

                lblTotal.Text = sum.ToString();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "An Error has occured! Please contact the programmer", MessageBoxButtons.OK);
            }
            finally
            {
                conn.Close();
            }
            refreshResult();
        }

        public void refreshResult()
        {
            txtCash.ForeColor = Color.Black;
            //if (txtCash.Text.Equals("0"))
            //{
            //    lblChange.Text = lblTotal.Text;
            //    return;
            //}
            if (txtCash.Text.Equals(""))
            {
                lblChange.ForeColor = Color.Red;
                lblChange.Text = "-" + lblTotal.Text;
                return;
            }
            double cash = 0;
            if (double.TryParse(txtCash.Text, out cash))
            {
                double total = cash - int.Parse(lblTotal.Text);
                if (total < 0)
                {
                    lblChange.ForeColor = Color.Red;
                }
                else
                {
                    lblChange.ForeColor = Color.White;
                }
                lblChange.Text = total.ToString();

            }
            else
            {
                //MessageBox.Show("Please check your input in cash", "Wrong input", MessageBoxButtons.OK);
                txtCash.ForeColor = Color.Red;
                lblChange.Text = lblTotal.Text;
            }
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                dtgItems.Rows.RemoveAt(dtgItems.SelectedCells[0].RowIndex);
                if(dtgItems.Rows.Count == 0)
                {
                    btnRemove.Enabled = false;
                }
                int sum = 0;
                foreach (DataGridViewRow row in dtgItems.Rows)
                {
                    sum += int.Parse(row.Cells[2].Value.ToString());
                }
                lblTotal.Text = sum.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please select an item first", "No item selected", MessageBoxButtons.OK);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            dtgItems.Rows.Clear();
            lblTotal.Text = "0";
            txtCash.Text = "";
            lblChange.Text = "0";
        }

        private void txtCash_TextChanged(object sender, EventArgs e)
        {
            refreshResult();

            //txtCash.ForeColor = Color.Black;
            ////if (txtCash.Text.Equals("0"))
            ////{
            ////    lblChange.Text = lblTotal.Text;
            ////    return;
            ////}
            //double cash = 0;
            //if(double.TryParse(txtCash.Text, out cash))
            //{
            //    double total = cash - int.Parse(lblTotal.Text);
            //    if (total < 0)
            //    {
            //        lblChange.ForeColor = Color.Red;
            //    }
            //    else
            //    {
            //        lblChange.ForeColor = Color.White;
            //    }
            //    lblChange.Text = total.ToString();

            //}
            //else
            //{
            //    //MessageBox.Show("Please check your input in cash", "Wrong input", MessageBoxButtons.OK);
            //    txtCash.ForeColor = Color.Red;
            //    lblChange.Text = lblTotal.Text;
            //}

        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            if(dtgItems.Rows.Count == 0)
            {
                MessageBox.Show("Please add an item first", "Nothing to be processed", MessageBoxButtons.OK);
                return;
            }
            if(txtCash.ForeColor == Color.Red | txtCash.Text.Equals(""))
            {
                MessageBox.Show("Please check the input in your cash", "Wrong input", MessageBoxButtons.OK);
                return;
            }
            if (lblChange.ForeColor == Color.Red | txtCash.Text.Equals("0"))
            {
                MessageBox.Show("Cash in is less than the total value", "Insufficient Cash", MessageBoxButtons.OK);
                return; 
            }

            String message = "Reciept:\nQty\t\tPrice\t\tItem\n";

            foreach(DataGridViewRow row in dtgItems.Rows)
            {
                message += row.Cells[1].Value.ToString() + "\t\t" + row.Cells[2].Value.ToString() + "\t\t" + row.Cells[0].Value.ToString() + "\n";
            }
            message += "Total: " + lblTotal.Text + "\nCash In: " + txtCash.Text + "\nChange: " + lblChange.Text;

            MessageBox.Show(message, "Process", MessageBoxButtons.OK);

            String sql = "";

            foreach(DataGridViewRow row in dtgItems.Rows)
            {
                sql += itemPurchasedQuery(row.Cells[0].Value.ToString(), int.Parse(row.Cells[1].Value.ToString()));
            }

            try
            {
                conn.ConnectionString = connstring;
                conn.Open();
                SqlCommand comm = new SqlCommand();
                comm.Connection = conn;
                comm.CommandText = sql;
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

            //btnClear.PerformClick();
            POSClicked();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public String itemPurchasedQuery(String product, int quantity)
        {
            int currentStock = 0;
            int newStock = 0;
            try
            {
                conn.ConnectionString = connstring;
                conn.Open();
                SqlCommand comm = new SqlCommand();
                comm.Connection = conn;
                comm.CommandText = "SELECT * FROM productTbl WHERE productName = '" + product + "'";
            
                SqlDataReader reader;
                reader = comm.ExecuteReader();

                while (reader.Read())
                {
                    currentStock = int.Parse(reader["productStock"].ToString());
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
            newStock = currentStock - quantity;

            return "UPDATE productTbl SET productStock = " + newStock + " WHERE productName = '" + product + "';";
        }

    }
}
