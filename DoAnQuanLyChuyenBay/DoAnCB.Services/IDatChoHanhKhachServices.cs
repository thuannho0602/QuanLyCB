using DoAnCB.Model;
using DoAnCB.Model.DatCho;
using DoAnCB.Model.KhachHang;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnCB.Services
{
    public interface IDatChoHanhKhachServices
    {
        Task<List<GheGiuChoResponse>> GetGheGiuCho(GheGiuChoRequest gheGiuChoRequest);
        Task<bool> CreateDatCho(DatChoInfo datChoInfo);
        Task<int> CreateKhachHanh(KhachHangCreateRequest khachHang);
        Task<int> CreateDatCho(DatChoCreateRequest datcho);
        Task<bool> CreateGheGiuCho(int DatChoId, GheGiuChoInfo datcho);
        Task<List<ThongTinKhachHangDatVeResponse>> GetThongTinHanhKhachDatVe();
        Task<List<DoanhThuThangResponse>> GetBaoCaoDanhThuTheoThang(int thang);
        Task<List<DoanhThuNameResponse>> GetBaoCaoDanhThuTheoNam(int nam);

    }
}
