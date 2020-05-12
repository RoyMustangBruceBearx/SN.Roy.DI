using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SN.Roy.DI.IServices
{
    public class SysLogService : ILogService
    {
        public Guid _guid;

        public SysLogService()
        {
            _guid = Guid.NewGuid();
        }

        void ILogService.LogInfomation(string info)
        {
            Console.WriteLine($" ==> SysLog : This Guid is :{_guid}");
            Console.WriteLine($" ==> SysLog : {DateTime.Now.ToString()}:{info}");
        }
    }
}
