using Microsoft.Extensions.DependencyInjection;
using SN.Roy.DI.Model;
using SN.Roy.DI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static SN.Roy.DI.IServices.IOperations;

namespace SN.Roy.DI.Try
{
    public class DITestHelper
    {

        public void DifSignletone()
        {
            var services = new ServiceCollection();
            // 默认构造
            services.AddSingleton<IOperationSingleton, Operation>();
            // 自定义传入Guid空值
            services.AddSingleton<IOperationSingleton>(
              new Operation(Guid.Empty));
            // 自定义传入一个New的Guid
            services.AddSingleton<IOperationSingleton>(
              new Operation(Guid.NewGuid()));

            var provider = services.BuildServiceProvider();

            // 输出singletone1的Guid
            var singletone1 = provider.GetService<IOperationSingleton>();
            Console.WriteLine($"signletone1: {singletone1.OperationId}");

            // 输出singletone2的Guid
            var singletone2 = provider.GetService<IOperationSingleton>();
            Console.WriteLine($"signletone2: {singletone2.OperationId}");
            Console.WriteLine($"singletone1 == singletone2 ? : { singletone1 == singletone2 }");
        }

        public void DifScope()
        {
            var services = new ServiceCollection()
                .AddScoped<IOperationScoped, Operation>()
                .AddTransient<IOperationTransient, Operation>()
                .AddSingleton<IOperationSingleton, Operation>();

            var provider = services.BuildServiceProvider();
            using (var scope1 = provider.CreateScope())
            {
                var p = scope1.ServiceProvider;

                var scopeobj1 = p.GetService<IOperationScoped>();
                var transient1 = p.GetService<IOperationTransient>();
                var singleton1 = p.GetService<IOperationSingleton>();

                var scopeobj2 = p.GetService<IOperationScoped>();
                var transient2 = p.GetService<IOperationTransient>();
                var singleton2 = p.GetService<IOperationSingleton>();

                Console.WriteLine(
                    $"scope1: { scopeobj1.OperationId.ToString("N")}," +
                    $"transient1: {transient1.OperationId.ToString("N")}, " +
                    $"singleton1: {singleton1.OperationId.ToString("N")}");

                Console.WriteLine($"scope2: { scopeobj2.OperationId.ToString("N")}," +
                    $"transient2: {transient2.OperationId.ToString("N")}, " +
                    $"singleton2: {singleton2.OperationId.ToString("N")}");
            }
        }


        public List<DIResultDto> GetDI_GUID()
        {
            List<DIResultDto> dIResultDto = new List<DIResultDto>();
            var services = new ServiceCollection()
                 .AddScoped<IOperationScoped, Operation>()
                 .AddTransient<IOperationTransient, Operation>()
                 .AddSingleton<IOperationSingleton, Operation>();

            var provider = services.BuildServiceProvider();
            using (var scope1 = provider.CreateScope())
            {
                var p = scope1.ServiceProvider;

                var scopeobj1 = p.GetService<IOperationScoped>();
                var transient1 = p.GetService<IOperationTransient>();
                var singleton1 = p.GetService<IOperationSingleton>();

                var scopeobj2 = p.GetService<IOperationScoped>();
                var transient2 = p.GetService<IOperationTransient>();
                var singleton2 = p.GetService<IOperationSingleton>();


                DIResultDto dIResultDtoA = new DIResultDto();
                dIResultDtoA.ScopedId = scopeobj1.OperationId.ToString("N");
                dIResultDtoA.TransientId = transient1.OperationId.ToString("N");
                dIResultDtoA.SingletonId = singleton1.OperationId.ToString("N");

                DIResultDto dIResultDtoB = new DIResultDto();
                dIResultDtoB.ScopedId = scopeobj2.OperationId.ToString("N");
                dIResultDtoB.TransientId = transient2.OperationId.ToString("N");
                dIResultDtoB.SingletonId = singleton2.OperationId.ToString("N");

                dIResultDto.Add(dIResultDtoA;
                dIResultDto.Add(dIResultDtoB);
            }
            return dIResultDto;
        }
    }
}
