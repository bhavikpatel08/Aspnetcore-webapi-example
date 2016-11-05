using AspnetCoreWebAPI.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspnetCoreWebAPI.Models
{
    public class ProductRepository : IProductRepository, IDisposable
    {
        private readonly DataContext DbContext;

        public ProductRepository(DataContext Context)
        {
            DbContext = Context;
        }

        public IEnumerable<Product> GetProducts(int pageSize, int pageNumber, string name)
        {
            var query = DbContext.Set<Product>().AsQueryable().Skip((pageNumber - 1) * pageSize).Take(pageSize);

            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(item => item.Name.ToLower().Contains(name.ToLower()));
            }

            return query;
        }

        public Product GetProduct(int? id)
        {
            return DbContext.Set<Product>().FirstOrDefault(item => item.ProductID == id);
        }

        public Product AddProduct(Product entity)
        {
            entity.ProductNumber = DateTime.Now.Ticks.ToString();
            entity.CreatedDate = DateTime.Now;
            entity.IsActive = true;
            DbContext.Set<Product>().Add(entity);

            DbContext.SaveChanges();

            return entity;
        }

        public Product UpdateProduct(int? id, Product changes)
        {
            var entity = GetProduct(id);

            if (entity != null)
            {
                entity.Name = changes.Name;
                entity.ProductNumber = changes.ProductNumber;

                DbContext.SaveChanges();
            }

            return entity;
        }

        public Product DeleteProduct(int? id)
        {
            var entity = GetProduct(id);

            if (entity != null)
            {
                DbContext.Set<Product>().Remove(entity);

                DbContext.SaveChanges();
            }

            return entity;
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this.DbContext != null)
                {
                    this.DbContext.Dispose();
                }
            }
        }
    }
}
