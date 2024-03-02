using Entities;
using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Repositories;

namespace DataAccess.Abstract
{
    public interface ICategoryRepository : IRepository<Category>
    {
    }
}
