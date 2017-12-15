using Data.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.Domain.Interfeces
{
    public interface IProductRepository
    {
        IQueryable<Product> GetProducts();
        IQueryable<Product> GetProductsByProvider(string provider);
        IQueryable<Product> GetProductsByName(string name);
        IQueryable<Product> GetProductsBoughtAt(DateTime date);
        IQueryable<Product> GetProductsBoughtBetween(DateTime startDate, DateTime endDate);
        IQueryable<Product> GetProductsByCategory(string category);
        Product GetProductById(Guid productId);
        void UpdateProduct(Product product);
        void DeleteProduct(Guid productId);
        Product AddProduct(Product product);

    }
}
