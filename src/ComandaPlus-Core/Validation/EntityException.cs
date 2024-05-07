using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComandaPlus_Core.Validation
{
    public class EntityException : Exception
    {
        public EntityException(string error) : base(error) { }

        public static void When(bool hasError, string error)
        {
            if (hasError)
                throw new EntityException(error);
        }
    }
}
