using CafeMan_Project.Models.Dal;
using CafeMan_Project.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CafeMan_Project.Repositories
{
    public class CafeRepo : IRepository<Cafe>
    {
        private readonly CafemanDbContext ctx;

        public CafeRepo(CafemanDbContext ctx)
        {
            this.ctx = ctx;
        }

        public async void Delete(int entityId)
        {
            var cafe = await ctx.Cafes.SingleOrDefaultAsync(c => c.CafeId == entityId);

            if (cafe != null)
                ctx.Remove(cafe);
        }

        public async Task<List<Cafe>> GetAll()
        {
            return await ctx.Cafes.ToListAsync();
        }

        public Task<Cafe?> GetById(int Id)
        {
            return ctx.Cafes.SingleOrDefaultAsync(c => c.CafeId == Id);
        }

        public async void Insert(Cafe entity)
        {
            await ctx.AddAsync(entity);
        }

        public async void Save()
        {
            await ctx.SaveChangesAsync();
        }

        public void Update(Cafe entity)
        {
            ctx.Update(entity);
        }

        //رنکینگ کافه ها
        public ICollection<Cafe> GetCafeRanking()
        {
            var cafes = ctx.Cafes
                           .Select(c => new
                           {
                               Cafe = c,
                               AverageStar = ctx.Comments
                                               .Where(comment => comment.CafeId == c.CafeId)
                                               .Average(comment => (double?)comment.Star) ?? 0
                           })
                           .OrderByDescending(c => c.AverageStar)
                           .Select(c => c.Cafe)
                           .ToList();

            return cafes;
        }


        //با توجه به توضیحات شما، شما می‌خواهید فیلد Star در اینتیتی Cafe بر اساس میانگین Star نظرات مردم محاسبه شود
        public void UpdateCafeStars()
        {
            var cafes = ctx.Cafes.Include(c => c.Comments).ToList();

            foreach (var cafe in cafes)
            {
                if (cafe.Comments != null && cafe.Comments.Any())
                {
                    cafe.Star = cafe.Comments.Average(comment => comment.Star);
                }
                else
                {
                    cafe.Star = 0;
                }
            }

            ctx.SaveChanges();
        }



    }
}
