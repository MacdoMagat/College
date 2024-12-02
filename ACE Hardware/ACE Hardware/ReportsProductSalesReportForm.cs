﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ACE_Hardware
{
    public partial class ReportsProductSalesReportForm : Form
    {

        private MySqlConnection conn = new MySqlConnection();
        private string connstring = Program.connstring;




        public ReportsProductSalesReportForm()
        {
            InitializeComponent();
        }








        public void refreshchart(string productname, string condition)
        {
            Chart1.Series["Sales"].Points.Clear();

            if (condition == "Weekly")
            {
                DateTime dailydate = new DateTime();
                dailydate = DateTime.Now ;
                dailydate = dailydate.AddDays(-7);
                for (int i = 0; i <= 7; i++)
                {
                    try
                    {
                        conn.ConnectionString = connstring;
                        conn.Open();

                        MySqlCommand comm = new MySqlCommand();
                        string commstring = "SELECT productname, SUM(quantity), datepurchased FROM productpurchasestbl WHERE productname='" + productname + "'  AND YEAR(datepurchased)='" + dailydate.ToString("yyyy") + "' AND MONTH(datepurchased)='" + dailydate.ToString("MM") + "' AND DAY(datepurchased)='" + dailydate.ToString("dd") + "' GROUP BY productname";
                        MySqlDataReader reader;

                        comm.Connection = conn;
                        comm.CommandText = commstring;
                        reader = comm.ExecuteReader();

                        while (reader.Read())
                            Chart1.Series["Sales"].Points.AddXY(dailydate.ToString("yyyy-MM-dd"), System.Convert.ToInt32(reader["SUM(quantity)"].ToString()));
                        dailydate = dailydate.AddDays(1);
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
            }
            else if (condition == "Monthly")
            {
                DateTime dailydate = new DateTime();
                dailydate = DateTime.Now;
                dailydate = dailydate.AddMonths(-6);
                for (int i = 0; i <= 6; i++)
                {
                    try
                    {
                        conn.ConnectionString = connstring;
                        conn.Open();

                        MySqlCommand comm = new MySqlCommand();
                        string commstring = "SELECT productname, SUM(quantity), datepurchased FROM productpurchasestbl WHERE productname='" + productname + "'  AND YEAR(datepurchased)='" + dailydate.ToString("yyyy") + "' AND MONTH(datepurchased)='" + dailydate.ToString("MM") + "' GROUP BY productname";
                        MySqlDataReader reader;

                        comm.Connection = conn;
                        comm.CommandText = commstring;
                        reader = comm.ExecuteReader();

                        double total = 0;
                        while (reader.Read())
                            total = total + System.Convert.ToDouble(reader["SUM(Quantity)"].ToString());

                        Chart1.Series["Sales"].Points.AddXY(dailydate.ToString("MMM"), total);
                        dailydate = dailydate.AddMonths(1);
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
            }
            else if (condition == "Yearly")
            {
                DateTime dailydate = new DateTime();
                dailydate = DateTime.Now;
                dailydate = dailydate.AddYears(-5);
                for (int i = 0; i <= 5; i++)
                {
                    try
                    {
                        conn.ConnectionString = connstring;
                        conn.Open();

                        MySqlCommand comm = new MySqlCommand();
                        string commstring = "SELECT productname, SUM(quantity), datepurchased FROM productpurchasestbl WHERE productname='" + productname + "'  AND YEAR(datepurchased)='" + dailydate.ToString("yyyy") + "' GROUP BY productname";
                        MySqlDataReader reader;

                        comm.Connection = conn;
                        comm.CommandText = commstring;
                        reader = comm.ExecuteReader();

                        double total = 0;
                        while (reader.Read())
                            total = total + System.Convert.ToDouble(reader["SUM(quantity)"].ToString());

                        Chart1.Series["Sales"].Points.AddXY(dailydate.ToString("yyyy"), total);
                        dailydate = dailydate.AddYears(1);
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
            }
        }


        public void refreshproduct(string productcategoryname)
        {
            string id="0";
            try
            {
                conn.ConnectionString = connstring;
                conn.Open();

                MySqlCommand comm = new MySqlCommand();
                string query = "SELECT * FROM productcategorytbl WHERE productcategoryname = '" + productcategoryname + "'";
                MySqlDataReader reader;

                comm.CommandText = query;
                comm.Connection = conn;
                reader = comm.ExecuteReader();


                while (reader.Read())
                    id = reader["productcategoryid"].ToString();
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
                string query = "SELECT * FROM producttbl WHERE productcategoryid = '" + id + "'";
                MySqlDataReader reader;

                comm.CommandText = query;
                comm.Connection = conn;
                reader = comm.ExecuteReader();

                ComboBox2.Items.Clear();
                while (reader.Read())
                    ComboBox2.Items.Add(reader["productname"].ToString());
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


        public void refreshcategory()
        {
            try
            {
                conn.ConnectionString = connstring;
                conn.Open();

                MySqlCommand comm = new MySqlCommand();
                string query = "SELECT * FROM productcategorytbl";
                MySqlDataReader reader;

                comm.CommandText = query;
                comm.Connection = conn;
                reader = comm.ExecuteReader();

                ComboBox1.Items.Clear();
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
        }

        private void ReportsProductSalesReportForm_Load(object sender, EventArgs e)
        {
            refreshcategory();
            ComboBox1.SelectedIndex = 0;
            refreshproduct(ComboBox1.SelectedItem.ToString());
            ComboBox2.SelectedIndex = 0;
            ComboBox3.SelectedIndex = 0;
            refreshchart(ComboBox2.Text, ComboBox3.Text);
        }

        private void ComboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            refreshchart(ComboBox2.Text, ComboBox3.Text);
        }

        private void ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            refreshchart(ComboBox2.Text, ComboBox3.Text);
            Label1.Text = "Product Sales Report: " + ComboBox2.Text;
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            refreshproduct(ComboBox1.SelectedItem.ToString());
            ComboBox2.SelectedIndex = 0;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            PrintPreviewDialog1.Document = PrintDocument1;
            PrintPreviewDialog1.ShowDialog();
        }

        private void PrintDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Bitmap bm = new Bitmap(1200, 1200);
            Chart1.DrawToBitmap(bm, new Rectangle(0, 0, 1200, 1200));
            e.Graphics.DrawImage(bm, 100, 300);

            e.Graphics.DrawString("ACE Hardware", new Font("Arial", 20, FontStyle.Bold), Brushes.Black, new Point(300, 100));

            e.Graphics.DrawString(ComboBox2.Text, new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(355, 180));
            e.Graphics.DrawString(ComboBox3.Text, new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(375, 200));
            e.Graphics.DrawString("Sales Report", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(350, 220));
        }
    }
}
