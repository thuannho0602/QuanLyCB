using DoAnCB.DataAccess;
using DoAnCB.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnCB.Repository.Implementations
{
    public class GheGiuChoRepository : RepositoryBase<GheGiuCho, ApplicationDbContext>, IGheGiuChoRepository
    {
        public GheGiuChoRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
