using DoAnCB.DataAccess;
using DoAnCB.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnCB.Repository.Implementations
{
    public class SanBayDenRepository : RepositoryBase<SanBayDen, ApplicationDbContext>, ISanBayDenRepository
    {
        public SanBayDenRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
