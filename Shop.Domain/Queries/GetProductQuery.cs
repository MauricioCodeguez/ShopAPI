﻿using System;

namespace Shop.Domain.Queries
{
    public class GetProductQuery
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public DateTime? Updated { get; set; }
    }
}