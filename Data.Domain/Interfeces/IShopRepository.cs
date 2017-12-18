using Data.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Data.Domain.Interfeces
{
    public interface IShopRepository : IRepository<Shop>
    {
        IReadOnlyList<Shop> GetShopsByCity(string city);
        IReadOnlyList<Shop> GetShopsByUser(Guid userId);
        Shop GetShopById(Guid shopId);
    }
}
