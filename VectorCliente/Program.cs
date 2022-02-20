using BlazorAnimate;
using Blazored.LocalStorage;
using Blazored.SessionStorage;
using Blazored.Toast;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Syncfusion.Blazor;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Tewr.Blazor.FileReader;
using VectorCliente.Services;
using VectorCliente.Services.IServices;

namespace VectorCliente
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.Configuration.GetValue<string>("BaseAPIUrlLocal")) });
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense(builder.Configuration.GetValue<string>("LicenciaSynfusion"));

            builder.Services.AddSingleton<HubConnection>(sp =>
            {
                var navigationManager = sp.GetRequiredService<NavigationManager>();
                return new HubConnectionBuilder()
                  .WithUrl(navigationManager.ToAbsoluteUri($"{builder.Configuration.GetValue<string>("BaseAPIUrlLocal")}/escalafonHubs"))
                  .WithAutomaticReconnect()
                  .Build();
            });

            builder.Services.AddScoped<IServiceUsuario, ServiceUsuario>();
            builder.Services.AddScoped<IServiceMesaOperativa, ServiceMesaOperativa>();
            builder.Services.AddScoped<IServiceRol, ServiceRol>();
            builder.Services.AddScoped<IServiceFuncionario, ServiceFuncionario>();
            builder.Services.AddScoped<IServiceCliente, ServiceCliente>();
            builder.Services.AddScoped<IServiceServicio, ServiceServicio>();
            builder.Services.AddScoped<IServiceRubro, ServiceRubro>();
            builder.Services.AddScoped<IServiceDataEscalafon, ServiceDataEscalafon>();
            builder.Services.AddScoped<IServicePrefFunServicio, ServicePrefFunServicio>();
            //builder.Services.AddScoped<IServiceDataEscalafonOperativo, ServiceDataEscalafonOperativo>();
            builder.Services.AddScoped<ServiceEscalafon>();
            //builder.Services.AddScoped<ServiceEscalafonOperativo>();
            builder.Services.AddScoped<ServiceInicializar>();
            builder.Services.AddScoped<ServiceImportar>();

            builder.Services.AddBlazoredToast();

            builder.Services.Configure<AnimateOptions>(options =>
            {
                options.Animation = Animations.FadeDown;
                options.Duration = TimeSpan.FromMilliseconds(500);
            });

            builder.Services.AddSyncfusionBlazor();
            builder.Services.AddBlazoredLocalStorage();
            builder.Services.AddBlazoredSessionStorage();
            builder.Services.AddFileReaderService(options => options.UseWasmSharedBuffer = true);    

            await builder.Build().RunAsync();
        }
    }
}
