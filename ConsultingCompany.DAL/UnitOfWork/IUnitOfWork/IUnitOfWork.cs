using ConsultingCompany.DAL.Repositories.IRepositories;

namespace ConsultingCompany.DAL.UnitOfWork
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync();

        IGenericRepository<TEntity> GetRepository<TEntity>() where TEntity : class;
    }
}
