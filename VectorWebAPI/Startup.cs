using AccesoDatos;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.AspNetCore.Http;
using Negocio.IRepositorios;
using Negocio.Repositorios;
using System.Reflection;
using System.IO;
using VectorWebAPI.Properties.EscalafonHub;

namespace VectorWebAPI
{
    public class Startup
    {
        private readonly string _MyCors = "MyCors"; 
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var key = Encoding.ASCII.GetBytes(Configuration.GetValue<string>("SecretKey"));

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            services.AddCors(options =>
            {
                options.AddPolicy(_MyCors, builder =>
                {
                    builder.WithOrigins("http://localhost:52280")
                    .AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod();
                });
            });

            services.AddSignalR();

            services.AddResponseCompression(opts =>
            {
                opts.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(
                    new[] { "application/octet-stream" });
            });

            services.AddDbContext<AppDbContext>(options =>
                      options.UseSqlServer(Configuration.GetConnectionString("LocalConnection")),
                                            ServiceLifetime.Scoped);

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddScoped<IRepoUsuario, RepoUsuario>();
            services.AddScoped<IRepoRol, RepoRol>();
            services.AddScoped<IRepoMesaOperativa, RepoMesaOperativa>();
            services.AddScoped<IRepoTipoContrato, RepoTipoContrato>();
            services.AddScoped<IRepoFuncionario, RepoFuncionario>();
            services.AddScoped<IRepoCliente, RepoCliente>();
            services.AddScoped<IRepoServicio, RepoServicio>();
            services.AddScoped<IRepoRubro, RepoRubro>();
            services.AddScoped<RepoPlanificacionEscalafon>();
            services.AddScoped<IRepoAusencia, RepoAusencia>();
            //services.AddScoped<RepoEscalafonOperativo>();
            services.AddScoped<IRepoRegistroHorario, RepoRegistroHorario>();
            services.AddScoped<IInicializacion, Inicializacion>();
            services.AddScoped<RepoPlanificacionDiaria>();
            services.AddScoped<IRepoPreferenciaFuncionarioServicio, RepoRepoPreferenciaFuncionarioServicio>();

            //para utilizar la ruta de archivos del servidor
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            //para traer los datos de configuracion de mail desde el appsettings.json
            //services.Configure<ConfigMail>(Configuration.GetSection("MailConnection"));

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "VectorWebAPI", Version = "v1" });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "VectorWebAPI v1"));
            }
            //creacion o acceso a la base de datos
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<AppDbContext>();
                context.Database.Migrate(); //para crear una base de datos pero no se pueden usar migraciones
            }

            app.UseStaticFiles();
            app.UseRouting();
            app.UseCors(_MyCors);
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseResponseCompression();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<EscalafonHub>("/escalafonHubs");
            });
        }
    }
}
