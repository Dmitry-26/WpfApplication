using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public class NodeNotFoundException : ApplicationException
    {
        public NodeNotFoundException(string message)
            :base(message)
        {
        }
    }
}