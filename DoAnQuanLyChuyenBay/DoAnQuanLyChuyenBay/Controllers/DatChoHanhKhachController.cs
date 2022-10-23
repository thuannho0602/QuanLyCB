using DoAnCB.Model;
using DoAnCB.Model.DatCho;
using DoAnCB.Model.KhachHang;
using DoAnCB.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoAnCB.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DatChoHanhKhachController : BaseController
    {
        private IDatChoHanhKhachServices _datChoHanhKhachServices;
        public DatChoHanhKhachController(IDatChoHanhKhachServices datChoHanhKhachServices)
        {
            _datChoHanhKhachServices = datChoHanhKhachServices;
        }
        [HttpPost("GiuCho")]
        public async Task<IEnumerable<GheGiuChoResponse>> GetGiuCho(GheGiuChoRequest gheGiuChoRequest)
        {
            return await _datChoHanhKhachServices.GetGheGiuCho(gheGiuChoRequest);
        }
        [HttpPost("KhachHang")]
        public async Task<int> CreateKhachHang(KhachHangCreateRequest khachHang)
        {
            return await _datChoHanhKhachServices.CreateKhachHanh(khachHang);
        }
        [HttpPost("CreateDatCho")]
        public async Task<int> CreateDatCho(DatChoCreateRequest datcho)
        {
            return await _datChoHanhKhachServices.CreateDatCho(datcho);
        }
        [HttpPost("{DatChoId}/GheGiuCho")]
        public async Task<bool> CreateGheGiuCho(int DatChoId, GheGiuChoInfo giucho)
        {
            return await _datChoHanhKhachServices.CreateGheGiuCho(DatChoId, giucho);
        }
        [HttpPost("GetBaoCaoDanhThuTheoThang/{thang}")]
        public async Task<List<DoanhThuThangResponse>> GetBaoCaoDanhThuTheoThang(int thang)
        {
            return await _datChoHanhKhachServices.GetBaoCaoDanhThuTheoThang(thang);
        }
        [HttpPost("GetBaoCaoDanhThuTheoNam/{nam}")]
        public async Task<List<DoanhThuNameResponse>> GetBaoCaoDanhThuTheoNam(int nam)
        {
            return await _datChoHanhKhachServices.GetBaoCaoDanhThuTheoNam(nam);
        }
        [HttpGet("GetThongTinHanhKhachDatVe")]
        public async Task<List<ThongTinKhachHangDatVeResponse>> GetThongTinHanhKhachDatVe()
        {
            return await _datChoHanhKhachServices.GetThongTinHanhKhachDatVe();
        }
    }
}
