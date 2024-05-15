namespace CafeMan_Project.Repositories
{
    public interface IUserRepository<User>
    {
        Task<List<User>> GetAll();
        Task<User?> GetById(string id);
    
    }
}
