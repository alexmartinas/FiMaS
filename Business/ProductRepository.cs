using Data.Domain.Interfeces;
using System;
using Data.Domain.Entities;
using Data.Persistence;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace Business
{
    public class ProductRepository : IProductRepository
    {
        private readonly IDatabaseContext _databaseContext;
        private readonly ILogger _logger;

        public ProductRepository(IDatabaseContext context, ILoggerFactory loggerFactory)
        {
            _databaseContext = context;
            _logger = loggerFactory.CreateLogger("ProductRepository");
        }

        public Product AddProduct(Product product)
        {
            _databaseContext.Products.Add(product);
            _databaseContext.SaveChanges();

            return product;
        }

        public void DeleteProduct(Guid productId)
        {
            var product = GetProductById(productId);
            _databaseContext.Products.Remove(product);
            _databaseContext.SaveChanges();
        }

        public Product GetProductById(Guid productId)
        {
            return _databaseContext.Products.FirstOrDefault(p => p.ProductId == productId);
        }

        public IQueryable<Product> GetProductsBoughtAt(DateTime date)
        {
            return _databaseContext.Products.Where(p => p.BoughtAt == date);
        }

        public IQueryable<Product> GetProductsBoughtBetween(DateTime startDate, DateTime endDate)
        {
            return _databaseContext.Products.Where(p => p.BoughtAt >= startDate && p.BoughtAt <= endDate);
        }

        public IQueryable<Product> GetProductsByCategory(string category)
        {
            return _databaseContext.Products.Where(p => p.Category == category);
        }

        public IQueryable<Product> GetProductsByName(string name)
        {
            return _databaseContext.Products.Where(p => p.Name == name);
        }

        public IQueryable<Product> GetProductsByProvider(string provider)
        {
            return _databaseContext.Products.Where(p => p.Provider == provider);
        }

        public IQueryable<Product> GetProducts()
        {
            return _databaseContext.Products;
        }

        public void UpdateProduct(Product product)
        {
            try
            {
                _databaseContext.Products.Attach(product);
            }
            catch (Exception exp)
            {
                _logger.LogError($"Error in {nameof(UpdateProduct)}: " + exp.Message);
            }
        }
    }
}
