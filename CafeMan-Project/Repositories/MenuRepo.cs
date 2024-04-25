using CafeMan_Project.Models.Dal;
using CafeMan_Project.Models.Entities;

namespace CafeMan_Project.Repositories
{
    public class MenuRepo : IRepository<Menu>
    {
        private readonly CafemanDbContext ctx;

        public MenuRepo(CafemanDbContext ctx)
        {
            this.ctx = ctx;
        }

        public void Delete(int entityId)
        {
            var menu = ctx.Menus.SingleOrDefault(c => c.MenuId == entityId);

            if (menu != null)
                ctx.Remove(menu);
        }

        public ICollection<Menu> GetAll()
        {
            return ctx.Menus.ToList();
        }

        public Menu? GetById(int id)
        {
            return ctx.Menus.SingleOrDefault(c => c.MenuId == id);
        }

        public void Insert(Menu entity)
        {
            ctx.Add(entity);
        }

        public void Save()
        {
            ctx.SaveChanges();
        }

        public void Update(Menu entity)
        {
            ctx.Update(entity);
        }
    }
}
