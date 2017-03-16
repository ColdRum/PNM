using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace PersonalNotes
{
    //static class DataTransfer
    //{
    //    public static string v1 { get; set; }
    //    public static string v4 { get; set; }
    //    public static string v5 { get; set; }
    //}

    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
