using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace UI
{
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
          
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var host = CreateHostBuilder().Build();
            ServiceProvider = host.Services;

            
            Application.Run(ServiceProvider.GetRequiredService<MainForm>());
           
        }
        public static IServiceProvider ServiceProvider {  get; private set; }
        static IHostBuilder CreateHostBuilder()
        {
            return Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    services.AddTransient<ICustomerService, CustomerManager>();
                    services.AddTransient<ICustomerDal, EfCustomerDal>();
                    services.AddTransient<IVehicleDal,EfVehicleDal>();
                    services.AddTransient<IVehicleService,VehicleManager>();
                    services.AddTransient<ITreatmentService,ITServiceManager>();
                    services.AddTransient<ITServiceDal,EfTServiceDal>();
                    services.AddTransient<InvoiceService, InvoiceManager>();
                    services.AddTransient<InvoiceDal, EfInvoiceDal>();
                    services.AddTransient<InvoiceDetailService,InvoiceDetailManager>();
                    services.AddTransient<InvoiceDetailDal,EfInvoiceDetailDal>();
                    services.AddTransient<FrmCustomer>();
                    services.AddTransient<FrmCustomerSearch>();
                    services.AddTransient<FrmVehicle>();
                    services.AddTransient<FrmVehicleSearch>();
                    services.AddTransient<MainForm>();
                });
        }
    }
}