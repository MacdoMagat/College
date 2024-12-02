using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace See_Sharp__Downy_POS_
{
    public partial class MainForm : Form
    {

        public POSForm pos = new POSForm();
        public InventoryForm inventory = new InventoryForm();
        public HomeForm home = new HomeForm();

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //pos.TopLevel = false;
            inventory.TopLevel = false;
            home.TopLevel = false;
            //pos.Dock = DockStyle.Fill;
            inventory.Dock = DockStyle.Fill;
            home.Dock = DockStyle.Fill;
            panel1.Controls.Add(home);
            home.Show();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            panel1.Controls.Add(home);
            home.Show();
        }

        private void btnPOS_Click(object sender, EventArgs e)
        {
            pos.POSClicked();
            pos.ShowDialog();
            //panel1.Controls.Clear();
            panel1.Controls.Clear();
            panel1.Controls.Add(home);
            home.Show();
            //panel1.Controls.Add(pos);
        }

        private void btnInventory_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            panel1.Controls.Add(inventory);
            inventory.refreshCboCategory();
            inventory.categorySelected();
            inventory.Show();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public void inventoryRefresh()
        {
            inventory.refreshCboCategory();
            inventory.categorySelected();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
