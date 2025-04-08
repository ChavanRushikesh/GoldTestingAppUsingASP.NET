namespace Gold_Testing_App
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {            
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());//this is done for testing each form    home
        }
    }
}