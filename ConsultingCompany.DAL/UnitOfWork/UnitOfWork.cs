using ConsultingCompany.BLL.Contracts.IUnitOfWork;
using ConsultingCompany.BLL.Contracts.Repositories;
using ConsultingCompany.DAL.Data.Context;
using ConsultingCompany.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsultingCompany.DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _dbContext;
        private readonly Dictionary<Type, object> _repositories = [];

        public UnitOfWork(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IGenericRepository<TEntity> GetRepository<TEntity>() where TEntity : class
        {
            var entityType = typeof(TEntity);

            if (_repositories.TryGetValue(entityType, out object? repository))
            {
                return (IGenericRepository<TEntity>)repository;
            }
            var newRepo = new GenericRepository<TEntity>(_dbContext);
            _repositories[entityType] = newRepo;
            return newRepo;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }
    }
}
