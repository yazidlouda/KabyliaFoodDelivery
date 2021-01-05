using Kabylia.Data;
using Kabylia.Models.Menu;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kabylia.Services
{
    public class MenuService
    {
        public async Task<bool> CreateMenuAsync(MenuCreate model)
        {
            var entity =
                new Menu()
                {
                    // OwnerID = _userId,

                    Name = model.Name,
                    Price = model.Price,
                    Description = model.Description,
                   RestaurantId=model.RestaurantId
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Menu.Add(entity);
                return await ctx.SaveChangesAsync() == 1;
            }
        }
        public bool CreateMenu(MenuCreate model)
        {
            var entity =
                new Menu()
                {

                    Name = model.Name,
                    Price = model.Price,
                    Description = model.Description,
                    RestaurantId = model.RestaurantId

                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Menu.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public async Task<IEnumerable<MenuListItem>> GetMenuAsync()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = await
                    ctx
                        .Menu
                        //.Where(e => e.OwnerID == _userId)
                        .Select(
                            e =>
                                new MenuListItem
                                {
                                    MenuId = e.MenuId,
                                    Name = e.Name,
                                    Description = e.Description,
                                    Price = e.Price,
                                   //RestaurantId=e.RestaurantId,
                                  // RestaurantName=e.Restaurant.Name

                                }
                        ).ToListAsync();
                return query.OrderBy(e => e.MenuId);
            }
        }
        public async Task<IEnumerable<SelectableMenu>> GetSelectableMenuAsync()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = await
                    ctx
                        .Menu
                        //.Where(e => e.OwnerID == _userId)
                        .Select(
                            e =>
                                new SelectableMenu
                                {
                                    MenuId = e.MenuId,
                                    Name = e.Name,
                                    Description = e.Description,
                                    Price = e.Price,
                                    Select=e.Select
                                    //RestaurantId=e.RestaurantId,
                                    // RestaurantName=e.Restaurant.Name

                                }
                        ).ToListAsync();
                return query.OrderBy(e => e.MenuId);
            }
        }
        public IEnumerable<MenuListItem> GetMenu()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Menu
                        //.Where(e => e.OwnerID == _userId)
                        .Select(
                            e =>
                                new MenuListItem
                                {
                                    MenuId = e.MenuId,
                                    Name = e.Name,
                                    Description = e.Description,
                                    Price = e.Price,
                                   // RestaurantId = e.RestaurantId,
                                   // RestaurantName = e.Restaurant.Name

                                }
                        );
                return query.ToList().OrderBy(e => e.MenuId);
            }
        }
        public IEnumerable<SelectableMenu> GetSelectableMenu()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Menu
                        //.Where(e => e.OwnerID == _userId)
                        .Select(
                            e =>
                                new SelectableMenu
                                {
                                    MenuId = e.MenuId,
                                    Name = e.Name,
                                    Description = e.Description,
                                    Price = e.Price,
                                    Select=e.Select
                                    // RestaurantId = e.RestaurantId,
                                    // RestaurantName = e.Restaurant.Name

                                }
                        );
                return query.ToList().OrderBy(e => e.MenuId);
            }
        }
        public async Task<MenuDetails> GetMenuByIdAsync(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {

                var entity = await
                    ctx
                        .Menu
                        .Where(e => e.MenuId == id)
                        .FirstOrDefaultAsync();
                return
                    new MenuDetails
                    {
                        MenuId = entity.MenuId,
                        Name = entity.Name,
                        Description = entity.Description,
                        Price = entity.Price,
                        RestaurantId = entity.RestaurantId,
                        RestaurantName = entity.Restaurant.Name

                    };
            }
        }
        public MenuDetails GetMenuById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {

                var entity =
                    ctx
                        .Menu
                        .Single(e => e.MenuId == id);
                return
                    new MenuDetails
                    {
                        MenuId = entity.MenuId,

                        Name = entity.Name,
                        Description = entity.Description,
                        Price = entity.Price,
                        RestaurantId = entity.RestaurantId,
                        RestaurantName = entity.Restaurant.Name

                    };
            }
        }
        public async Task<bool> UpdateMenuAsync(MenuEdit note)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = await
                    ctx
                        .Menu
                        .Where(e => e.MenuId == note.MenuId)
                        .FirstOrDefaultAsync();
                entity.Name = note.Name;
                entity.Description = note.Description;
                entity.Price = note.Price;
                //entity.RestaurantId = note.RestaurantId;
                return await ctx.SaveChangesAsync() == 1;
            }
        }
        public bool UpdateMenu(MenuEdit note)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Menu
                        .Where(e => e.MenuId == note.MenuId)
                        .FirstOrDefault();

                entity.Name = note.Name;
                entity.Description = note.Description;
                entity.Price = note.Price;
               // entity.RestaurantId = note.RestaurantId;


                return ctx.SaveChanges() == 1;
            }
        }
        public async Task<bool> DeleteMenuAsync(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = await
                    ctx
                        .Menu
                        .Where(e => e.MenuId == id)
                        .FirstOrDefaultAsync();

                ctx.Menu.Remove(entity);

                return await ctx.SaveChangesAsync() == 1;
            }
        }

        public bool DeleteMenu(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Menu
                        .Single(e => e.MenuId == id);

                ctx.Menu.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
