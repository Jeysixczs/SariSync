using Microsoft.Extensions.DependencyInjection;
using SariSariStore.Admin.View;
using SariSariStore.Core.Services;
using SariSariStore.Core.Services.Interface;


namespace SariSariStore.Admin
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {       
            ApplicationConfiguration.Initialize(); 
            Application.Run(new LoadingForm());
        }
       
    }
}