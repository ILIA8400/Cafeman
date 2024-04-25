using CafeMan_Project.Models.Dal;
using CafeMan_Project.Models.Entities;

namespace CafeMan_Project.Repositories
{
    public class EdibleRepo : IRepository<Edibles>
    {
        private readonly CafemanDbContext ctx;

        public EdibleRepo(CafemanDbContext ctx)
        {
            this.ctx = ctx;
        }

        public void Delete(int entityId)
        {
            var edible = ctx.Edibles.SingleOrDefault(c => c.EdiblesId == entityId);

            if (edible != null)
                ctx.Remove(edible);
        }

        public ICollection<Edibles> GetAll()
        {
            return ctx.Edibles.ToList();
        }

        public Edibles? GetById(int id)
        {
            return ctx.Edibles.SingleOrDefault(c => c.EdiblesId == id);
        }

        public void Insert(Edibles entity)
        {
            ctx.Add(entity);
        }

        public void Save()
        {
            ctx.SaveChanges();
        }

        public void Update(Edibles entity)
        {
            ctx.Update(entity);
        }
    }
}
