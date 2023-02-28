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
    internal class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private readonly ApplicationDbContext _db;

        public CategoryRepository(ApplicationDbContext db) :base (db)
        {
            _db = db;
        }
    }
}
