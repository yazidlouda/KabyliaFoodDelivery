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
   public class RestaurantService
    {
        //private readonly Guid _userId;

        //public CategoryService(Guid userID)
        //{
        //    _userId = userID;
        //}

        public async Task<bool> CreateRestaurantAsync(RestaurantCreate model)
        {
            var entity =
                new Restaurant()
                {
                   // OwnerID = _userId,
                    Name = model.Name,
                    Phone= model.Phone,
                    Email= model.Email,
                    Address= model.Address,
                    OpeningTime= model.OpeningTime,
                    ClosingTime= model.ClosingTime,
                    Area= model.Area,
                    Review=model.Review,
                    //Menu=model.Menu

                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Restaurants.Add(entity);
                return await ctx.SaveChangesAsync() == 1;
            }
        }

        public bool CreateRestaurant(RestaurantCreate model)
        {
            var entity =
                new Restaurant()
                {
                    Name = model.Name,
                    Phone = model.Phone,
                    Email = model.Email,
                    Address = model.Address,
                    OpeningTime = model.OpeningTime,
                    ClosingTime = model.ClosingTime,
                    Area = model.Area,
                    Review = model.Review,
                    //Menu = model.Menu

                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Restaurants.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public async Task<IEnumerable<RestaurantListItem>> GetRestaurantsAsync()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = await
                            ctx
                            .Restaurants
                            //.Where(e => e.OwnerID == _userId)
                            .Select(
                                e =>
                                    new RestaurantListItem
                                    {
                                        RestaurantId = e.RestaurantId,
                                        Name = e.Name,
                                        Phone=e.Phone,
                                        Email=e.Email,
                                        Address=e.Address,
                                        OpeningTime=e.OpeningTime,
                                        ClosingTime=e.ClosingTime,
                                        Area=e.Area,
                                        Review=e.Review,
                                       // Menu=e.Menu
                                    }
                    ).ToListAsync();
                return query;
            }
        }
        public IEnumerable<RestaurantListItem> GetRestaurants()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx
                            .Restaurants
                            //.Where(e => e.OwnerID == _userId)
                            .Select(
                                e =>
                                    new RestaurantListItem
                                    {
                                        RestaurantId = e.RestaurantId,
                                        Name = e.Name,
                                        Phone = e.Phone,
                                        Email = e.Email,
                                        Address = e.Address,
                                        OpeningTime = e.OpeningTime,
                                        ClosingTime = e.ClosingTime,
                                        Area = e.Area,
                                        Review = e.Review,
                                        //Menu = e.Menu
                                        // NumOfNote = e.Notes.Count()
                                    }
                    ).ToList();
                return query;
            }
        }

        public async Task<RestaurantDetails> GetRestaurantByIdAsync(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = await
                    ctx
                        .Restaurants
                        .Where(e => e.RestaurantId == id )
                        .FirstOrDefaultAsync();
                return
                    new RestaurantDetails
                    {
                        RestaurantId = entity.RestaurantId,
                        Name = entity.Name,
                        Phone=entity.Phone,
                        Email=entity.Email,
                        Address = entity.Address,
                        OpeningTime=entity.OpeningTime,
                        ClosingTime=entity.ClosingTime,
                        Area=entity.Area,
                        Review=entity.Review,
                        //Customer = entity.Customer
                        //        .Select(
                        //            x => new CustomerListItem
                        //            {
                        //                FirstName=x.FirstName,
                        //                LastName=x.LastName,
                        //                Address=x.Address,
                        //            }
                        //        ).ToList()
                    };
            }
        }

        public RestaurantDetails GetRestaurantByID(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Restaurants
                        .Where(e => e.RestaurantId == id)
                        .FirstOrDefault();
                return
                    new RestaurantDetails
                    {

                        RestaurantId = entity.RestaurantId,
                        Name = entity.Name,
                        Phone = entity.Phone,
                        Email = entity.Email,
                        Address = entity.Address,
                        OpeningTime = entity.OpeningTime,
                        ClosingTime = entity.ClosingTime,
                        Area = entity.Area,
                        Review = entity.Review,
                        //Customer = entity.Customer
                        //        .Select(
                        //            x => new CustomerListItem
                        //            {
                        //                FirstName = x.FirstName,
                        //                LastName = x.LastName
                        //            }
                        //        ).ToList()
                    };
            }
        }

        public async Task<bool> UpdateRestaurantAsync(RestaurantEdit category)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = await
                    ctx
                        .Restaurants
                        .Where(e => e.RestaurantId == category.RestaurantId )
                        .FirstOrDefaultAsync();
                entity.Name = category.Name;
                entity.Phone = category.Phone;
                entity.Email = category.Email;
                entity.Address = category.Address;
                entity.OpeningTime = category.OpeningTime;
                entity.ClosingTime = category.ClosingTime;
                entity.Area = category.Area;
                entity.Review = category.Review;

                return await ctx.SaveChangesAsync() == 1;
            }
        }

        public bool UpdateRestaurant(RestaurantEdit category)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Restaurants
                        .Where(e => e.RestaurantId == category.RestaurantId)
                        .FirstOrDefault();
                entity.Name = category.Name;
                entity.Phone = category.Phone;
                entity.Email = category.Email;
                entity.Address = category.Address;
                entity.OpeningTime = category.OpeningTime;
                entity.ClosingTime = category.ClosingTime;
                entity.Area = category.Area;
                entity.Review = category.Review;

                return ctx.SaveChanges() == 1;
            }
        }

        public async Task<bool> DeleteRestaurantAsync(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = await
                    ctx
                        .Restaurants
                        .Where(e => e.RestaurantId == id )
                        .FirstOrDefaultAsync();
                ctx.Restaurants.Remove(entity);

                return await ctx.SaveChangesAsync() == 1;
            }
        }

        public bool DeleteRestaurant(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Restaurants
                        .Where(e => e.RestaurantId == id )
                        .FirstOrDefault();
                ctx.Restaurants.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
