using FluentValidation;
using FluentValidation.AspNetCore;
using Flyon.Api.Validation;
using Flyon.Data.SQL;
using Flyon.Data.SQL.Migrations;
using Flyon.Data.SQL.User;
using Flyon.IData.User;
using Flyon.Data.SQL.Post;
using Flyon.IData.Post;
using Flyon.IServices.Requests;
using Flyon.IServices.User;
using Flyon.Services.User;
using Flyon.IServices.Post;
using Flyon.Services.Post;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Flyon.Api
{
    public class Startup
    {
        public IConfiguration Configuration { get;}

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
            
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<FlyonDbContext>(options => options
                .UseMySQL(Configuration.GetConnectionString("FlyonDbContext")));

            services.AddTransient<DatabaseSeed>();
            
            services.AddControllers()
                .AddNewtonsoftJson(options => {
                    options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                })
                .AddFluentValidation();
            services.AddTransient<IValidator<EditUser>, EditUserValidator>();
            services.AddTransient<IValidator<CreateUser>, CreateUserValidator>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepository, UserRepository>();

            services.AddTransient<IValidator<EditPost>, EditPostValidator>();
            services.AddTransient<IValidator<CreatePost>, CreatePostValidator>();
            services.AddScoped<IPostService, PostService>();
            services.AddScoped<IPostRepository, PostRepository>();

            services.AddApiVersioning( o =>
            {
                o.ReportApiVersions = true;
                o.UseApiBehavior = false;
            });
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();
            
            var context = serviceScope.ServiceProvider.GetRequiredService<FlyonDbContext>();
            var databaseSeed = serviceScope.ServiceProvider.GetRequiredService<DatabaseSeed>();
                
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            databaseSeed.Seed();
            
            
            app.UseRouting();
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}