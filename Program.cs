using System;
using System.Windows.Forms;
using pencatatanwarga;

namespace AplikasiPencatatanWarga
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Inisialisasi Database
            DatabaseManager dbManager = new DatabaseManager();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}