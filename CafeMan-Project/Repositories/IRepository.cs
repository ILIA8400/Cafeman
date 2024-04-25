namespace CafeMan_Project.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        ICollection<TEntity> GetAll();
        TEntity? GetById(int id);
        void Insert(TEntity entity);
        void Update(TEntity entity);
        void Delete(int entityId);
        void Save();
    }
}
