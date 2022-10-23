using DoAnCB.DataAccess;
using DoAnCB.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnCB.Repository.Implementations
{
    public class SanBayDiRepository : RepositoryBase<SanBayDi, ApplicationDbContext>, ISanBayDiRepository
    {
        public SanBayDiRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
