using ComandaPlus_Core.Entities;
using ComandaPlus_Core.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComandaPlus_Core.Models
{
    public sealed class Product : BaseEntity
    {
        
        [Column("PRD_TITLE")]
        public string Title { get; private set; }

        [Column("PRD_DESCRIPTION")]
        public string Description { get; private set; }

        [Column("PRD_IMAGE")]
        public byte[] Image { get; private set; }

        [Column("PRD_PRICE")]
        public decimal Price { get; private set; }

        [Column("PRD_STOCK")]
        public int Stock { get; private set; }

        public Product(string title, string description, decimal price, int stock, byte[] image)
        {
            ValidateData(title, description, image, price, stock);

            Title = title;
            Description = description;
            Image = image;
            Price = price;
            Stock = stock;
        }

        public void Update(string title, string description, decimal price, int stock, byte[] image)
        {
            ValidateData(title, description, image, price, stock);

            Title = title;
            Description = description;
            Image = image;
            Price = price;
            Stock = stock;
        }

        private void ValidateData(string title, string description, byte[] image, decimal price, int stock)
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

            EntityException
                .When(price < 0, "Invalid price value");

            EntityException
                .When(stock < 0, "Invalid stock value");
        }
    }
}
