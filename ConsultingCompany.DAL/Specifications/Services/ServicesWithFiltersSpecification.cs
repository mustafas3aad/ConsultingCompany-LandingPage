using ConsultingCompany.DAL.Entities;
using ConsultingCompany.Shared.QueryParams.services;

namespace ConsultingCompany.DAL.Specifications.Services
{
    public class ServicesWithPaginationSpecification
        : BaseSpecifications<Service>
    {
        public ServicesWithPaginationSpecification(
            ServiceQueryParams param)

            : base(s => s.IsActive && (string.IsNullOrEmpty(param.Search)
                || s.Name.ToLower().Contains(param.Search.ToLower())))  
        {
            ApplyPagination(
                param.PageSize,
                param.PageIndex);

            AddOrderBy(s => s.Name);
        }
    }
}
