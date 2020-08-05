using Shop.Shared.Entities;
using System;

namespace Shop.Domain.Entities
{
    public class Product : Entity
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }

        public Product(
            string name,
            string description, 
            decimal price)
        {
            Name = name;
            Description = description;
            Price = price;
        }

        public void UpdateProduct(
            string name,
            string description,
            decimal price)
        {
            Name = name;
            Description = description;
            Price = price;
        }

        public override string ToString() => Name;
    }
}