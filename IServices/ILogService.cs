using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SN.Roy.DI.IServices
{
    public interface ILogService
    {
        void LogInfomation(string info);
    }

    //public class SysLogService : ILogService
    //{
    //    void ILogService.LogInfomation(string info)
    //    {
    //        Console.WriteLine($" ==> SysLogService : {DateTime.Now.ToString()}:{info}");
    //    }
    //}
}
