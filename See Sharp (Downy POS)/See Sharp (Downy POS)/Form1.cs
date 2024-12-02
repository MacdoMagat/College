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
    public partial class LoginForm : Form
    {
        public static MainForm main = new MainForm();

        SqlConnection conn = new SqlConnection();
        String connstring = "Data Source=MACDO;Initial Catalog=downyDb;Integrated Security=True";

        public LoginForm()
        {
            InitializeComponent();
        }
        
        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                conn.ConnectionString = connstring;
                conn.Open();
                SqlCommand comm = new SqlCommand();
                comm.Connection = conn;
                comm.CommandText = "SELECT * FROM userTbl WHERE userUN = '" + txtUN.Text + "' AND userPW = '" + txtPW.Text + "'";
                SqlDataReader reader;
                reader = comm.ExecuteReader();
                int counter = 0;
                String type = "";
                while (reader.Read())
                {
                    counter += 1;
                    type = reader["userType"].ToString();
                }

                if (counter == 0)
                {
                    MessageBox.Show("Please check your username and password", "No account detected", MessageBoxButtons.OK);
                }
                else if (counter == 1)
                {
                    MessageBox.Show("Welcome " + type, "Welcome", MessageBoxButtons.OK);
                    if (type.Equals("User"))
                    {
                        main.btnInventory.Enabled = false;  
                    }
                    main.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Multiple Accounts we detected", "Multiple Account", MessageBoxButtons.OK);
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


        private void LoginForm_Load(object sender, EventArgs e)
        {
            MessageBox.Show("See Sharp POS for Downy\nBy Marc Dominic M. Magat\nBSIT-4A\n\nAdministrator\n\tUsername: admin\n\tPassword: admin\nUser\n\tUsername: user\n\tPassword: user\n\nNote:\n\tMa'am Login at POS lang po ito, balak ko po sanang lagyan ng inventory sa mga susunod na panahon. Lagyan ko po sana ng main form pero POS na lang po muna pagka-login.");
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //private void LoginForm_Load()
        //{
        //    MessageBox.Show("See Sharp POS for Downy\nBy Marc Dominic M. Magat\nBSIT-4A\n\nAdministrator\n\tUsername:admin\n\tPassword:admin\nUser\n\tUsername:user\n\tPassword:user\n\nNote:\n\tMa'am Login at POS lang po ito, balak ko po sanang lagyan ng inventory sa mga susunod na panahon. Lagyan ko po sana ng main form pero POS na lang po muna isinunod ko.");
        //}



        //public void showForm()
        //{
        //    this.Show();
        //}
    }
}
