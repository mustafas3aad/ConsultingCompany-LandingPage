using ConsultingCompany.BLL.Contracts.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsultingCompany.BLL.Contracts.IUnitOfWork
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync();

        IGenericRepository<TEntity> GetRepository<TEntity>() where TEntity : class;
    }
}
