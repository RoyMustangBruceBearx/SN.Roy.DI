using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static SN.Roy.DI.IServices.IOperations;

namespace SN.Roy.DI.Services
{
    public class OperationService
    {
        public OperationService(
       IOperationTransient transientOperation,
       IOperationScoped scopedOperation,
       IOperationSingleton singletonOperation,
       IOperationSingletonInstance instanceOperation)
        {
            _transientOperation = transientOperation;
            _scopedOperation = scopedOperation;
            _singletonOperation = singletonOperation;
            _singletonInstanceOperation = instanceOperation;
        }
        public IOperationTransient _transientOperation { get; }
        public IOperationScoped _scopedOperation { get; }
        public IOperationSingleton _singletonOperation { get; }
        public IOperationSingletonInstance _singletonInstanceOperation { get; }
    }
}
