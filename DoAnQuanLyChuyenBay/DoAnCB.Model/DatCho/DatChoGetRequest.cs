using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnCB.Model.DatCho
{
    public class DatChoGetRequest
    {
        public int Id { get; set; }
        public string MaCho { get; set; }
        public DateTime NgayDi { get; set; }
        public DateTime? NgayVe { get; set; }
        public int ChuyenBayID { get; set; }
        public int KhachHangID { get; set; }
    }
}
