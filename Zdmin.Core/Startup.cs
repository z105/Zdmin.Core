using FreeSql;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zdmin.Core.Models.Fsql;
using Zdmin.Core.Models.Base;

namespace Admin.Core
{
    public class Startup
    {
        private readonly string connectionString = @"Data Source=|DataDirectory|F:\ASP.NET Core\MySource\Zdmin.Core\zdmin.db; Pooling=true;Min Pool Size=1";
        private readonly string DefaultCorsPolicyName = "Allow";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            #region Cors 跨域
            services.AddCors(options =>
            {
                options.AddPolicy(DefaultCorsPolicyName, policy =>
                {
                    policy.WithOrigins("http://192.168.1.158:10001")
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials();
                });

            });
            #endregion

            services.AddControllers();


            services.AddAuthentication();

            // FreeSql
            var fsqlBuilder = new FreeSqlBuilder()
                .UseConnectionString(FreeSql.DataType.Sqlite, connectionString)
                .UseAutoSyncStructure(true) //自动迁移实体的结构到数据库
                .UseLazyLoading(false)      
                .UseNoneCommandParameter(true); // 不使用sql参数化执行，监控sql执行所用。 

            fsqlBuilder.UseMonitorCommand(cmd => { }, (cmd, traceLog) =>
            {
                Console.WriteLine($"{cmd.CommandText}\r\n");
            });

            var fsql = fsqlBuilder.Build();
            fsql.GlobalFilter.Apply<ISoftDelete>("SoftDelete", a => a.IsDeleted == false);
            fsql.Aop.AuditValue += (s, e) =>
            {
                // var user = services.BuildServiceProvider().GetService<IUser>();
            };
            services.AddSingleton<IFreeSql>(fsql);
            services.AddFreeRepository(null, this.GetType().Assembly);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(DefaultCorsPolicyName);

            app.UseRouting();

            app.UseAuthorization();

        

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
