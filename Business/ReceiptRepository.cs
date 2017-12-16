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

        public  IReadOnlyList<Receipt> GetReceiptsByOwner(Guid ownerId)
        {
            return _databaseContext.Receipts.ToList();
        }
        public IReadOnlyList<Receipt> GetReceiptsByPrintedDate(Guid ownerId, DateTime date)
        {
            return _databaseContext.Receipts.ToList();
        }
        public void EditRecceipt(Guid id, Receipt receipt)
        {

        }
        public void CreateReceipt(Guid ownerId, DateTime printedAt)
        {

        }
        public void DeleteReceipt(Guid id)
        {

        }
        public void AddProduct(Guid receiptId, Product product, Guid ownerId)
        {

        }
        public void DeleteProduct(Guid receiptId, Guid productId)
        {

        }
        public Receipt GetById(Guid Id)
        {
            return _databaseContext.Receipts.FirstOrDefault(t => t.Id == Id);
        }
    }
}
