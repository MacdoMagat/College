using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ACE_Hardware
{
    public partial class ReportsForm : Form
    {

        private ReportsSalesReportForm salesreport = new ReportsSalesReportForm();
        private ReportsProductSalesReportForm productsalesreport = new ReportsProductSalesReportForm();

        public ReportsForm()
        {
            InitializeComponent();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Program.mainFormInstance.Show();
            this.Close();
        }

        private void ReportsForm_Load(object sender, EventArgs e)
        {
            salesreport.TopLevel = false;
            salesreport.Dock = DockStyle.Fill;
            productsalesreport.TopLevel = false;
            productsalesreport.Dock = DockStyle.Fill;
            Panel1.Controls.Add(salesreport);
            salesreport.Show();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Panel1.Controls.Clear();
            Panel1.Controls.Add(salesreport);
            salesreport.Show();
        }

        private void ReportsForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.mainFormInstance.Show();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            Panel1.Controls.Clear();
            Panel1.Controls.Add(productsalesreport);
            productsalesreport.Show();
        }
    }
}
