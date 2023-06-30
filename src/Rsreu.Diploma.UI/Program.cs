namespace Rsreu.Diploma;

using Microsoft.Extensions.Configuration;

internal static class Program
{
    public static IConfiguration Configuration;

    [STAThread]
    static void Main()
    {
        var builder = new ConfigurationBuilder();
        builder.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
        Configuration = builder.Build();

        ApplicationConfiguration.Initialize();
        Application.Run(new MainForm());
    }
}