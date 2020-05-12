using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static SN.Roy.DI.IServices.IOperations;

namespace SN.Roy.DI.Services
{
    public class Operation : IOperationTransient, IOperationScoped, IOperationSingleton, IOperationSingletonInstance
    {
        private Guid _guid;
        public Operation() 
        {
            _guid = Guid.NewGuid();
        }
        public Operation(Guid guid)
        {
            _guid = guid;
        }
        public Guid OperationId => _guid;
    }
}
