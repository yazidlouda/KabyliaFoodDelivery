using Kabylia.Data;
using Kabylia.Models.DeliveryDriver;
using Kabylia.Models.Order;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kabylia.Services
{
    public class DeliveryDriverService
    {
        public async Task<bool> CreateDeliveryDriverAsync(DeliveryDriverCreate model)
        {
            var entity =
                new DeliveryDriver()
                {
                    // OwnerID = _userId,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    Username = model.Username,
                    PhoneNumber = model.PhoneNumber,
                    IsActive = model.IsActive,
                    Latitude = model.Latitude,
                    Longitude = model.Longitude


                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.DeliveryDrivers.Add(entity);
                return await ctx.SaveChangesAsync() == 1;
            }
        }

        public bool CreateDeliveryDriver(DeliveryDriverCreate model)
        {
            var entity =
                new DeliveryDriver()
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    Username = model.Username,
                    PhoneNumber = model.PhoneNumber,
                    IsActive = model.IsActive,
                    Latitude = model.Latitude,
                    Longitude = model.Longitude
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.DeliveryDrivers.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public async Task<IEnumerable<DeliveryDriverListItem>> GetDeliveryDriversAsync()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = await
                            ctx
                            .DeliveryDrivers
                            //.Where(e => e.OwnerID == _userId)
                            .Select(
                                e =>
                                    new DeliveryDriverListItem
                                    {
                                        DriverId = e.DriverId,
                                        FirstName = e.FirstName,
                                        LastName = e.LastName,
                                        Username = e.Username,
                                        Email = e.Email,
                                        PhoneNumber = e.PhoneNumber,
                                        Latitude = e.Latitude,
                                        Longitude = e.Longitude,
                                        IsActive = e.IsActive,
                                        DelivryCount=e.Order.Count()
                                    }
                    ).ToListAsync();
                return query;
            }
        }
        public IEnumerable<DeliveryDriverListItem> GetDeliveryDrivers()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx
                            .DeliveryDrivers
                            //.Where(e => e.OwnerID == _userId)
                            .Select(
                                e =>
                                    new DeliveryDriverListItem
                                    {
                                        DriverId = e.DriverId,
                                        FirstName = e.LastName,
                                        Username = e.Username,
                                        Email = e.Email,
                                        PhoneNumber = e.PhoneNumber,
                                        Latitude = e.Latitude,
                                        Longitude = e.Longitude,
                                        IsActive = e.IsActive,
                                        DelivryCount = e.Order.Count()

                                    }
                    ).ToList();
                return query;
            }
        }

        public async Task<DeliveryDriverDetails> GetDeliveryDriverByIdAsync(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = await
                    ctx
                        .DeliveryDrivers
                        .Where(e => e.DriverId == id)
                        .FirstOrDefaultAsync();
                return
                    new DeliveryDriverDetails
                    {
                        DriverId = entity.DriverId,
                        FirstName = entity.FirstName,
                        LastName = entity.LastName,
                        Email = entity.Email,
                        Username = entity.Username,
                        PhoneNumber = entity.PhoneNumber,
                        IsActive = entity.IsActive,
                        Latitude = entity.Latitude,
                        Longitude = entity.Longitude,
                        Order = entity.Order
                        .Select(
                                    x => new OrderListItem
                                    {
                                        OrderId = x.OrderId,
                                        CustomerName = x.Customer.FirstName+" "+x.Customer.LastName,
                                        CustomerAddress=x.Customer.Address,
                                        RestaurantName = x.Restaurant.Name,
                                        RestaurantAddress=x.Restaurant.Address,
                                        RestaurantLatitude=x.Restaurant.Latitude,
                                        RestaurantLongitude=x.Restaurant.Longitude,
                                        CustomerLatitude=x.Customer.Latitude,
                                        CustomerLongitude=x.Customer.Longitude
                                    }
                                ).ToList()

                    };
            }
        }

        public DeliveryDriverDetails GetDeliveryDriverByID(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .DeliveryDrivers
                        .Where(e => e.DriverId == id)
                        .FirstOrDefault();
                return
                    new DeliveryDriverDetails
                    {

                        DriverId = entity.DriverId,
                        FirstName = entity.FirstName,
                        LastName = entity.LastName,
                        Email = entity.Email,
                        Username = entity.Username,
                        PhoneNumber = entity.PhoneNumber,
                        IsActive = entity.IsActive,
                        Latitude = entity.Latitude,
                        Longitude = entity.Longitude,
                        Order = entity.Order
                        .Select(
                                    x => new OrderListItem
                                    {
                                        OrderId = x.OrderId,
                                        CustomerName = x.Customer.FirstName + " " + x.Customer.LastName,
                                        CustomerAddress = x.Customer.Address,
                                        RestaurantName = x.Restaurant.Name,
                                        RestaurantAddress = x.Restaurant.Address,
                                        RestaurantLatitude = x.Restaurant.Latitude,
                                        RestaurantLongitude = x.Restaurant.Longitude,
                                        CustomerLatitude = x.Customer.Latitude,
                                        CustomerLongitude = x.Customer.Longitude
                                    }
                                ).ToList()

                    };
            }
        }

        public async Task<bool> UpdateDeliveryDriverAsync(DeliveryDriverEdit category)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = await
                    ctx
                        .DeliveryDrivers
                        .Where(e => e.DriverId == category.DriverId)
                        .FirstOrDefaultAsync();
                entity.FirstName = category.FirstName;
                entity.LastName = category.LastName;
                entity.Email = category.Email;
                entity.Username = category.Username;
                entity.PhoneNumber = category.PhoneNumber;
                entity.IsActive = category.IsActive;
                entity.Latitude = category.Latitude;
                entity.Longitude = category.Longitude;

                return await ctx.SaveChangesAsync() == 1;
            }
        }

        public bool UpdateDeliveryDriver(DeliveryDriverEdit category)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .DeliveryDrivers
                        .Where(e => e.DriverId == category.DriverId)
                        .FirstOrDefault();
                entity.FirstName = category.FirstName;
                entity.LastName = category.LastName;
                entity.Email = category.Email;
                entity.Username = category.Username;
                entity.PhoneNumber = category.PhoneNumber;
                entity.IsActive = category.IsActive;
                entity.Latitude = category.Latitude;
                entity.Longitude = category.Longitude;
                return ctx.SaveChanges() == 1;
            }
        }

        public async Task<bool> DeleteDeliveryDriverAsync(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = await
                    ctx
                        .DeliveryDrivers
                        .Where(e => e.DriverId == id)
                        .FirstOrDefaultAsync();
                ctx.DeliveryDrivers.Remove(entity);

                return await ctx.SaveChangesAsync() == 1;
            }
        }

        public bool DeleteDeliveryDriver(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .DeliveryDrivers
                        .Where(e => e.DriverId == id)
                        .FirstOrDefault();
                ctx.DeliveryDrivers.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
