using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using SN.Roy.DI.IServices;
using SN.Roy.DI.Services;
using SN.Roy.DI.Try;
using static SN.Roy.DI.IServices.IOperations;

namespace SN.Roy.DI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        public OperationService _operationService { get; }
        public IOperationTransient _transientOperation { get; }
        public IOperationScoped _scopedOperation { get; }
        public IOperationSingleton _singletonOperation { get; }
        public IOperationSingletonInstance _singletonInstanceOperation { get; }

        private readonly ILogService _sysLog;

        public MenuController(
            OperationService operationService,
            IOperationTransient transientOperation,
            IOperationScoped scopedOperation,
            IOperationSingleton singletonOperation,
            IOperationSingletonInstance singletonInstanceOperation,
            ILogService sysLog)
        {
            _sysLog = sysLog;
            _operationService = operationService;
            _transientOperation = transientOperation;
            _scopedOperation = scopedOperation;
            _singletonOperation = singletonOperation;
            _singletonInstanceOperation = singletonInstanceOperation;
        }


        //[HttpGet("logger")
        [HttpGet]
        public IActionResult Login()
        {
            Console.WriteLine("IOperation操作:");
            Console.WriteLine("transient1:" + _transientOperation.OperationId.ToString());
            Console.WriteLine("scope1:" + _scopedOperation.OperationId.ToString());
            Console.WriteLine("singleton1:" + _singletonOperation.OperationId.ToString());
            //Console.WriteLine("实例:" + _singletonInstanceOperation.OperationId.ToString());
            Console.WriteLine("");
            Console.WriteLine("OperationService操作:");
            Console.WriteLine("transient2:" + _operationService._transientOperation.OperationId.ToString());
            Console.WriteLine("scope2:" + _operationService._scopedOperation.OperationId.ToString());
            Console.WriteLine("singleton2:" + _operationService._singletonOperation.OperationId.ToString());
            Console.WriteLine("");
            Console.WriteLine("IOperation2操作:");
            Console.WriteLine("transient3:" + _transientOperation.OperationId.ToString());
            Console.WriteLine("scope3:" + _scopedOperation.OperationId.ToString());
            Console.WriteLine("singleton3:" + _singletonOperation.OperationId.ToString());
            //Console.WriteLine("实例:" + _operationService._singletonInstanceOperation.OperationId.ToString());
            _sysLog.LogInfomation("maybe");
            return Ok("Seccuss");
        }

        //[HttpGet("logger")
        [HttpGet]
        public IActionResult TestDI()
        {
            DITestHelper dihelper = new DITestHelper();
            dihelper.DifSignletone();
            return Ok("Seccuss");
        }

        [HttpGet]
        public IActionResult TestDIScope()
        {
            DITestHelper dihelper = new DITestHelper();
            dihelper.DifScope();
            return Ok("Seccuss");
        }

    }
}