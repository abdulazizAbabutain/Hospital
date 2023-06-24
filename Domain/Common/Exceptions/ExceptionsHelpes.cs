using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Common.Exceptions
{
    public static class ExceptionsHelpes
    {
        public static void ThrowIfNull(this object val, string name)
        {
            if(val is null)
                throw new ArgumentNullException(nameof(name));
        }
    }
}
