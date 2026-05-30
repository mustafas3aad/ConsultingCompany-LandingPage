using ConsultingCompany.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsultingCompany.DAL.Specifications.NewsletterSubscribers
{
    public class NewsletterSubscriberByEmailSpecification
     : BaseSpecifications<NewsletterSubscriber>
    {
        public NewsletterSubscriberByEmailSpecification(string email)
            : base(x => x.Email == email)
        {
        }
    }
}
