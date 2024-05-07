using ComandaPlus_Core.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComandaPlus_Core.Entities
{
    public class Menu : BaseEntity
    {

        [Column("MNU_TITLE")]
        public string Title { get; private set; }

        [Column("MNU_DESCRIPTION")]
        public string Description { get; private set; }

        [Column("MNU_ACTIVE")]
        public bool Active { get; private set; }

        public Menu(string title, string description, bool active)
        {
            ValidateData(title, description);

            Title = title;
            Description = description;
            Active = active;
        }

        public void Update(string title, string description, bool active)
        {
            ValidateData(title, description);

            Title = title;
            Description = description;
            Active = active;
        }

        public void ValidateData(string title, string description)
        {

            EntityException
                .When(string.IsNullOrEmpty(title), "Invalid title. Title is required");

            EntityException
                .When(title.Length < 5, "Invalid title. Too short, minimum of 3 characters");

            EntityException
                .When(title.Length > 50, "Invalid title. Too big, maximum of 50 characters");

            EntityException
                .When(string.IsNullOrEmpty(description), "Invalid description. Title is required");

            EntityException
                .When(description.Length < 10, "Invalid description. Too short, minimum of 10 characters");

            EntityException
                .When(description.Length > 250, "Invalid description. Too big, maximum of 250 characters");
        }

    }
}
 