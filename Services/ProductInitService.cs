using System.Collections.Generic;
using App.Models;

namespace App.Services
{
    public class ProductInitService : List<ProductModel>
    {
        public ProductInitService()
        {
            AddRange(new ProductModel[]{
                new ProductModel(){Id = 1, Name ="IPhone X", Price=1000},
                new ProductModel(){Id = 2, Name="Samsung", Price=500},
                new ProductModel(){Id = 3, Name="Nokia", Price=800},

            });
        }
    }
}