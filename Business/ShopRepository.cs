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
            ICityRepository cityRepository = new CityRepository(_databaseContext);
            var city = cityRepository.GetById(cityId);
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
            ICityRepository cityRepository = new CityRepository(_databaseContext);
            var city = cityRepository.GetById(cityId);
            city.Shops.Add(shop);
        }

        public void Edit(Shop shop)
        {
            _databaseContext.Shops.Update(shop);
        }

        public void Delete(Guid cityId, Guid shopId)
        {
            ICityRepository cityRepository = new CityRepository(_databaseContext);
            var city = cityRepository.GetById(cityId);
            var shop = GetById(shopId);
            city.Shops.Remove(shop);
        }
    }
}
