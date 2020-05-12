using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Nest;
using SN.Roy.DI.IServices;
using SN.Roy.DI.Services;
using static SN.Roy.DI.IServices.IOperations;

namespace SN.Roy.DI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(Microsoft.Extensions.DependencyInjection.IServiceCollection services)
        {
            services.AddControllers();


            // 添加MVC服务
            services.AddControllersWithViews();

            // 注册服务

            #region 依赖注入

            #region 注册方法注解
            // Singleton：单例服务，从当前服务容器中获取这个类型的实例永远是同一个实例；
            // Scoped：每个作用域生成周期内创建一个实例；
            // Transient：每一次请求服务都创建一个新实例；
            #endregion
            services.AddSingleton<ILogService, SysLogService>();

            //services.AddScoped<ILogService, SysLogService>();

            //services.AddTransient<ILogService, SysLogService>();

            services.AddTransient<IOperationTransient, Operation>();
            services.AddScoped<IOperationScoped, Operation>();
            services.AddSingleton<IOperationSingleton, Operation>();
            services.AddSingleton<IOperationSingletonInstance>(new Operation(Guid.Empty));
            services.AddTransient<OperationService, OperationService>();


            var serviceCollection = new ServiceCollection()
                  .AddTransient<ILogService, SysLogService>()
                  .AddSingleton<ILogService, SysLogService>()
                  .AddScoped<ILogService, SysLogService>();
            #endregion

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
