using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrSystem.DataAccess.Repository.Interfaces
{
    public interface IUnitOfWork
    {
        ICompanyRepository CompanyRepository { get; }
        void Save();
    }
}
