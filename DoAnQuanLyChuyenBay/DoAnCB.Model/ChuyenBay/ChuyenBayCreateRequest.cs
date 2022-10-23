using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnCB.Model.ChuyenBay
{
    public class ChuyenBayCreateRequest
    {
        public int Id { get; set; }
        public string GioKhoiHanh { get; set; }
        public int ThoiGian { get; set; }
        public decimal Gia { get; set; }
        public int SanBayDiID { get; set; }
        public int SanBayDenID { get; set; }
        public int MayBayID { get; set; }
    }
}
