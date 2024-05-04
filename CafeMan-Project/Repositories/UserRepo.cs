using CafeMan_Project.Models.Dal;
using CafeMan_Project.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CafeMan_Project.Repositories
{
    public class UserRepo : IRepository<User>
    {
        private readonly CafemanDbContext ctx;

        public UserRepo(CafemanDbContext ctx)
        {
            this.ctx = ctx;
        }

        public async void Delete(int entityId)
        {
            var user = await ctx.Users.SingleOrDefaultAsync(c => c.UserId == entityId);

            if (user != null)
                ctx.Remove(user);
        }

        public Task<List<User>> GetAll()
        {
            return ctx.Users.ToListAsync();
        }

        public Task<User?> GetById(int id)
        {
            return ctx.Users.SingleOrDefaultAsync(c => c.UserId == id);
        }

        public async void Insert(User entity)
        {
            await ctx.AddAsync(entity);
        }

        public async void Save()
        {
            await ctx.SaveChangesAsync();
        }

        public void Update(User entity)
        {
            ctx.Update(entity);
        }
    }
}
