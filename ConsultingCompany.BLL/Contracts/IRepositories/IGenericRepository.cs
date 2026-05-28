using ConsultingCompany.BLL.Contracts.Specifications;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsultingCompany.BLL.Contracts.Repositories
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAllAsync();

        Task<TEntity?> GetByIdAsync(int id);

        Task AddAsync(TEntity entity);

        void Remove(TEntity entity);

        void Update(TEntity entity);

        Task<IEnumerable<TEntity>> GetAllAsync(ISpecifications<TEntity> specifications);

        Task<TEntity?> GetByIdAsync(ISpecifications<TEntity> specifications);

        Task<int> CountAsync(ISpecifications<TEntity> specifications);


    }
}
