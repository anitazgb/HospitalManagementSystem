namespace HMS
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread] // attribute for a proper interaction with COM components
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize(); // define the application configuration
            Application.Run(new LoginForm()); // app starts with the login form
        }
    }
}