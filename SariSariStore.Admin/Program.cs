using Microsoft.Extensions.DependencyInjection;
using SariSariStore.Admin.View;
using SariSariStore.Core.Services;
using SariSariStore.Core.Services.Interface;


namespace SariSariStore.Admin
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        public static IServiceProvider ServiceProvider { get; private set; }

        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            //var services = new ServiceCollection();
            //ConfigureServices(services);
            //ServiceProvider = services.BuildServiceProvider();

            //var mainForm = ServiceProvider.GetRequiredService<MainForm>();
            //Application.Run(mainForm);
            Application.Run(new DashboardForm());
        }


        private static void ConfigureServices(ServiceCollection services)
        {
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<MainForm>();
        }
    }
}