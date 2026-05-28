using System;
using System.Collections.Generic;
using System.Text;

namespace ConsultingCompany.BLL.Contracts.IDataInitializer
{
    public interface IDataInitializer
    {
        Task InitializeAsync();
    }
}
