using Kabylia.Data;
using Kabylia.Models.Customer;
using Kabylia.Models.Restaurant;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kabylia.Services
{
    public class CustomerService
    {
        //private readonly Guid _userId;

        //public CustomerService(Guid userID)
        //{
        //    _userId = userID;
        //}

        public async Task<bool> CreateCustomerAsync(CustomerCreate model)
        {
            var entity =
                new Customer()
                {
                    // OwnerID = _userId,
                    
                    FirstName = model.FirstName,
                   LastName=model.LastName,
                   Username=model.Username,
                   Phone=model.Phone,
                   Email=model.Email,
                   Address=model.Address,
                   MembershipLevel=model.MembershipLevel,
                   Latitude=model.Latitude,
                   Longitude=model.Longitude
                   //RestaurantId=model.RestaurantId
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Customers.Add(entity);
                return await ctx.SaveChangesAsync() == 1;
            }
        }
        public bool CreateCustomer(CustomerCreate model)
        {
            var entity =
                new Customer()
                {
                    
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Username = model.Username,
                    Phone = model.Phone,
                    Email = model.Email,
                    Address = model.Address,
                    MembershipLevel = model.MembershipLevel,
                    Latitude = model.Latitude,
                    Longitude = model.Longitude
                    //RestaurantId=model.RestaurantId

                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Customers.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public async Task<IEnumerable<CustomerListItem>> GetCustomersAsync()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = await
                    ctx
                        .Customers
                        //.Where(e => e.OwnerID == _userId)
                        .Select(
                            e =>
                                new CustomerListItem
                                {
                                    CustomerId = e.CustomerId,
                                    FirstName = e.FirstName,
                                    LastName = e.LastName,
                                    Username = e.Username,
                                    Phone = e.Phone,
                                    Email = e.Email,
                                    Address = e.Address,
                                    MembershipLevel = e.MembershipLevel,
                                    Latitude=e.Latitude,
                                    Longitude=e.Longitude
                                   //RestaurantName= e.Restaurant.Name
                                  

                                }
                        ).ToListAsync();
                return query.OrderBy(e => e.CustomerId);
            }
        }

        public IEnumerable<CustomerListItem> GetCustomers()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Customers
                        //.Where(e => e.OwnerID == _userId)
                        .Select(
                            e =>
                                new CustomerListItem
                                {
                                    CustomerId=e.CustomerId,
                                    FirstName = e.FirstName,
                                    LastName = e.LastName,
                                    Username = e.Username,
                                    Phone = e.Phone,
                                    Email = e.Email,
                                    Address = e.Address,
                                    MembershipLevel = e.MembershipLevel,
                                    Latitude = e.Latitude,
                                    Longitude = e.Longitude
                                    // RestaurantName = e.Restaurant.Name

                                }
                        );
                return query.ToList().OrderBy(e => e.CustomerId);
            }
        }
        public async Task<CustomerDetails> GetCustomerByIdAsync(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {

                var entity = await
                    ctx
                        .Customers
                        .Where(e => e.CustomerId == id)
                        .FirstOrDefaultAsync();
                return
                    new CustomerDetails
                    {
                        CustomerId=entity.CustomerId,
                        FirstName = entity.FirstName,
                        LastName = entity.LastName,
                        Username = entity.Username,
                        Phone = entity.Phone,
                        Email = entity.Email,
                        Address = entity.Address,
                        MembershipLevel = entity.MembershipLevel,
                        Latitude=entity.Latitude,
                        Longitude=entity.Longitude
                        //RestaurantName = entity.Restaurant.Name

                    };
            }
        }
        public CustomerDetails GetCustomerById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {

                var entity =
                    ctx
                        .Customers
                        .Single(e => e.CustomerId == id );
                return
                    new CustomerDetails
                    {
                        FirstName = entity.FirstName,
                        LastName = entity.LastName,
                        Username = entity.Username,
                        Phone = entity.Phone,
                        Email = entity.Email,
                        Address = entity.Address,
                        MembershipLevel = entity.MembershipLevel,
                        Latitude = entity.Latitude,
                        Longitude = entity.Longitude
                        // RestaurantName = entity.Restaurant.Name

                    };
            }
        }
        public async Task<bool> UpdateCustomerAsync(CustomerEdit note)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = await
                    ctx
                        .Customers
                        .Where(e => e.CustomerId == note.CustomerId )
                        .FirstOrDefaultAsync();
                entity.FirstName = note.FirstName;
                entity.LastName = note.LastName;
                entity.Username = note.Username;
                entity.Phone = note.Phone;
                entity.Email = note.Email;
                entity.Address = note.Address;
                entity.MembershipLevel = note.MembershipLevel;
                entity.Latitude = note.Latitude;
                entity.Longitude = note.Longitude;

                //entity.RestaurantId = note.RestaurantId;

                //ctx.Entry(entity).State = EntityState.Modified;
                return await ctx.SaveChangesAsync() == 1;
            }
        }
        public bool UpdateCustomer(CustomerEdit note)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Customers
                        .Where(e => e.CustomerId == note.CustomerId )
                        .FirstOrDefault();

                entity.FirstName = note.FirstName;
                entity.LastName = note.LastName;
                entity.Username = note.Username;
                entity.Phone = note.Phone;
                entity.Email = note.Email;
                entity.Address = note.Address;
                entity.MembershipLevel = note.MembershipLevel;
                entity.Latitude = note.Latitude;
                entity.Longitude = note.Longitude;
                //entity.RestaurantId = note.RestaurantId;


                return ctx.SaveChanges() == 1;
            }
        }
        public async Task<bool> DeleteCustomerAsync(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = await
                    ctx
                        .Customers
                        .Where(e => e.CustomerId == id )
                        .FirstOrDefaultAsync();

                ctx.Customers.Remove(entity);

                return await ctx.SaveChangesAsync() == 1;
            }
        }

        public bool DeleteCustomer(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Customers
                        .Single(e => e.CustomerId == id );

                ctx.Customers.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
