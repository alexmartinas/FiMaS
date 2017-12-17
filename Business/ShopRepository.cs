using System;
using System.Collections.Generic;
using System.Linq;
using Data.Domain.Entities;
using Data.Domain.Interfeces;
using Data.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Business
{
    public class ShopRepository : IShopRepository
    {
        private readonly IDatabaseContext _databaseContext;

        public ShopRepository(IDatabaseContext databaseContext)
        {
            _databaseContext = databaseContext; 
        }

        public IReadOnlyList<Shop> GetShopsByCity(string city) => _databaseContext
                .Cities
                .Include(t => t.Shops)
                    .ThenInclude(t => t.City)
                        .ThenInclude(t => t.Country)
                .FirstOrDefault(c => c.Name == city)
                .Shops;

        public IReadOnlyList<Shop> GetShopsByUser(Guid userId)
        {
            var user = _databaseContext
                            .Users
                            .Include(t => t.Receipts)
                            .FirstOrDefault(t => t.UserId == userId);

            var receipts = user.Receipts;

            var products = new List<Product>();

            foreach (var receipt in receipts)
            {
                products.AddRange(receipt.Products);
            }

            var shops = products.Select(t => t.Shop).ToList().AsReadOnly();

            return shops;
        }

        public Shop Get(Guid id) => _databaseContext
                .Shops
                .Include(t => t.City)
                    .ThenInclude(t => t.Country)
                .FirstOrDefault(t => t.ShopId == id);

        public List<Shop> GetAll() => _databaseContext
                .Shops
                .Include(t => t.City)
                    .ThenInclude(t => t.Country)
                .ToList();


        public void Add(Shop entity)
        {
            _databaseContext.Shops.Add(entity);
            _databaseContext.SaveChanges();
        }

        public void Edit(Shop entity)
        {
            _databaseContext.Shops.Update(entity);
            _databaseContext.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var shop = Get(id);
            if (shop == null) return;
            _databaseContext.Shops.Remove(shop);
            _databaseContext.SaveChanges();
        }
    }
}
