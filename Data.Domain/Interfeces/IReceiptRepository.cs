using Data.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Domain.Interfeces
{
    interface IReceiptRepository
    {
        IReadOnlyList<Receipt> getReceiptsByOwner(Guid ownerId);
        IReadOnlyList<Receipt> getReceiptsByPrintedDate(Guid ownerId,DateTime date);
        void editRecceipt(Guid id, Receipt receipt);
        void createReceipt(Guid ownerId, DateTime printedAt);
        void deleteReceipt(Guid id);
        void addProduct(Guid receiptId, Product product, Guid ownerId);
        void deleteProduct(Guid receiptId, Guid productId);
    }
}
