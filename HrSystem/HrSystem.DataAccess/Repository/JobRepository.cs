using HrSystem.DataAccess.Data;
using HrSystem.DataAccess.Repository.Interfaces;
using HrSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrSystem.DataAccess.Repository
{
    public class JobRepository : Repository<Job>, IJobRepository 
    {
        private readonly ApplicationDbContext _db;

        public JobRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
    }
}
