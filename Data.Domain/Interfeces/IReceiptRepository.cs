using Data.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Data.Domain.Interfeces
{
   public interface IReceiptRepository
    {
        IReadOnlyList<Receipt> GetReceiptsByOwner(Guid ownerId);
        IReadOnlyList<Receipt> GetReceiptsByPrintedDate(Guid ownerId,DateTime date);
        void EditRecceipt(Guid id, Receipt receipt);
        void CreateReceipt(Guid ownerId, DateTime printedAt);
        void DeleteReceipt(Guid id);
        void AddProduct(Guid receiptId, Product product, Guid ownerId);
        void DeleteProduct(Guid receiptId, Guid productId);
        Receipt GetById(Guid id);
    }
}
