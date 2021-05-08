using System;
using System.Text;
using Domain.Contract;
using Infrastructure;
using Infrastructure.Base;
using Infrastructure.Inicializacion;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace WebApi
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
            services.AddControllers();
            services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new OpenApiInfo {Title = "WebApi", Version = "v1"}); });

            //services.AddDbContext<MyContext>(opt => opt.Use(Configuration.GetConnectionString("Postgres"),
            //   o => o.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery)));
            services.AddDbContext<MyContext>(opt => opt.UseInMemoryDatabase(databaseName: "TiendaDevZeros"));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IDbContext, MyContext>();
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
            });
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(
                    options =>
                        options.TokenValidationParameters = new TokenValidationParameters
                        {
                            ValidateIssuer = true,
                            ValidateAudience = true,
                            ValidateLifetime = true,
                            ValidateIssuerSigningKey = true,
                            ValidIssuer = "yourdomain.com",
                            ValidAudience = "yourdomain.com",
                            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration.GetSection("Token").Value)),
                            ClockSkew = TimeSpan.Zero
                        });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebApi v1"));
            }
            app.UseCors("CorsPolicy");
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
            InicializarDatabase(app,env);
        }

        public static void InicializarDatabase(IApplicationBuilder app,IWebHostEnvironment env)
        {
            using var scope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope();
            //scope.ServiceProvider.GetRequiredService<MyContext>().Database.Migrate();
            var contex = scope.ServiceProvider.GetRequiredService<MyContext>();
            if (env.IsDevelopment())
            {
                var inicializador = new Inicializador(contex);
                inicializador.inicializar();
            }
        }
    }
}