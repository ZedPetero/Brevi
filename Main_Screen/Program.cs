namespace Main_Screen;
    using System;
    using System.Windows.Forms;

    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            // show the splash screen first; when it closes, start the main form
            using (var splash = new splash_screen())
            {
                splash.ShowDialog();
            }

            Application.Run(new Form1());
        }
    }
