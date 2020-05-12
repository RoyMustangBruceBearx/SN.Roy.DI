using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SN.Roy.DI.IServices
{
    public interface IDIServiceCollection : IList<ServiceDescriptor>
    {
        void Add(Services.ServiceDescriptor descriptor);
    }

}
