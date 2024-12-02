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
    public partial class POSForm : Form
    {

        private MySqlConnection conn = new MySqlConnection();
        private string connstring = Program.connstring;

        public POSForm()
        {
            InitializeComponent();
        }

        private void POSForm_Load(object sender, EventArgs e)
        {
            Button2.Enabled = false;
            try
            {
                conn.ConnectionString = connstring;
                conn.Open();

                string categoryquery = "SELECT * FROM productcategorytbl";
                MySqlCommand categorycomm = new MySqlCommand();
                MySqlDataReader categoryreader;
                categorycomm.CommandText = categoryquery;
                categorycomm.Connection = conn;
                categoryreader = categorycomm.ExecuteReader();

                Button categorybtn;
                while (categoryreader.Read())
                {
                    categorybtn = new Button();
                    categorybtn.Name = categoryreader["productcategoryname"].ToString();
                    categorybtn.Text = categoryreader["productcategoryname"].ToString();
                    categorybtn.Width = 100;
                    categorybtn.Height = 59;
                    categorybtn.ForeColor = Color.White;
                    categorybtn.Font = new Font("Century Gothic", 12);
                    categorybtn.FlatStyle = FlatStyle.Flat;
                    categorybtn.BackColor = Color.Coral;
                    categorybtn.FlatAppearance.BorderColor = Color.Black;
                    categorybtn.Click += categorybuttonclicked;
                    FlowLayoutPanel2.Controls.Add(categorybtn);
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

                string productquery = "SELECT * FROM producttbl LEFT JOIN productcategorytbl ON producttbl.productcategoryid = productcategorytbl.productcategoryid";
                MySqlCommand productcomm = new MySqlCommand();
                MySqlDataReader productreader;
                productcomm.CommandText = productquery;
                productcomm.Connection = conn;
                productreader = productcomm.ExecuteReader();

                Button productbtn;
                while (productreader.Read())
                {
                    productbtn = new Button();
                    productbtn.Name = productreader["productname"].ToString();
                    productbtn.Text = "ID: [" + productreader["productid"].ToString() + "]" + Environment.NewLine + productreader["productname"].ToString() + Environment.NewLine + "P " + productreader["productprice"].ToString();
                    productbtn.Width = 165;
                    productbtn.Height = 100;
                    productbtn.ForeColor = Color.White;
                    productbtn.Font = new Font("Century Gothic", 12);
                    productbtn.FlatStyle = FlatStyle.Flat;
                    productbtn.BackColor = Color.MediumTurquoise;
                    productbtn.FlatAppearance.BorderColor = Color.Black;
                    productbtn.Click += productbuttonclicked;
                    FlowLayoutPanel1.Controls.Add(productbtn);
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
        }














        public void categorybuttonclicked(object sender, EventArgs e)
        {

            // MsgBox(sender.ToString)
            int start = sender.ToString().IndexOf(":") + 2;
            string selectedcategory = sender.ToString().Substring(start, sender.ToString().Length - start);

            try
            {
                FlowLayoutPanel1.Controls.Clear();

                conn.ConnectionString = connstring;
                conn.Open();

                string productquery = "SELECT * FROM producttbl LEFT JOIN productcategorytbl ON producttbl.productcategoryid = productcategorytbl.productcategoryid WHERE productcategorytbl.productcategoryname = '" + selectedcategory + "'";
                MySqlCommand productcomm = new MySqlCommand();
                MySqlDataReader productreader;
                productcomm.CommandText = productquery;
                productcomm.Connection = conn;
                productreader = productcomm.ExecuteReader();

                Button productbtn;
                while (productreader.Read())
                {
                    productbtn = new Button();
                    productbtn.Name = productreader["productname"].ToString();
                    productbtn.Text = "ID: [" + productreader["productid"].ToString() + "]" + Environment.NewLine + productreader["productname"].ToString() + Environment.NewLine + "P " + productreader["productprice"].ToString();
                    productbtn.Width = 165;
                    productbtn.Height = 100;
                    productbtn.ForeColor = Color.White;
                    productbtn.Font = new Font("Century Gothic", 12);
                    productbtn.FlatStyle = FlatStyle.Flat;
                    productbtn.BackColor = Color.MediumTurquoise;
                    productbtn.FlatAppearance.BorderColor = Color.Black;
                    productbtn.Click += productbuttonclicked;
                    FlowLayoutPanel1.Controls.Add(productbtn);
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
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                FlowLayoutPanel1.Controls.Clear();

                conn.ConnectionString = connstring;
                conn.Open();

                string productquery = "SELECT * FROM producttbl LEFT JOIN productcategorytbl ON producttbl.productcategoryid = productcategorytbl.productcategoryid";
                MySqlCommand productcomm = new MySqlCommand();
                MySqlDataReader productreader;
                productcomm.CommandText = productquery;
                productcomm.Connection = conn;
                productreader = productcomm.ExecuteReader();

                Button productbtn;
                while (productreader.Read())
                {
                    productbtn = new Button();
                    productbtn.Name = productreader["productname"].ToString();
                    productbtn.Text = "ID: [" + productreader["productid"].ToString() + "]" + Environment.NewLine + productreader["productname"].ToString() + Environment.NewLine + "P " + productreader["productprice"].ToString();
                    productbtn.Width = 165;
                    productbtn.Height = 100;
                    productbtn.ForeColor = Color.White;
                    productbtn.Font = new Font("Century Gothic", 12);
                    productbtn.FlatStyle = FlatStyle.Flat;
                    productbtn.BackColor = Color.MediumTurquoise;
                    productbtn.FlatAppearance.BorderColor = Color.Black;
                    productbtn.Click += productbuttonclicked;

                    // If CInt(productreader("productquantity")) > 0 Then
                    FlowLayoutPanel1.Controls.Add(productbtn);
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
        }











        public void productbuttonclicked(object sender, EventArgs e)
        {
            string productselectedid = sender.ToString().Substring(sender.ToString().IndexOf("[") + 1, sender.ToString().IndexOf("]") - sender.ToString().IndexOf("[") - 1);
            try
            {
                conn.ConnectionString = connstring;
                conn.Open();

                MySqlCommand comm = new MySqlCommand();
                string query = "SELECT * FROM producttbl WHERE productid = " + productselectedid + "";
                MySqlDataReader reader;
                comm.CommandText = query;
                comm.Connection = conn;
                reader = comm.ExecuteReader();

                // While reader.Read
                // DataGridView1.Rows.Add(reader("productname").ToString, reader("productprice").ToString)
                // Dim initialprice As Double = CDbl(Label4.Text)
                // Label4.Text = initialprice + CDbl(reader("productprice").ToString)
                // End While

                // MsgBox(DataGridView1.Rows.Count)
                // MsgBox(DataGridView1.Rows(2).Cells(0).Value.ToString) ung 2 ung i
                // ung count ay minus one kase kasama ung blank sa bilangan
                while (reader.Read())
                {
                    bool productalreadylisted = false;
                    int rowindex=0;
                    if (DataGridView1.Rows.Count > 1)
                    {
                        for (int i = 0; i <= DataGridView1.Rows.Count - 2; i++)
                        {
                            if (DataGridView1.Rows[i].Cells[0].Value.ToString().Equals(reader["productname"].ToString()))
                            {
                                rowindex = i;
                                productalreadylisted = true;
                                break;
                            }
                        }
                    }
                    if (productalreadylisted)
                    {
                        if (System.Convert.ToInt32(reader["productquantity"]) - System.Convert.ToInt32(DataGridView1.Rows[rowindex].Cells[1].Value.ToString()) <= 0)
                        {
                            MessageBox.Show("Out of Stock");
                            return;
                        }
                        else
                        {
                            DataGridView1.Rows[rowindex].Cells[2].Value = System.Convert.ToDouble(DataGridView1.Rows[rowindex].Cells[2].Value.ToString()) + System.Convert.ToDouble(reader["productprice"].ToString());
                            DataGridView1.Rows[rowindex].Cells[1].Value = System.Convert.ToInt32(DataGridView1.Rows[rowindex].Cells[1].Value.ToString()) + 1;
                            double initialprice = System.Convert.ToDouble(Label4.Text);
                            Label4.Text = (initialprice + System.Convert.ToDouble(reader["productprice"].ToString())).ToString();
                        }
                    }
                    else if (System.Convert.ToBoolean(int.Parse(reader["productquantity"].ToString()) <= 0))
                    {
                        MessageBox.Show("Out of Stock");
                        return;
                    }
                    else
                    {
                        DataGridView1.Rows.Add(reader["productname"].ToString(), "1", reader["productprice"].ToString());
                        double initialprice = System.Convert.ToDouble(Label4.Text);
                        Label4.Text = (initialprice + System.Convert.ToDouble(reader["productprice"].ToString())).ToString();
                    }

                    if (DataGridView1.Rows.Count - 1 > 0)
                        Button4.Enabled = true;
                    else
                        Button4.Enabled = false;
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
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            Label9.Text = DateTime.Now.ToString("hh:mm:ss");
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            Button4.Enabled = false;
            Label4.Text = "0";
            DataGridView1.Rows.Clear();
            TextBox1.Text = "";
            Label6.Text = "0";
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            Program.mainFormInstance.Show();
            this.Hide();
        }

        private void POSForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.mainFormInstance.Show();
        }

        private void DataGridView1_Click(object sender, EventArgs e)
        {
            try
            {
                int dummy = DataGridView1.CurrentRow.Index;
                if (DataGridView1.CurrentRow.Index + 1 == DataGridView1.Rows.Count)
                    Button2.Enabled = false;
                else
                    Button2.Enabled = true;
            }
            catch (Exception ex)
            {
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            double priceofselecteditem=0;
            try
            {
                conn.ConnectionString = connstring;
                conn.Open();


                MySqlCommand comm = new MySqlCommand();
                string query = "SELECT * FROM producttbl WHERE productname = '" + DataGridView1.Rows[DataGridView1.CurrentRow.Index].Cells[0].Value.ToString() + "'";
                MySqlDataReader reader;
                comm.Connection = conn;
                comm.CommandText = query;
                reader = comm.ExecuteReader();

                while (reader.Read())
                {
                    priceofselecteditem = System.Convert.ToDouble(reader["productprice"].ToString());
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
                if (DataGridView1.Rows[DataGridView1.CurrentRow.Index].Cells[1].Value.ToString().Equals("1"))
                {
                    DataGridView1.Rows.RemoveAt(DataGridView1.CurrentRow.Index);
                    Label4.Text = (System.Convert.ToDouble(Label4.Text) - priceofselecteditem).ToString();
                    Button2.Enabled = false;
                }
                else
                {
                    DataGridView1.Rows[DataGridView1.CurrentRow.Index].Cells[1].Value = System.Convert.ToInt32(DataGridView1.Rows[DataGridView1.CurrentRow.Index].Cells[1].Value.ToString()) - 1;
                    DataGridView1.Rows[DataGridView1.CurrentRow.Index].Cells[2].Value = System.Convert.ToDouble(DataGridView1.Rows[DataGridView1.CurrentRow.Index].Cells[2].Value.ToString()) - priceofselecteditem;
                    Label4.Text = (System.Convert.ToDouble(Label4.Text) - priceofselecteditem).ToString();
                }
                // MsgBox(DataGridView1.Rows.Count)
                if (DataGridView1.Rows.Count - 1 > 0)
                    Button4.Enabled = true;
                else
                    Button4.Enabled = false;
            }
            catch (Exception ex)
            {
            }
        }
























        private void Button4_Click(object sender, EventArgs e)
        {
            double cash;
            if (TextBox1.Text == "")
                TextBox1.Text = "0";
            try
            {
                cash = double.Parse(TextBox1.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cash must be numbers");
                TextBox1.Text = "0";
                return;
            }
            Label6.Text = (cash - System.Convert.ToDouble(Label4.Text)).ToString();
            if (System.Convert.ToDouble(Label6.Text) < 0)
            {
                MessageBox.Show("Please check cash");
                return;
            }


            purchaseconfirmed();

            MessageBox.Show("Transaction Success");

            Button4.Enabled = false;
            Label4.Text = "0";
            DataGridView1.Rows.Clear();
            TextBox1.Text = "";
            Label6.Text = "0";


            //POSPayReportForm.Label6.Text = cash;
            //POSPayReportForm.Label5.Text = Label6.Text;
            // POSPayReportForm.Button1.Enabled = False
            //POSPayReportForm.ShowDialog();
        }




        public void purchase(string productname, int quantitypurchased)
        {
            int initialquantity=0;
            try
            {
                conn.ConnectionString = connstring;
                conn.Open();

                MySqlCommand comm = new MySqlCommand();
                string query = "SELECT * FROM producttbl WHERE productname = '" + productname + "'";
                MySqlDataReader reader;
                comm.CommandText = query;
                comm.Connection = conn;
                reader = comm.ExecuteReader();

                while (reader.Read())
                    initialquantity = System.Convert.ToInt32(reader["productquantity"].ToString());
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
                string updatequery = "UPDATE producttbl SET productquantity = " + (initialquantity - quantitypurchased).ToString() + " WHERE productname = '" + productname + "'";
                // MsgBox(initialquantity & " - " & quantitypurchased & " = " & initialquantity - quantitypurchased)
                comm.CommandText = updatequery;
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
                string query = "INSERT INTO productpurchasestbl(productname,quantity,datepurchased) VALUES('" + productname + "','" + quantitypurchased + "',NOW())";

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
        }






        public void purchaseconfirmed()
        {
            for (int i = 0; i <= DataGridView1.Rows.Count - 2; i++)
                purchase(DataGridView1.Rows[i].Cells[0].Value.ToString(), System.Convert.ToInt32(DataGridView1.Rows[i].Cells[1].Value.ToString()));
            try
            {
                conn.ConnectionString = connstring;
                conn.Open();

                MySqlCommand comm = new MySqlCommand();
                string query = "INSERT INTO `salestbl`(`sold`, `dateandtime`) VALUES (" + Label4.Text + ",now())";

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
                string query = "INSERT INTO logstbl(username,process,description,dateandtime) VALUES('" + Program.login.username + "','POS - Sold Items','Sold items with a total value of " + Label4.Text + "',NOW())";

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

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            double cash;
            if (TextBox1.Text == "")
                TextBox1.Text = "0";
            try
            {
                cash = double.Parse(TextBox1.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cash must be numbers");
                TextBox1.Text = "0";
                return;
            }
            Label6.Text = (cash - System.Convert.ToDouble(Label4.Text)).ToString();
        }
    }
}
