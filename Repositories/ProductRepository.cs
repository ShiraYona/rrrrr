using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class ProductRepository:IProductRepository
    {
        StoreDataBase1Context _storeDataBase1;
        public ProductRepository(StoreDataBase1Context storeDataBase1)
        {
            _storeDataBase1 = storeDataBase1;
        }

        public async Task<IEnumerable<Product>> getProde()
        {
            return   _storeDataBase1.Products.ToList();
        }
    }
}
