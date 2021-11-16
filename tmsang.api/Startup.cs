using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using tmsang.application;
using tmsang.infra;

namespace tmsang.api
{
    public class Startup
    {        
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

            File.AppendAllText("Files/TrackMigration/test.txt", $"{DateTime.Now}: Begin Startup...\n");
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            File.AppendAllText("Files/TrackMigration/test.txt", $"{DateTime.Now}: Begin ConfigureServices...\n");

            // TODO: add dbcontext cho MySQL
            string mySqlConnectionStr = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContextPool<MyDbContext>(options => options.UseMySql(mySqlConnectionStr, ServerVersion.AutoDetect(mySqlConnectionStr)));
            // services.AddDbContext<MyDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("ReleasesDb")));

            // TODO: add UnitOfWork
            services.AddUnitOfWork<MyDbContext>();

            // add Cors
            services.AddCors();

            services.AddControllers(options => {
                options.Filters.Add(typeof(UnitOfWorkTransactionFilter));
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "tmsang.api", Version = "v1" });
            });

            //services.AddHttpContextAccessor();
            services.AddGrabCustomServices(Configuration);

            services.AddSignalR();
            //services.AddSignalR(options => { options.KeepAliveInterval = TimeSpan.FromSeconds(5); }).AddMessagePackProtocol();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            File.AppendAllText("Files/TrackMigration/test.txt", $"{DateTime.Now}: Begin Configure...\n");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "tmsang.api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            // global cors policy
            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            // custom jwt auth middleware
            app.UseMiddleware<JwtMiddleware>();
            // app.ConfigureExceptionHandler();                 // TODO

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<SignalrHub>("/signalr");
            });

            // toi can mot cai class, luc ban dau init chay se load lieu vao day + sau khi dang ky service trong container
            new Initialization(app);

        }
    }
}
