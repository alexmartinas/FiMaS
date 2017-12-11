using Data.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Domain.Interfeces
{
    interface IShopRepository
    {
        IReadOnlyList<Shop> getShopsByCity(Guid cityId);
        IReadOnlyList<Shop> getShopsByUser(Guid cityId);
    }
}
