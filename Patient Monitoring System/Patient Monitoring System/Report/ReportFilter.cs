using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Patient_Monitoring_System.Report
{
    public partial class ReportFilter : Form
    {
        public ReportFilter()
        {
            InitializeComponent();
        }

        private void cboPreriodicity_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboPreriodicity.Text.Equals("Custom"))
            {
                lblFrom.Text = "From:";
                lblTo.Text = "To:";
                lblTo.Visible = true;
                dtpTo.Enabled = true;
                dtpTo.Visible = true;
                dtpFrom.FormatCustom = "dddd - MMMM dd, yyyy";
            }
            else if (cboPreriodicity.Text.Equals("Daily"))
            {
                lblTo.Visible = false;
                dtpFrom.FormatCustom = "dddd - MMMM dd, yyyy";
                lblFrom.Text = "Day";
                dtpTo.Enabled = false;
                dtpTo.Visible = false;
            }
            else if (cboPreriodicity.Text.Equals("Weekly"))
            {
                lblTo.Visible = false;
                dtpFrom.FormatCustom = "dddd - MMMM dd, yyyy";
                lblFrom.Text = "One Week From:";
                dtpTo.Enabled = false;
                dtpTo.Visible = false;
            }
            else if (cboPreriodicity.Text.Equals("Monthly"))
            {
                lblTo.Visible = false;
                dtpFrom.FormatCustom = "MMMM yyyy";
                lblFrom.Text = "Month:";
                dtpTo.Enabled = false;
                dtpTo.Visible = false;
            }
            else if (cboPreriodicity.Text.Equals("Yearly"))
            {
                lblTo.Visible = false;
                dtpFrom.FormatCustom = "yyyy";
                lblFrom.Text = "Year:";
                dtpTo.Enabled = false;
                dtpTo.Visible = false;
            }
        }
    }
}
