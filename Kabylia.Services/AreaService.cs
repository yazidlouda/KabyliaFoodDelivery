using Kabylia.Data;
using Kabylia.Models.Area;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kabylia.Services
{
    public class AreaService
    {
        public async Task<bool> CreateAreaAsync(AreaCreate model)
        {
            var entity =
                new Area()
                {
                    // OwnerID = _userId,

                    AreaName = model.AreaName,


                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Area.Add(entity);
                return await ctx.SaveChangesAsync() == 1;
            }
        }
        public bool CreateMenu(AreaCreate model)
        {
            var entity =
                new Area()
                {

                    AreaName = model.AreaName,


                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Area.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public async Task<IEnumerable<AreaListItem>> GetAreaAsync()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = await
                    ctx
                        .Area
                        //.Where(e => e.OwnerID == _userId)
                        .Select(
                            e =>
                                new AreaListItem
                                {
                                    AreaId = e.AreaId,
                                    AreaName = e.AreaName,




                                }
                        ).ToListAsync();
                return query.OrderBy(e => e.AreaId);
            }
        }

        public IEnumerable<AreaListItem> GetArea()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Area
                        //.Where(e => e.OwnerID == _userId)
                        .Select(
                            e =>
                                new AreaListItem
                                {
                                    AreaId = e.AreaId,
                                    AreaName = e.AreaName,



                                }
                        );
                return query.ToList().OrderBy(e => e.AreaId);
            }
        }
        public async Task<AreaDetails> GetAreaByIdAsync(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {

                var entity = await
                    ctx
                        .Area
                        .Where(e => e.AreaId == id)
                        .FirstOrDefaultAsync();
                return
                    new AreaDetails
                    {
                        AreaId = entity.AreaId,
                        AreaName = entity.AreaName,



                    };
            }
        }
        public AreaDetails GetAreaById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {

                var entity =
                    ctx
                        .Area
                        .Single(e => e.AreaId == id);
                return
                    new AreaDetails
                    {
                        AreaId = entity.AreaId,

                        AreaName = entity.AreaName,



                    };
            }
        }
        public async Task<bool> UpdateAreaAsync(AreaEdit note)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = await
                    ctx
                        .Area
                        .Where(e => e.AreaId == note.AreaId)
                        .FirstOrDefaultAsync();
                entity.AreaName = note.AreaName;

                return await ctx.SaveChangesAsync() == 1;
            }
        }
        public bool UpdateMenu(AreaEdit note)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Area
                        .Where(e => e.AreaId == note.AreaId)
                        .FirstOrDefault();

                entity.AreaName = note.AreaName;



                return ctx.SaveChanges() == 1;
            }
        }
        public async Task<bool> DeleteAreaAsync(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = await
                    ctx
                        .Area
                        .Where(e => e.AreaId == id)
                        .FirstOrDefaultAsync();

                ctx.Area.Remove(entity);

                return await ctx.SaveChangesAsync() == 1;
            }
        }

        public bool DeleteArea(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Area
                        .Single(e => e.AreaId == id);

                ctx.Area.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
