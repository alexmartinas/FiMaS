using Data.Domain.Entities;
using Data.Domain.Interfeces;
using Data.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Business
{
    public class ReceiptRepository : IReceiptRepository
    {
        private readonly IDatabaseContext _databaseContext;

        public ReceiptRepository(IDatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        IReadOnlyList<Receipt> GetReceiptsByOwner(Guid ownerId)
        {
            return _databaseContext.Receipts.ToList();
        }
        IReadOnlyList<Receipt> GetReceiptsByPrintedDate(Guid ownerId, DateTime date)
        {
            return _databaseContext.Receipts.ToList();
        }
        void EditRecceipt(Guid id, Receipt receipt)
        {

        }
        void CreateReceipt(Guid ownerId, DateTime printedAt)
        {

        }
        void DeleteReceipt(Guid id)
        {

        }
        void AddProduct(Guid receiptId, Product product, Guid ownerId)
        {

        }
        void DeleteProduct(Guid receiptId, Guid productId)
        {

        }
        IReadOnlyList<Receipt> GetById(Guid Id)
        {
            return _databaseContext.Receipts.ToList();
        }
    }
}
