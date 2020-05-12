using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SN.Roy.DI.Model
{
    public class DIResultDto
    {
        public string ScopedId { get; set; }

        public string TransientId { get; set; }

        public string SingletonId { get; set; }

    }
}
