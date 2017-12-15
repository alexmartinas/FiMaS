using System;
using System.Collections.Generic;
using System.Linq;
using Data.Domain.Entities;
using Data.Domain.Interfeces;
using Data.Persistence;

namespace Business
{
    public class ShopRepository : IShopRepository
    {
        private readonly IDatabaseContext _databaseContext;

        public ShopRepository(IDatabaseContext databaseContext)
        {
            _databaseContext = databaseContext; 
        }

        public IReadOnlyList<Shop> GetShopsByCity(Guid cityId)
        {
            var city = _databaseContext.Cities.FirstOrDefault(c => c.Id == cityId);
            return city.Shops.AsReadOnly();
        }
        
        public IReadOnlyList<Shop> GetShopsByUser(Guid userId)
        {
            throw new NotImplementedException();
        }

        public IReadOnlyList<Shop> GetAllShops()
        {
            return _databaseContext.Shops.ToList().AsReadOnly();
        }

        public Shop GetById(Guid shopId)
        {
            return _databaseContext.Shops.FirstOrDefault(s => s.Id == shopId);
        }

        public void Add(Guid cityId, Shop shop)
        {
            var city = _databaseContext.Cities.FirstOrDefault(c => c.Id == cityId);
            city.Shops.Add(shop);
            _databaseContext.SaveChanges();
        }

        public void Edit(Guid cityId, Shop shop)
        {
            var city = _databaseContext.Cities.FirstOrDefault(c => c.Id == cityId);
            _databaseContext.Shops.Update(shop);
            _databaseContext.SaveChanges();
        }

        public void Delete(Guid cityId, Guid shopId)
        {
            var city = _databaseContext.Cities.FirstOrDefault(c => c.Id == cityId);
            var shop = GetById(shopId);
            city.Shops.Remove(shop);
        }
    }
}
