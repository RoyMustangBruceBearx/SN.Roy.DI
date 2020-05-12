﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SN.Roy.DI.IServices
{
    public class IOperations
    {
        public interface IOperation
        {
            Guid OperationId { get; }
        }
        public interface IOperationTransient : IOperation
        {
        }
        public interface IOperationScoped : IOperation
        {
        }
        public interface IOperationSingleton : IOperation
        {
        }
        public interface IOperationSingletonInstance : IOperation
        {
        }
    }
}