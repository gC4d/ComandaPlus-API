using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComandaPlus_Core.Entities
{
    public abstract class BaseEntity
    {
        public int Id { get; private set; }
    }
}
