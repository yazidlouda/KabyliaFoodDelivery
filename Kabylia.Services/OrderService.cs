using Kabylia.Data;
using Kabylia.Models.Order;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kabylia.Services
{
    public class OrderService
    {
        public async Task<bool> CreateOrderAsync(OrderCreate model)
        {
            var entity =
                new Order()
                {
                    // OwnerID = _userId,

                   // OrderId = model.OrderId,
                   // Menu = model.,
                    Price = model.Price,
                    DateOfOrder = DateTime.Now,
                    DeliveryCharge = model.DeliveryCharge,
                    CustomerId = model.CustomerId,
                   // MembershipLevel = model.MembershipLevel,
                    RestaurantId = model.RestaurantId
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Orders.Add(entity);
                return await ctx.SaveChangesAsync() == 1;
            }
        }
        public bool CreateOrder(OrderCreate model)
        {
            var entity =
                new Order()
                {

                    //OrderId = model.OrderId,
                   // Menu = model.Menu,
                    Price = model.Price,
                    DateOfOrder = DateTime.Now,
                    DeliveryCharge = model.DeliveryCharge,
                    CustomerId = model.CustomerId,
                    // MembershipLevel = model.MembershipLevel,
                    RestaurantId = model.RestaurantId

                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Orders.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public async Task<IEnumerable<OrderListItem>> GetOrdersAsync()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = await
                    ctx
                        .Orders
                        //.Where(e => e.OwnerID == _userId)
                        .Select(
                            e =>
                                new OrderListItem
                                {
                                    OrderId =e.OrderId,
                                    //Menu = e.Menu,
                                    Price = e.Price,
                                    DateOfOrder = e.DateOfOrder,
                                    DeliveryCharge = e.DeliveryCharge,
                                    CustomerName = e.Customer.FirstName +" "+ e.Customer.LastName,
                                    RestaurantName = e.Restaurant.Name


                                }
                        ).ToListAsync();
                return query.OrderBy(e => e.OrderId);
            }
        }

        public IEnumerable<OrderListItem> GetOrders()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Orders
                        //.Where(e => e.OwnerID == _userId)
                        .Select(
                            e =>
                                new OrderListItem
                                {
                                    OrderId = e.OrderId,
                                    //Menu = e.Menu,
                                    Price = e.Price,
                                    DateOfOrder = e.DateOfOrder,
                                    DeliveryCharge = e.DeliveryCharge,
                                    CustomerName = e.Customer.FirstName + " " + e.Customer.LastName,
                                    RestaurantName = e.Restaurant.Name

                                }
                        );
                return query.ToList().OrderBy(e => e.OrderId);
            }
        }
        public async Task<OrderDetails> GetOrderByIdAsync(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {

                var entity = await
                    ctx
                        .Orders
                        .Where(e => e.OrderId == id)
                        .FirstOrDefaultAsync();
                return
                    new OrderDetails
                    {
                        OrderId = entity.OrderId,
                        //Menu = entity.Menu,
                        Price = entity.Price,
                        DateOfOrder = DateTime.Now,
                        DeliveryCharge = entity.DeliveryCharge,
                        CustomerName = entity.Customer.FirstName + " " + entity.Customer.LastName,
                        RestaurantName = entity.Restaurant.Name

                    };
            }
        }
        public OrderDetails GetOrderById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {

                var entity =
                    ctx
                        .Orders
                        .Single(e => e.OrderId == id);
                return
                    new OrderDetails
                    {
                        OrderId = entity.OrderId,
                        //Menu = entity.Menu,
                        Price = entity.Price,
                        DateOfOrder = DateTime.Now,
                        DeliveryCharge = entity.DeliveryCharge,
                        CustomerName = entity.Customer.FirstName + " " + entity.Customer.LastName,
                        RestaurantName = entity.Restaurant.Name

                    };
            }
        }
        public async Task<bool> UpdateOrderAsync(OrderEdit note)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = await
                    ctx
                        .Orders
                        .Where(e => e.OrderId == note.OrderId)
                        .FirstOrDefaultAsync();
               // entity.Menu = note.Menu;
                entity.Price = note.Price;
                entity.DeliveryCharge = note.DeliveryCharge;
                entity.CustomerId = note.CustomerId;
                entity.RestaurantId = note.RestaurantId;
                //entity.Customer.FirstName = note.CustomerName;

                //ctx.Entry(entity).State = EntityState.Modified;
                return await ctx.SaveChangesAsync() == 1;
            }
        }
        public bool UpdateCustomer(OrderEdit note)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Orders
                        .Where(e => e.OrderId == note.OrderId)
                        .FirstOrDefault();
                //entity.Menu = note.Menu;
                entity.Price = note.Price;
                entity.DeliveryCharge = note.DeliveryCharge;
                entity.CustomerId = note.CustomerId;
                entity.RestaurantId = note.RestaurantId;
                //entity.Customer.FirstName = note.CustomerName;

                return ctx.SaveChanges() == 1;
            }
        }
        public async Task<bool> DeleteOrderAsync(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = await
                    ctx
                        .Orders
                        .Where(e => e.OrderId == id)
                        .FirstOrDefaultAsync();

                ctx.Orders.Remove(entity);

                return await ctx.SaveChangesAsync() == 1;
            }
        }

        public bool DeleteCustomer(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Orders
                        .Single(e => e.OrderId == id);

                ctx.Orders.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
