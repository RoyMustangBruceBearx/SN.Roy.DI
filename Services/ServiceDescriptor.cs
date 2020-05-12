using Microsoft.Extensions.DependencyInjection;
using SN.Roy.DI.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SN.Roy.DI.Services
{

    public class ServiceDescriptor
    {
        private Type serviceType;
        private Type implementationType;
        private ServiceLifetime lifetime;

        public ServiceDescriptor(Type serviceType, Type implementationType, ServiceLifetime lifetime)
        {
            this.serviceType = serviceType;
            this.implementationType = implementationType;
            this.lifetime = lifetime;
        }

        private static IDIServiceCollection Add(
          IDIServiceCollection collection,
          Type serviceType,
          Type implementationType,
          ServiceLifetime lifetime)
        {
            var descriptor = new ServiceDescriptor(serviceType, implementationType, lifetime);
            collection.Add(descriptor);
            return collection;
        }
    }
}
