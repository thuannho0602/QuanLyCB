using DoAnCB.Model.KhachHang;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnCB.Model.DatCho
{
    public class DatChoCreateRequest
    {
        public DateTime NgayDi { get; set; }
        public DateTime? NgayVe { get; set; }
        public int ChuyenBayID { get; set; }
        public int KhachHangID { get; set; }
    }
    public class DoanhThuThangResponse
    {
        public string TenMayBay { get; set; }
        public int MayBayID { get; set; }
        public int ChuyenBayID { get; set; }
        public decimal DoanhThu { get; set; }
        public int SoVe { get; set; }
    }
    public class DoanhThuNameResponse
    {
        public int Thang { get; set; }
        public string TenMayBay { get; set; }
        public int MayBayID { get; set; }
        public int ChuyenBayID { get; set; }
        public decimal DoanhThu { get; set; }
        public int SoChuyenBay { get; set; }
    }
    public class ThongTinKhachHangDatVeResponse
    {
        public string HoTen { get; set; }
        public string SoDienThoai { get; set; }
        public string Email { get; set; }
        public string NgayDi { get; set; }
        public string NgayVe { get; set; }
        public string GioDi { get; set; }
        //public string SoGhe { get; set; }
        public string TenMayBay { get; set; }
    }

    public class DatChoInfo
    {
        public DatChoCreateRequest DatCho { get; set; }
        public KhachHangCreateRequest KhachHang { get; set; }
        public List<GheGiuChoInfo> GheGiuChos { get; set; }
    }
}
