using Data.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Data.Domain.Interfeces
{
    public interface IShopRepository
    {
        IReadOnlyList<Shop> GetShopsByCity(Guid cityId);
        IReadOnlyList<Shop> GetShopsByUser(Guid userId);
        IReadOnlyList<Shop> GetAllShops();
        Shop GetById(Guid id);
        void Add(Guid cityId, Shop shop);
        void Edit(Guid cityId, Shop shop);
        void Delete(Guid cityId, Guid shopId);
    }
}
