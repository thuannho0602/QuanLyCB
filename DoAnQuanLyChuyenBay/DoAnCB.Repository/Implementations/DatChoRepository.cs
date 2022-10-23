using DoAnCB.DataAccess;
using DoAnCB.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnCB.Repository.Implementations
{
    public class DatChoRepository : RepositoryBase<DatCho, ApplicationDbContext>, IDatChoRepository
    {
        public DatChoRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
