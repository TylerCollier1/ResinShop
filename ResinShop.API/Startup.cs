using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using ResinShop.Core.Interfaces.DAL;
using ResinShop.DAL;
using ResinShop.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResinShop.API
{
    public class Startup
    {
        private const string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options => {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = "http://localhost:2000",
                        ValidAudience = "http://localhost:2000",
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("KeyForSignInSecret@1234"))
                    };
                    services.AddMvc().SetCompatibilityVersion(Microsoft.AspNetCore.Mvc.CompatibilityVersion.Version_3_0);
                });


            services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                    policy =>
                    {
                        policy.AllowAnyHeader();
                        policy.WithOrigins("*", "http://localhost:3000");
                        policy.AllowAnyMethod();
                    });
            });


            services.AddControllers();

            ConfigProvider cp = new ConfigProvider();
            DBFactory dbFactory = new DBFactory(cp.Config);

            services.AddTransient<IArtRepository, ArtRepository>(s => new ArtRepository(dbFactory));
            services.AddTransient<IColorRepository, ColorRepository>(s => new ColorRepository(dbFactory));
            services.AddTransient<ICustomerRepository, CustomerRepository>(s => new CustomerRepository(dbFactory));
            services.AddTransient<IOrderRepository, OrderRepository>(s => new OrderRepository(dbFactory));
            services.AddTransient<IMaterialRepository, MaterialRepository>(s => new MaterialRepository(dbFactory));
            services.AddTransient<IReportsRepository, ReportsRepository>(s => new ReportsRepository(dbFactory));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseCors(MyAllowSpecificOrigins);

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}