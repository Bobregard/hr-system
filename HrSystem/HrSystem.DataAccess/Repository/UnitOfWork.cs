using HrSystem.DataAccess.Data;
using HrSystem.DataAccess.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrSystem.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            CompanyRepository = new CompanyRepository(_db);
        }

        public ICompanyRepository CompanyRepository { get; private set; }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
