using CafeMan_Project.Models.Entities;

namespace CafeMan_Project.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<List<TEntity>> GetAll();
        Task<TEntity?> GetById(int id);
        void Insert(TEntity entity);
        void Update(TEntity entity);
        void Delete(int entityId);
        void Save();
    }
}
