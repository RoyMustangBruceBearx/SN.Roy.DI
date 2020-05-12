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


            // ���MVC����
            services.AddControllersWithViews();

            // ע�����

            #region ����ע��

            #region ע�᷽��ע��
            // Singleton���������񣬴ӵ�ǰ���������л�ȡ������͵�ʵ����Զ��ͬһ��ʵ����
            // Scoped��ÿ�����������������ڴ���һ��ʵ����
            // Transient��ÿһ��������񶼴���һ����ʵ����
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
