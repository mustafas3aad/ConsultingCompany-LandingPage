using System;
using System.Collections.Generic;
using System.Text;

namespace ConsultingCompany.DAL.Data.DataSeed
{
    public interface IDataInitializer
    {
        Task InitializeAsync();
    }
}
