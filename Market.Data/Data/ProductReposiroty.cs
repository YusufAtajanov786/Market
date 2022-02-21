using Market.Data.Data.IRepository;
using Market.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Data.Data
{
    public class ProductReposiroty : IProductRepository
    {
        public Product GetProductById(Guid id)
        {
            return new Product()
            {
                Id = id,
                Name = $"Product = {id}",
                CategoryId = new Random().Next(0, 100)
            };
        }
    }
}
