using CafeMan_Project.Models.Entities;

namespace CafeMan_Project.Repositories
{
    public interface ICafeRepository<Cafe> where Cafe : class
    {
        Task<List<Cafe>> GetAll();
        Task<Cafe?> GetById(int id);
        Task Insert(Cafe entity);
        void Update(Cafe entity);
        Task Delete(int entityId);
        Task Save();

        Task<List<Cafe>> GetOwnerCafe();
        Task<List<Cafe>> GetAllOrdderByRank();

    }
}
