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
    public partial class StockForm : Form
    {
        SqlConnection conn = new SqlConnection();
        String connstring = "Data Source=MACDO;Initial Catalog=downyDb;Integrated Security=True";
        public String productName = "";

        public StockForm()
        {
            InitializeComponent();
        }

        private void StockForm_Load(object sender, EventArgs e)
        {

        }

        private void btnAction_Click(object sender, EventArgs e)
        {
            int dummyNumber;
            if(!int.TryParse(txtHowMany.Text,out dummyNumber))
            {
                MessageBox.Show("Error input", "Error", MessageBoxButtons.OK);
                return;
            }
            int currentStock = int.Parse(lblCurrentStock.Text);
            if (btnAction.Text.Equals("Add"))
            {
                int stockToBeAdded = 0;
                if(int.TryParse(txtHowMany.Text,out stockToBeAdded))
                {
                    if (stockToBeAdded < 0)
                    {
                        MessageBox.Show("How can you add negative stock?", "Error haha XD", MessageBoxButtons.OK);
                        return;
                    }
                    else
                    {
                        currentStock += stockToBeAdded;
                    }
                }
            }
            else if (btnAction.Text.Equals("Remove"))
            {
                int stockToBeRemoved = 0;
                if (int.TryParse(txtHowMany.Text, out stockToBeRemoved))
                {
                    if (stockToBeRemoved < 0)
                    {
                        MessageBox.Show("How can you remove negative stock?", "Error haha XD", MessageBoxButtons.OK);
                        return;
                    }
                    else
                    {
                        currentStock -= stockToBeRemoved;
                    }
                }
            }
            try
            {
                conn.ConnectionString = connstring;
                conn.Open();
                SqlCommand comm = new SqlCommand();
                comm.Connection = conn;
                comm.CommandText = "UPDATE productTbl SET productStock = " + currentStock + " WHERE productName = '" + productName + "'";
                comm.ExecuteNonQuery();
                MessageBox.Show("Stock updated", "Yey!", MessageBoxButtons.OK);
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
