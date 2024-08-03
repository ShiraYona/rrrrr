using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace services
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> getProde();
        Task<List<Gift>> GetUsersAsync();

    }
}
