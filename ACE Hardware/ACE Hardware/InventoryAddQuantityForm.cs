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
    public partial class InventoryAddQuantityForm : Form
    {

        private int initialquantity;
        private MySqlConnection conn = new MySqlConnection();
        private string connstring = Program.connstring;

        public InventoryAddQuantityForm()
        {
            InitializeComponent();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void InventoryAddQuantityForm_Load(object sender, EventArgs e)
        {
            initialquantity = int.Parse(Program.inventoryFormInstance.TextBox3.Text);
            this.Label2.Text = Program.inventoryFormInstance.TextBox2.Text;
            this.Label3.Text = Program.inventoryFormInstance.Label8.Text;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                int dummy = System.Convert.ToInt32(TextBox1.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please enter a valid quantity");
                return;
            }
            try
            {
                conn.ConnectionString = connstring;
                conn.Open();

                int finalquantity = initialquantity + System.Convert.ToInt32(TextBox1.Text);

                MySqlCommand comm = new MySqlCommand();
                string query = "UPDATE producttbl SET productquantity = " + finalquantity + " WHERE productid = '" + Label3.Text + "'";
                // UPDATE `producttbl` SET `productid`=[value-1],`productname`=[value-2],`productcategoryid`=[value-3],`productquantity`=[value-4],`productprice`=[value-5] WHERE 1

                comm.CommandText = query;
                comm.Connection = conn;
                comm.ExecuteNonQuery();
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
                string query = "INSERT INTO logstbl(username,process,description,dateandtime) VALUES('" + Program.login.username + "','Inventory - Add Quantity','Quantity (" + TextBox1.Text + ") added to Product (" + Label2.Text + ")',NOW())";

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

            Program.inventoryFormInstance.searchitem(Program.inventoryFormInstance.TextBox1.Text, Program.inventoryFormInstance.ComboBox1.Text);
            Program.inventoryFormInstance.iteminfo(Label3.Text);
            this.Close();
        }
    }
}
