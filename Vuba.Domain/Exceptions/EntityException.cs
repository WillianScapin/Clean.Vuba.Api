using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vuba.Domain.Exceptions
{
    public class EntityException : AppException
    {
        public EntityException(string message) : base(message, "422")
        {
        }
    }
}
