using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vuba.Domain.Entities
{
    public sealed class Roles
    {
        public string Standard { get; private set; } = "default";
        public string Premium { get; private set; } = "admin";
    }
}
