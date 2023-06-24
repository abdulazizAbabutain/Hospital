using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string massge)
            : base(massge)
        {

        }

        public NotFoundException(string key, object value)
            : base($"The property {key} with id {value} dose not exists")
        {

        }
    }
}
