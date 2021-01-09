using Kabylia.Data;
using Kabylia.Models.Transaction;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kabylia.Services
{
    public class TransactionService
    {
        public async Task<bool> CreateTransactionAsync(TransactionCreate model)
        {
            var entity =
                new Transaction()
                {
                   
                   
                    OrderId = model.OrderId,
                   
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Transactions.Add(entity);
                return await ctx.SaveChangesAsync() == 1;
            }
        }
        public bool CreateTransaction(TransactionCreate model)
        {
            var entity =
                new Transaction()
                {

                  
                    OrderId = model.OrderId,

                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Transactions.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public async Task<IEnumerable<TransactionListItem>> GetTransactionsAsync()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = await
                    ctx
                        .Transactions
                        //.Where(e => e.OwnerID == _userId)
                        .Select(
                            e =>
                                new TransactionListItem
                                {
                                    TransactionId=e.TransactionId,
                                    OrderId = e.OrderId,
                                    Amount = (e.Order.Restaurant.Menu.Sum(item => (item.Price)) + e.Order.DeliveryCharge) + (e.Order.Restaurant.Menu.Sum(item => (item.Price)) + e.Order.DeliveryCharge) * 7 / 100,
                                    DateOfTransaction = e.DateOfTransaction,
                                    CustomerId = e.Order.Customer.CustomerId,
                                    RestaurantId = e.Order.Restaurant.RestaurantId,
                                    CustomerName = e.Order.Customer.FirstName + " " + e.Order.Customer.LastName,
                                    RestaurantName = e.Order.Restaurant.Name


                                }
                        ).ToListAsync();
                return query.OrderBy(e => e.TransactionId);
            }
        }

        public IEnumerable<TransactionListItem> GetTransactions()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Transactions
                        //.Where(e => e.OwnerID == _userId)
                        .Select(
                            e =>
                                new TransactionListItem
                                {
                                    TransactionId = e.TransactionId,
                                    OrderId = e.OrderId,
                                    Amount = (e.Order.Restaurant.Menu.Sum(item => (item.Price)) + e.Order.DeliveryCharge)+ (e.Order.Restaurant.Menu.Sum(item => (item.Price)) + e.Order.DeliveryCharge)*7/100,

                                    DateOfTransaction = e.DateOfTransaction,
                                    CustomerId = e.Order.Customer.CustomerId,
                                    RestaurantId = e.Order.Restaurant.RestaurantId,
                                    CustomerName = e.Order.Customer.FirstName + " " + e.Order.Customer.LastName,
                                    RestaurantName = e.Order.Restaurant.Name
                                }
                        );
                return query.ToList().OrderBy(e => e.TransactionId);
            }
        }
        public async Task<TransactionDetails> GetTransactionByIdAsync(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {

                var entity = await
                    ctx
                        .Transactions
                        .Where(e => e.TransactionId == id)
                        .FirstOrDefaultAsync();
                return
                    new TransactionDetails
                    {
                        TransactionId = entity.TransactionId,
                        OrderId = entity.OrderId,
                        DateOfTransaction = entity.DateOfTransaction,
                        CustomerId = entity.Order.Customer.CustomerId,
                        RestaurantId = entity.Order.Restaurant.RestaurantId,
                        Amount = (entity.Order.Restaurant.Menu.Sum(item => (item.Price)) + entity.Order.DeliveryCharge) + (entity.Order.Restaurant.Menu.Sum(item => (item.Price)) + entity.Order.DeliveryCharge) * 7 / 100,
                        CustomerName = entity.Order.Customer.FirstName + " " + entity.Order.Customer.LastName,
                        RestaurantName = entity.Order.Restaurant.Name

                    };
            }
        }
        public TransactionDetails GetTransactionById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {

                var entity =
                    ctx
                        .Transactions
                        .Single(e => e.OrderId == id);
                return
                    new TransactionDetails
                    {
                        TransactionId = entity.TransactionId,
                        OrderId = entity.OrderId,
                        DateOfTransaction = entity.DateOfTransaction,
                        CustomerId = entity.Order.Customer.CustomerId,
                        RestaurantId = entity.Order.Restaurant.RestaurantId,
                        Amount = (entity.Order.Restaurant.Menu.Sum(item => (item.Price)) + entity.Order.DeliveryCharge)+ (entity.Order.Restaurant.Menu.Sum(item => (item.Price)) + entity.Order.DeliveryCharge)*7/100,

                        CustomerName = entity.Order.Customer.FirstName + " " + entity.Order.Customer.LastName,
                        RestaurantName = entity.Order.Restaurant.Name

                    };
            }
        }
        public async Task<bool> UpdateTransactionAsync(TransactionEdit note)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = await
                    ctx
                        .Transactions
                        .Where(e => e.TransactionId == note.TransactionId  )
                        .FirstOrDefaultAsync();
              
                entity.OrderId = note.OrderId;
                entity.Order.Customer.CustomerId = note.CustomerId;
                entity.Order.Restaurant.RestaurantId = note.CustomerId;
               
                //entity.Customer.FirstName = note.CustomerName;

                //ctx.Entry(entity).State = EntityState.Modified;
                return await ctx.SaveChangesAsync() == 1;
            }
        }
        public bool UpdateTransaction(TransactionEdit note)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Transactions
                        .Where(e => e.TransactionId == note.TransactionId)
                        .FirstOrDefault();
              
                entity.OrderId = note.OrderId;
                entity.Order.Customer.CustomerId = note.CustomerId;
                entity.Order.Restaurant.RestaurantId = note.CustomerId;
                //entity.Customer.FirstName = note.CustomerName;

                return ctx.SaveChanges() == 1;
            }
        }
        public async Task<bool> DeleteTransactionAsync(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = await
                    ctx
                        .Transactions
                        .Where(e => e.TransactionId == id)
                        .FirstOrDefaultAsync();

                ctx.Transactions.Remove(entity);

                return await ctx.SaveChangesAsync() == 1;
            }
        }

        public bool DeleteTransaction(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Transactions
                        .Single(e => e.TransactionId == id);

                ctx.Transactions.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
