using Data.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Domain.Interfeces
{
    interface IProductRepository
    {
        IReadOnlyList<Product> getProductsByProvider(string provider);
        IReadOnlyList<Product> getProductsByName(string name);
        IReadOnlyList<Product> getProductsBoughtAt(DateTime date);
        IReadOnlyList<Product> getProductsBoughtBetween(DateTime startDate, DateTime endDate);
        IReadOnlyList<Product> getProductsByCategory(string category);
        void updateProduct(Guid id, Product product);
        void deleteProduct(Guid productId);
        void addProduct(double price, string name, DateTime boughtAt, string provider, string category, double quantity, Guid ownerId);

    }
}
