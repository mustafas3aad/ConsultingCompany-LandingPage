using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ConsultingCompany.BLL.Contracts.Specifications
{
    public interface ISpecifications<TEntity> where TEntity : class
    {
        public ICollection<Expression<Func<TEntity, object>>> IncludeExpressions { get; }
        public ICollection<string> IncludeStrings { get; }
        public Expression<Func<TEntity, bool>> Criteria { get; }
        public Expression<Func<TEntity, object>> OrderBy { get; }
        public Expression<Func<TEntity, object>> OrderByDescending { get; }
        public int Take { get; }
        public int Skip { get; }
        public bool IsPaginated { get; }
        bool IgnoreQueryFilters { get; }
    }
}
