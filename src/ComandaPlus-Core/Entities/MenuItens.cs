using ComandaPlus_Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComandaPlus_Core.Entities
{
    public class MenuItens : BaseEntity
    {
        [Column("MNI_MNU_ID")]
        public int MenuId { get; private set; }
        public Menu Menu { get; private set; }

        [Column("MNI_PRD_ID")]
        public int ProductId {  get; private set; }
        public Product Product { get; private set; }
    }
}
