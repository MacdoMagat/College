using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ACE_Hardware
{
    static class Program
    {

        public static string connstring = "Server=192.168.43.222;User Id=ubuntu;Password=ubuntu;Database=pos";

        public static LoginForm login;

        public static AdminForm adminFormInstance;
        public static ExitForm exitFormInstance;
        public static InventoryAddQuantityForm inventoryAddQuantityFormInstance;
        public static InventoryEditCategoryAddForm inventoryEditCategoryAddFormInstance;
        public static InventoryEditCategoryEditForm inventoryEditCategoryEditFormInstance;
        public static InventoryEditCategoryForm inventoryEditCategoryFormInstance;
        public static InventoryForm inventoryFormInstance;
        public static LogsForm logsFormInstance;
        public static MainForm mainFormInstance;
        public static POSForm posFormInstance;
        public static ReportsForm reportsFormInstance;
        

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]

        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new POSForm());

            //adminFormInstance = new AdminForm();
            //exitFormInstance = new ExitForm();
            //inventoryAddQuantityFormInstance = new InventoryAddQuantityForm();
            //inventoryEditCategoryAddFormInstance = new InventoryEditCategoryAddForm();
            //inventoryEditCategoryEditFormInstance = new InventoryEditCategoryEditForm();
            //inventoryEditCategoryFormInstance = new InventoryEditCategoryForm();
            //inventoryFormInstance = new InventoryForm();
            //logsFormInstance = new LogsForm();
            mainFormInstance = new MainForm();
            //posFormInstance = new POSForm();
            //reportsFormInstance = new ReportsForm();

            Application.Run(login = new LoginForm());
        }
    }
}
