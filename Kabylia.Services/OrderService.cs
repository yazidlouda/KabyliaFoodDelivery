using Kabylia.Data;
using Kabylia.Models.Menu;
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
                    
                    DateOfOrder = DateTime.Now,
                    DeliveryCharge = model.DeliveryCharge,
                    CustomerId = model.CustomerId,
                    RestaurantId = model.RestaurantId,
                    DriverId=model.DriverId,
                    
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

                   
                    DateOfOrder = DateTime.Now,
                    DeliveryCharge = model.DeliveryCharge,
                    CustomerId = model.CustomerId,
                   
                    RestaurantId = model.RestaurantId,
                    DriverId = model.DriverId,
                   
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
                                    DateOfOrder = e.DateOfOrder,
                                    DeliveryCharge = e.DeliveryCharge,
                                    CustomerName = e.Customer.FirstName +" "+ e.Customer.LastName,
                                    RestaurantName = e.Restaurant.Name,
                                    DriverName=e.DeliveryDriver.FirstName+" "+e.DeliveryDriver.LastName,
                                    RestaurantLatitude=e.Restaurant.Latitude,
                                    RestaurantLongitude=e.Restaurant.Longitude,
                                    CustomerLatitude=e.Customer.Latitude,
                                    CustomerLongitude=e.Customer.Longitude,
                                    DriverLatitude = e.DeliveryDriver.Latitude,
                                    DriverLongitude = e.DeliveryDriver.Longitude,
                                    Amount=e.Restaurant.Menu.Sum(item => (item.Price))
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
                                    DateOfOrder = e.DateOfOrder,
                                    DeliveryCharge = e.DeliveryCharge,
                                    CustomerName = e.Customer.FirstName + " " + e.Customer.LastName,
                                    RestaurantName = e.Restaurant.Name,
                                    DriverName = e.DeliveryDriver.FirstName + " " + e.DeliveryDriver.LastName,
                                     RestaurantLatitude = e.Restaurant.Latitude,
                                    RestaurantLongitude = e.Restaurant.Longitude,
                                    CustomerLatitude = e.Customer.Latitude,
                                    CustomerLongitude = e.Customer.Longitude,
                                    DriverLatitude = e.DeliveryDriver.Latitude,
                                    DriverLongitude = e.DeliveryDriver.Longitude,
                                    Amount = e.Restaurant.Menu.Sum(item => (item.Price)),


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
                       
                        DateOfOrder = DateTime.Now,
                        DeliveryCharge = entity.DeliveryCharge,
                        CustomerName = entity.Customer.FirstName + " " + entity.Customer.LastName,
                        RestaurantName = entity.Restaurant.Name,
                        DriverName=entity.DeliveryDriver.FirstName+" "+entity.DeliveryDriver.LastName,
                        RestaurantLatitude=entity.Restaurant.Latitude,
                        RestaurantLongitude=entity.Restaurant.Longitude,
                        CustomerLatitude=entity.Customer.Latitude,
                        CustomerLongitude=entity.Customer.Longitude,
                        DriverLatitude = entity.DeliveryDriver.Latitude,
                        DriverLongitude = entity.DeliveryDriver.Longitude,
                        Amount = entity.Restaurant.Menu.Sum(item =>(item.Price)) ,
                        Menu = entity.Restaurant.Menu.Select(x => new MenuListItem
                        {
                            MenuId=x.MenuId,
                            Name = x.Name,
                            Description = x.Description,
                            Price = x.Price
                        }
                                ).ToList()

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
                        DateOfOrder = DateTime.Now,
                        DeliveryCharge = entity.DeliveryCharge,
                        CustomerName = entity.Customer.FirstName + " " + entity.Customer.LastName,
                        RestaurantName = entity.Restaurant.Name,
                        DriverName = entity.DeliveryDriver.FirstName + " " + entity.DeliveryDriver.LastName,
                        RestaurantLatitude = entity.Restaurant.Latitude,
                        RestaurantLongitude = entity.Restaurant.Longitude,
                        CustomerLatitude = entity.Customer.Latitude,
                        CustomerLongitude = entity.Customer.Longitude,
                        DriverLatitude = entity.DeliveryDriver.Latitude,
                        DriverLongitude = entity.DeliveryDriver.Longitude,
                        Amount = entity.Restaurant.Menu.Sum(item =>(item.Price)) ,
                        Menu=entity.Restaurant.Menu.Select(x => new MenuListItem
                        {
                           MenuId=x.MenuId,
                            Name = x.Name,
                            Description = x.Description,
                            Price = x.Price
                        }
                                ).ToList()

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
                        .Where(e => e.OrderId == note.OrderId )
                        .FirstOrDefaultAsync();
              
                
                entity.DeliveryCharge = note.DeliveryCharge;
                entity.CustomerId = note.CustomerId;
                entity.RestaurantId = note.RestaurantId;
                entity.DriverId = note.DriverId;
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
                        .Where(e => e.OrderId == note.OrderId )
                        .FirstOrDefault();
                entity.DeliveryCharge = note.DeliveryCharge;
                entity.CustomerId = note.CustomerId;
                entity.RestaurantId = note.RestaurantId;
                entity.DriverId = note.DriverId;

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
