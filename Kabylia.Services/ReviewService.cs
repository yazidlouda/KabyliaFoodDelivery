using Kabylia.Data;
using Kabylia.Models.Review;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kabylia.Services
{
    public class ReviewService
    {
        public async Task<bool> CreateReviewAsync(ReviewCreate model)
        {
            var entity =
                new Review()
                {
                    // OwnerID = _userId,

                    Reviews = model.Reviews,
                    CustomerId = model.CustomerId,
                    RestaurantId = model.RestaurantId
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Review.Add(entity);
                return await ctx.SaveChangesAsync() == 1;
            }
        }
        public bool CreateReview(ReviewCreate model)
        {
            var entity =
                new Review()
                {

                    Reviews = model.Reviews,
                    CustomerId = model.CustomerId,
                    RestaurantId = model.RestaurantId

                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Review.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public async Task<IEnumerable<ReviewListItem>> GetReviewAsync()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = await
                    ctx
                        .Review
                        //.Where(e => e.OwnerID == _userId)
                        .Select(
                            e =>
                                new ReviewListItem
                                {
                                    
                                    ReviewId = e.ReviewId,
                                    CustomerName = e.Customer.FirstName+e.Customer.LastName,
                                    RestaurantName = e.Restaurant.Name,
                                    Reviews = e.Reviews,
                                   

                                }
                        ).ToListAsync();
                return query.OrderBy(e => e.ReviewId);
            }
        }
      
        public IEnumerable<ReviewListItem> GetReview()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Review
                        //.Where(e => e.OwnerID == _userId)
                        .Select(
                            e =>
                                new ReviewListItem
                                {
                                    ReviewId = e.ReviewId,
                                    CustomerName = e.Customer.FirstName + e.Customer.LastName,
                                    RestaurantName = e.Restaurant.Name,
                                    Reviews = e.Reviews,

                                }
                        );
                return query.ToList().OrderBy(e => e.ReviewId);
            }
        }
       
        public async Task<ReviewDetails> GetReviewByIdAsync(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {

                var entity = await
                    ctx
                        .Review
                        .Where(e => e.ReviewId == id)
                        .FirstOrDefaultAsync();
                return
                    new ReviewDetails
                    {
                        ReviewId = entity.ReviewId,
                        Reviews = entity.Reviews,
                        CustomerName = entity.Customer.FirstName+entity.Customer.LastName,
       
                        RestaurantName = entity.Restaurant.Name

                    };
            }
        }
        public ReviewDetails GetReviewById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {

                var entity =
                    ctx
                        .Review
                        .Single(e => e.ReviewId == id);
                return
                    new ReviewDetails
                    {
                        ReviewId = entity.ReviewId,
                        Reviews = entity.Reviews,
                       

                    };
            }
        }
        public async Task<bool> UpdateReviewAsync(ReviewEdit note)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = await
                    ctx
                        .Review
                        .Where(e => e.ReviewId == note.ReviewId)
                        .FirstOrDefaultAsync();
                entity.Reviews = note.Reviews;
             
                return await ctx.SaveChangesAsync() == 1;
            }
        }
        public bool UpdateReview(ReviewEdit note)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Review
                        .Where(e => e.ReviewId == note.ReviewId)
                        .FirstOrDefault();

                entity.Reviews = note.Reviews;
                return ctx.SaveChanges() == 1;
            }
        }
        public async Task<bool> DeleteReviewAsync(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = await
                    ctx
                        .Review
                        .Where(e => e.ReviewId == id)
                        .FirstOrDefaultAsync();

                ctx.Review.Remove(entity);

                return await ctx.SaveChangesAsync() == 1;
            }
        }

        public bool DeleteReview(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Review
                        .Single(e => e.ReviewId == id);

                ctx.Review.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
