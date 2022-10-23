using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnCB.Model.KhachHang
{
    public class KhachHangGetResponse
    {
        public int Id { get; set; }
        public string HoTen { get; set; }
        public string SoDienThoai { get; set; }
        public string Email { get; set; }
        public string NgayThangNamSinh { get; set; }
        public bool GioiTinh { get; set; }
    }
}
