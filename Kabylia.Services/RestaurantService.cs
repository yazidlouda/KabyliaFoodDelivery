using Kabylia.Data;
using Kabylia.Models.Customer;
using Kabylia.Models.Menu;
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
                    AreaId= model.AreaId,
                    Review=model.Review,
                    
                    //MenuId=model.MenuId

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
                    AreaId = model.AreaId,
                    Review = model.Review,
                    
                   // MenuId = model.MenuId

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
                                       // MenuId=e.MenuId,
                                        Name = e.Name,
                                        Phone=e.Phone,
                                        Email=e.Email,
                                        Address=e.Address,
                                        OpeningTime=e.OpeningTime,
                                        ClosingTime=e.ClosingTime,
                                        AreaName=e.Area.AreaName,
                                        Review=e.Review,
                                        NumberOfMenu=e.Menu.Count()
                                        //MenuName=e.Menu.Name
                                       // Menu=e.Menu
                                    }
                    ).ToListAsync();
                return query.OrderBy(e => e.RestaurantId);
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
                                       // MenuId = e.MenuId,

                                        Name = e.Name,
                                        Phone = e.Phone,
                                        Email = e.Email,
                                        Address = e.Address,
                                        OpeningTime = e.OpeningTime,
                                        ClosingTime = e.ClosingTime,
                                        AreaName = e.Area.AreaName,

                                        Review = e.Review,
                                        NumberOfMenu = e.Menu.Count()

                                        //MenuName = e.Menu.Name

                                        //Menu = e.Menu
                                        // NumOfNote = e.Notes.Count()
                                    }
                    ).ToList();
                return query.OrderBy(e => e.RestaurantId);
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
                        AreaId = entity.AreaId,
                        AreaName = entity.Area.AreaName,
                        Review =entity.Review,
                        Menu = entity.Menu
                        .Select(
                                    x => new MenuListItem
                                    {
                                        MenuId = x.MenuId,
                                        Name = x.Name,
                                        Description = x.Description,
                                        Price = x.Price
                                    }
                                ).ToList()
                        //MenuId=entity.MenuId,
                        //MenuName=entity.Menu.Name

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
                        .Single(e => e.RestaurantId == id);
                        //.FirstOrDefault();
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
                        AreaId = entity.AreaId,
                        AreaName = entity.Area.AreaName,
                        Review = entity.Review,
                        Menu = entity.Menu
                         .Select(
                                    x => new MenuListItem
                                    {
                                        MenuId = x.MenuId,
                                        Name = x.Name,
                                        Description = x.Description,
                                        Price = x.Price
                                    }
                                ).ToList()
                        //MenuId = entity.MenuId,
                        //MenuName = entity.Menu.Name

                    };
            }
        }
        public async Task<RestaurantDetails> GetMenuRestaurantByIdAsync(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = await
                    ctx
                        .Restaurants
                        .Where(e => e.RestaurantId == id)
                        .FirstOrDefaultAsync();
                return
                    new RestaurantDetails
                    {
                      
                        Menu = entity.Menu
                        .Select(
                                    x => new MenuListItem
                                    {
                                        MenuId = x.MenuId,
                                        Name = x.Name,
                                        Description = x.Description,
                                        Price = x.Price
                                    }
                                ).ToList()
                       

                    };
            }
        }

        public RestaurantDetails GetMenuRestaurantByID(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Restaurants
                        .Single(e => e.RestaurantId == id);
                //.FirstOrDefault();
                return
                    new RestaurantDetails
                    {

                       
                        Menu = entity.Menu
                         .Select(
                                    x => new MenuListItem
                                    {
                                        MenuId = x.MenuId,
                                        Name = x.Name,
                                        Description = x.Description,
                                        Price = x.Price
                                    }
                                ).ToList()
                       

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
                entity.AreaId = category.AreaId;
                entity.Review = category.Review;
               //entity.MenuId = category.MenuId;

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
                entity.AreaId = category.AreaId;
                entity.Review = category.Review;
               // entity.MenuId = category.MenuId;

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
