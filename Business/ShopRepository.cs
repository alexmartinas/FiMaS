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

        public IReadOnlyList<Shop> GetShopsByCity(Guid cityId) => _databaseContext
                .Cities
                .FirstOrDefault(c => c.CityId == cityId)
                .Shops;

        public IReadOnlyList<Shop> GetShopsByUser(Guid userId)
        {
            throw new NotImplementedException();
        }

        public IReadOnlyList<Shop> GetAllShops() => _databaseContext
                .Shops
                .ToList();

        public Shop GetById(Guid shopId) => _databaseContext
                .Shops
                .FirstOrDefault(t => t.ShopId == shopId);

        public void Add(Guid cityId, Shop shop)
        {
            throw new NotImplementedException();
        }

        public void Edit(Guid cityId, Shop shop)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid cityId, Guid shopId)
        {
            throw new NotImplementedException();
        }
    }
}
