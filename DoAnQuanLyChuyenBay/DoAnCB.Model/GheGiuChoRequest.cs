using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnCB.Model
{
    public class GheGiuChoRequest
    {
        public DateTime NgayDi { get; set; }
        public DateTime? NgayVe { get; set; }
        public int ChuyenBayID { get; set; }
    }
    public class GheGiuChoInfo
    {
        public string MaCho { get; set; }
    }
}
