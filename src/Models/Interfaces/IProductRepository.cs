using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspnetCoreWebAPI.Models.Interfaces
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetProducts(int pageSize, int pageNumber, string name);

        Product GetProduct(int? id);

        Product AddProduct(Product entity);

        Product UpdateProduct(int? id, Product changes);

        Product DeleteProduct(int? id);
    }
}
