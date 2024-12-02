using System;
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
    public partial class ReportsSalesReportForm : Form
    {

        private MySqlConnection conn = new MySqlConnection();
        private string connstring = Program.connstring;

        public ReportsSalesReportForm()
        {
            InitializeComponent();
        }





        public void refreshlist(string condition)
        {
            Chart1.Series["Sales"].Points.Clear();

            if (condition == "Weekly")
            {
                DateTime dailydate = new DateTime();
                dailydate = DateTime.Now;
                dailydate = dailydate.AddDays(-7);
                for (int i = 0; i <= 7; i++)
                {
                    try
                    {
                        conn.ConnectionString = connstring;
                        conn.Open();

                        MySqlCommand comm = new MySqlCommand();
                        string commstring = "SELECT SUM(sold) FROM `salestbl` WHERE DATE(dateandtime)='" + dailydate.ToString("yyyy-MM-dd") + "' GROUP BY dateandtime";
                        MySqlDataReader reader;

                        comm.Connection = conn;
                        comm.CommandText = commstring;
                        reader = comm.ExecuteReader();

                        while (reader.Read())
                            Chart1.Series["Sales"].Points.AddXY(dailydate.ToString("yyyy-MM-dd"), System.Convert.ToInt32(reader["SUM(sold)"].ToString()));
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
                        string commstring = "SELECT SUM(sold) FROM `salestbl` WHERE YEAr(dateandtime)='" + dailydate.ToString("yyyy") + "' AND MONTH(dateandtime)='" + dailydate.ToString("MM") + "' GROUP BY dateandtime";
                        MySqlDataReader reader;

                        comm.Connection = conn;
                        comm.CommandText = commstring;
                        reader = comm.ExecuteReader();

                        double total = 0;
                        while (reader.Read())
                            total = total + System.Convert.ToDouble(reader["SUM(sold)"].ToString());

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
                        string commstring = "SELECT SUM(sold) FROM `salestbl` WHERE YEAr(dateandtime)='" + dailydate.ToString("yyyy") + "' GROUP BY dateandtime";
                        MySqlDataReader reader;

                        comm.Connection = conn;
                        comm.CommandText = commstring;
                        reader = comm.ExecuteReader();

                        double total = 0;
                        while (reader.Read())
                            total = total + System.Convert.ToDouble(reader["SUM(sold)"].ToString());

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

        private void ReportsSalesReportForm_Load(object sender, EventArgs e)
        {
            ComboBox1.SelectedIndex = 0;
            refreshlist(ComboBox1.Text);
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            refreshlist(ComboBox1.Text);
        }

        private void PrintDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Bitmap bm = new Bitmap(1200, 1200);
            Chart1.DrawToBitmap(bm, new Rectangle(0, 0, 1200, 1200));
            e.Graphics.DrawImage(bm, 100, 300);

            e.Graphics.DrawString("ACE Hardware", new Font("Arial", 20, FontStyle.Bold), Brushes.Black, new Point(300, 100));

            e.Graphics.DrawString(ComboBox1.Text, new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(375, 200));
            e.Graphics.DrawString("Sales Report", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(350, 220));
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            PrintPreviewDialog1.Document = PrintDocument1;
            PrintPreviewDialog1.ShowDialog();
        }
    }
}
