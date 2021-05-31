using Bingo.Domain.Contracts;
using Bingo.Domain.Repositories;
using Bingo.Infraestructura;
using Bingo.Infraestructura.Base;
using Bingo.Infraestructura.System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using projAspAngular.hubs;
using System.Net;
using WebSocket.HubConfig;

namespace projAspAngular
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            var connectionString = Configuration.GetConnectionString("BingoContext");//obtiene la configuracion del appsettitgs

            services.AddDbContext<BingoContext>(opt => opt.UseMySQL(connectionString, b => b.MigrationsAssembly("WebSocket")));

            services.AddScoped<IUnitOfWork, UnitOfWork>(); //Crear Instancia por peticion IJugadorRepository
            services.AddScoped<ICartonRepository, CartonRepository>(); //Crear Instancia por peticion
            services.AddScoped<IDbContext, BingoContext>(); //Crear Instancia por peticion
            services.AddScoped<IEmailSender, SendgridSender>(); //Crear Instancia por peticion
            services.AddScoped<IJugadorRepository, JugadorRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IEventoBingoRepository, EventoBingoRepository>();



            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder => builder
                .WithOrigins("http://localhost:4200")
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials()
                );
            });

            services.Configure<ForwardedHeadersOptions>(options =>
            {
                options.KnownProxies.Add(IPAddress.Parse("10.0.0.100"));
            });
            services.AddControllersWithViews();
            services.AddSignalR();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Bingo.WebApi", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Banco.WebApi v1"));
            }
            else
            {
                app.UseForwardedHeaders(new ForwardedHeadersOptions
                {
                    ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
                });
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            //app.UseHttpsRedirection();
            app.UseCors("CorsPolicy");

            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
                //endpoints.MapControllers();
                endpoints.MapHub<ChatHub>("/chat");
                endpoints.MapHub<PartidaHub>("/partida_jugando");

            });

        }
    }
}
