using CafeMan_Project.Models.Dal;
using CafeMan_Project.Models.Entities;

namespace CafeMan_Project.Repositories
{
    public class UserRepo : IRepository<User>
    {
        private readonly CafemanDbContext ctx;

        public UserRepo(CafemanDbContext ctx)
        {
            this.ctx = ctx;
        }

        public void Delete(int entityId)
        {
            var user = ctx.Users.SingleOrDefault(c => c.UserId == entityId);

            if (user != null)
                ctx.Remove(user);
        }

        public ICollection<User> GetAll()
        {
            return ctx.Users.ToList();
        }

        public User? GetById(int id)
        {
            return ctx.Users.SingleOrDefault(c => c.UserId == id);
        }

        public void Insert(User entity)
        {
            ctx.Add(entity);
        }

        public void Save()
        {
            ctx.SaveChanges();
        }

        public void Update(User entity)
        {
            ctx.Update(entity);
        }
    }
}
