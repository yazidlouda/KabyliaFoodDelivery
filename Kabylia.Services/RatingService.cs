using Kabylia.Data;
using Kabylia.Models.Rating;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kabylia.Services
{
    public class RatingService
    {
        public async Task<bool> CreateRatingAsync(RatingCreate model)
        {
            var entity =
                new Rating()
                {
                    // OwnerID = _userId,
                    CustomerId=model.CustomerId,
                    RestaurantId=model.RestaurantId,
                   RestaurantRating=model.RestaurantRating,
                    DeliveryDriverId=model.DeliveryDriverId,
                   DeliveryDriverRating=model.DeliveryDriverRating,
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Rating.Add(entity);
                return await ctx.SaveChangesAsync() == 1;
            }
        }
        public bool CreateRating(RatingCreate model)
        {
            var entity =
                new Rating()
                {
                    CustomerId = model.CustomerId,
                    RestaurantId = model.RestaurantId,
                    RestaurantRating = model.RestaurantRating,
                    DeliveryDriverId = model.DeliveryDriverId,
                    DeliveryDriverRating = model.DeliveryDriverRating,

                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Rating.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public async Task<IEnumerable<RatingListItem>> GetRatingAsync()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = await
                    ctx
                        .Rating
                        //.Where(e => e.OwnerID == _userId)
                        .Select(
                            e =>
                                new RatingListItem
                                {
                                    RatingId=e.RatingId,
                                    RestaurantId = e.RestaurantId,
                                    RestaurantRating = e.RestaurantRating,
                                    DeliveryDriverId = e.DeliveryDriverId,
                                    DeliveryDriverRating = e.DeliveryDriverRating,
                                    CustomerName=e.Customer.FirstName+" "+e.Customer.LastName


                                }
                        ).ToListAsync();
                return query.OrderBy(e => e.RatingId);
            }
        }

        public IEnumerable<RatingListItem> GetRating()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Rating
                        //.Where(e => e.OwnerID == _userId)
                        .Select(
                            e =>
                                new RatingListItem
                                {
                                    RatingId = e.RatingId,
                                    RestaurantId = e.RestaurantId,
                                    RestaurantRating = e.RestaurantRating,
                                    DeliveryDriverId = e.DeliveryDriverId,
                                    DeliveryDriverRating = e.DeliveryDriverRating,
                                    CustomerName = e.Customer.FirstName + " " + e.Customer.LastName

                                }
                        );
                return query.ToList().OrderBy(e => e.RatingId);
            }
        }

        public async Task<RatingDetails> GetRatingByIdAsync(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {

                var entity = await
                    ctx
                        .Rating
                        .Where(e => e.RatingId == id)
                        .FirstOrDefaultAsync();
                return
                    new RatingDetails
                    {
                        RatingId = entity.RatingId,
                        RestaurantName=entity.Restaurant.Name,
                        RestaurantRating = entity.RestaurantRating,
                        DeliveryDriverName=entity.DeliveryDriver.FirstName+" "+entity.DeliveryDriver.LastName,
                        DeliveryDriverRating = entity.DeliveryDriverRating,
                        CustomerName = entity.Customer.FirstName + " " + entity.Customer.LastName

                    };
            }
        }
        public RatingDetails GetRatingById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {

                var entity =
                    ctx
                        .Rating
                        .Single(e => e.RatingId == id);
                return
                    new RatingDetails
                    {
                        RatingId = entity.RatingId,
                        RestaurantName = entity.Restaurant.Name,
                        RestaurantRating = entity.RestaurantRating,
                        DeliveryDriverName = entity.DeliveryDriver.FirstName + " " + entity.DeliveryDriver.LastName,
                        DeliveryDriverRating = entity.DeliveryDriverRating,
                        CustomerName = entity.Customer.FirstName + " " + entity.Customer.LastName



                    };
            }
        }
        public async Task<bool> UpdateRatingAsync(RatingEdit note)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = await
                    ctx
                        .Rating
                        .Where(e => e.RatingId == note.RatingId)
                        .FirstOrDefaultAsync();
                entity.RestaurantRating = note.RestaurantRating;
                entity.DeliveryDriverRating = note.DeliveryDriverRating;

                return await ctx.SaveChangesAsync() == 1;
            }
        }
        public bool UpdateRating(RatingEdit note)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Rating
                        .Where(e => e.RatingId == note.RatingId)
                        .FirstOrDefault();

                entity.RestaurantRating = note.RestaurantRating;
                entity.DeliveryDriverRating = note.DeliveryDriverRating;
                return ctx.SaveChanges() == 1;
            }
        }
        public async Task<bool> DeleteRatingAsync(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = await
                    ctx
                        .Rating
                        .Where(e => e.RatingId == id)
                        .FirstOrDefaultAsync();

                ctx.Rating.Remove(entity);

                return await ctx.SaveChangesAsync() == 1;
            }
        }

        public bool DeleteRating(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Rating
                        .Single(e => e.RatingId == id);

                ctx.Rating.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
