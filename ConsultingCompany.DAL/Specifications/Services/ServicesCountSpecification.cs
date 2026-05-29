using ConsultingCompany.DAL.Entities;
using ConsultingCompany.Shared.QueryParams.services;

namespace ConsultingCompany.DAL.Specifications.Services
{
    public class ServicesCountSpecification
        : BaseSpecifications<Service>
    {
        public ServicesCountSpecification(
            ServiceQueryParams param)

            : base(s =>

                s.IsActive

                &&

                (string.IsNullOrEmpty(param.Search)
                ||
                s.Name.ToLower()
                .Contains(param.Search.ToLower()))
            )
        {
        }
    }
}
