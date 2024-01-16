using Microsoft.VisualBasic.ApplicationServices;

namespace LogicGateCircuitMakerMenu
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            ApplicationConfiguration.Initialize();
            if (args.Length > 0)
            {
                Form2 f2 = new();
                f2.SetUserID(int.Parse(args[0]));
                Application.Run(f2);
            }
            else
                Application.Run(new Form1());
        }
    }
}