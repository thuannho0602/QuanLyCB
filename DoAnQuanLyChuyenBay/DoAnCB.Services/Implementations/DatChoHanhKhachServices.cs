using DoAnCB.DataAccess;
using DoAnCB.Entity;
using DoAnCB.Model;
using DoAnCB.Model.DatCho;
using DoAnCB.Model.KhachHang;
using DoAnCB.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnCB.Services.Implementations
{
    public class DatChoHanhKhachServices : IDatChoHanhKhachServices
    {
        private IGheGiuChoRepository _giuChoRepository;
        private IKhachHangRepository _khachHangRepository;
        private IDatChoRepository _datChoRepository;
        private ApplicationDbContext _appContext;
        public DatChoHanhKhachServices(IGheGiuChoRepository giuChoRepository, IKhachHangRepository khachHangRepository, IDatChoRepository datChoRepository, ApplicationDbContext appContext)
        {
            _giuChoRepository = giuChoRepository;
            _khachHangRepository = khachHangRepository;
            _datChoRepository = datChoRepository;
            _appContext = appContext;
        }
        public async Task<List<GheGiuChoResponse>> GetGheGiuCho(GheGiuChoRequest gheGiuChoRequest)
        {
            try
            {
                var listGiuCho = (from datcho in _datChoRepository.FindByCondition(c => c.NgayDi == gheGiuChoRequest.NgayDi.Date && (c.NgayVe == null ||(c.NgayVe == null ? c.NgayVe == null : c.NgayVe.Value.Date == (gheGiuChoRequest.NgayVe == null? gheGiuChoRequest.NgayVe : gheGiuChoRequest.NgayVe.Value.Date))) && c.ChuyenBayID == gheGiuChoRequest.ChuyenBayID)
                                  join khachhang in _khachHangRepository.FindAll() on datcho.KhachHangID equals khachhang.Id
                                  join giucho in _giuChoRepository.FindAll() on datcho.Id equals giucho.DatChoId
                                  select new GheGiuChoResponse
                                  {
                                      DatChoId = datcho.Id,
                                      Id = giucho.Id,
                                      MaCho = giucho.MaCho.Trim()
                                  }).ToList();

                return await Task.FromResult(listGiuCho);
            }
            catch (Exception ex)
            {

                return new List<GheGiuChoResponse>();
            }
           
        }
        public async Task<int> CreateKhachHanh(KhachHangCreateRequest khachHang)
        {
            if (khachHang != null)
            {
                var khachHangDB = new KhachHang
                {
                    HoTen = khachHang.HoTen,
                    SoDienThoai = khachHang.SoDienThoai,
                    Email = khachHang.Email,
                    NgayThangNamSinh = khachHang.NgayThangNamSinh,
                    GioiTinh = khachHang.GioiTinh,
                };
                _khachHangRepository.Add(khachHangDB);
                _khachHangRepository.SaveChanges();
                return await Task.FromResult(khachHangDB.Id);
            }
            return -1;
        }
        public async Task<int> CreateDatCho(DatChoCreateRequest datcho)
        {
            if (datcho != null)
            {
                var datchoDB = new DatCho
                {
                    NgayDi = datcho.NgayDi,
                    NgayVe = datcho.NgayVe,
                    ChuyenBayID = datcho.ChuyenBayID,
                    KhachHangID = datcho.KhachHangID,
                };
                _datChoRepository.Add(datchoDB);
                _datChoRepository.SaveChanges();
                return await Task.FromResult(datchoDB.Id);
            }
            return -1;
        }
        public async Task<bool> CreateGheGiuCho(int DatChoId, GheGiuChoInfo datcho)
        {
            var lstgiucho = datcho.MaCho.Split(",");


            if (lstgiucho.Any())
            {
                foreach (var item in lstgiucho)
                {
                    var ghegiucho = new GheGiuCho
                    {
                        DatChoId = DatChoId,
                        MaCho = item
                    };
                    _giuChoRepository.Add(ghegiucho);
                }
                _giuChoRepository.SaveChanges();
                return await Task.FromResult(true);
            }
            return false;
        }
        public async Task<bool> CreateDatCho(DatChoInfo datChoInfo)
        {
            if(datChoInfo.KhachHang != null)
            {
                var khachHang = new KhachHang
                {
                    HoTen = datChoInfo.KhachHang.HoTen,
                    SoDienThoai = datChoInfo.KhachHang.SoDienThoai,
                    Email = datChoInfo.KhachHang.Email,
                    NgayThangNamSinh = datChoInfo.KhachHang.NgayThangNamSinh,
                    GioiTinh = datChoInfo.KhachHang.GioiTinh,
                };
                _khachHangRepository.Add(khachHang);
                _khachHangRepository.SaveChanges();
                var datcho = new DatCho
                {
                    NgayDi = datChoInfo.DatCho.NgayDi,
                    NgayVe = datChoInfo.DatCho.NgayVe,
                    ChuyenBayID = datChoInfo.DatCho.ChuyenBayID,
                    KhachHangID = khachHang.Id,
                };
                _datChoRepository.Add(datcho);
                _datChoRepository.SaveChanges();

                if (datChoInfo.GheGiuChos.Any())
                {
                    foreach (var item in datChoInfo.GheGiuChos)
                    {
                        var ghegiucho = new GheGiuCho
                        {
                            DatChoId = datcho.Id,
                            MaCho = item.MaCho
                        };
                        _giuChoRepository.Add(ghegiucho);
                    }
                    _giuChoRepository.SaveChanges();
                }
            }


            return await Task.FromResult(true);
        }

        public async Task<List<DoanhThuThangResponse>> GetBaoCaoDanhThuTheoThang(int thang)
        {
            var list = (from datcho in _datChoRepository.FindAll()
                        join chuyenbay in _appContext.ChuyenBays on datcho.ChuyenBayID equals chuyenbay.Id
                        join maybay in _appContext.MayBays on chuyenbay.MayBayID equals maybay.Id
                        select new
                        {
                            DatChoId = datcho.Id,
                            Thang = datcho.NgayDi.Month,
                            ChuyenBayID = chuyenbay.Id,
                            MayBayID = chuyenbay.MayBayID,
                            DoanhThu = chuyenbay.Gia,
                            TenMayBay = maybay.TenMayBay
                        }).ToList();

            list = list.Where(c => c.Thang == thang).ToList();
            var listGroup = list.GroupBy(c => new {c.TenMayBay,  c.ChuyenBayID, c.MayBayID }).Select(c => new DoanhThuThangResponse
            {
                TenMayBay = c.Key.TenMayBay,
                MayBayID = c.Key.MayBayID,
                ChuyenBayID = c.Key.ChuyenBayID,
                DoanhThu = c.Sum(x=>x.DoanhThu),
                SoVe = c.Count()
            }).ToList();

            return await Task.FromResult(listGroup);
        }
        public async Task<List<DoanhThuNameResponse>> GetBaoCaoDanhThuTheoNam(int nam)
        {
            var list = (from datcho in _datChoRepository.FindAll()
                        join chuyenbay in _appContext.ChuyenBays on datcho.ChuyenBayID equals chuyenbay.Id
                        join maybay in _appContext.MayBays on chuyenbay.MayBayID equals maybay.Id
                        select new
                        {
                            DatChoId = datcho.Id,
                            Thang = datcho.NgayDi.Month,
                            Nam = datcho.NgayDi.Year,
                            ChuyenBayID = chuyenbay.Id,
                            MayBayID = chuyenbay.MayBayID,
                            DoanhThu = chuyenbay.Gia,
                            TenMayBay = maybay.TenMayBay
                        }).ToList();

            list = list.Where(c => c.Nam == nam).ToList();
            var listGroup = list.GroupBy(c => new { c.Thang, c.TenMayBay, c.MayBayID }).Select(c => new DoanhThuNameResponse
            {
                Thang = c.Key.Thang,
                TenMayBay = c.Key.TenMayBay,
                MayBayID = c.Key.MayBayID,
                DoanhThu = c.Sum(x => x.DoanhThu),
                SoChuyenBay = c.Count()
            }).ToList();

            return await Task.FromResult(listGroup);
        }

        public async Task<List<ThongTinKhachHangDatVeResponse>> GetThongTinHanhKhachDatVe()
        {

            var list = (from datcho in _datChoRepository.FindAll()
                        join chuyenbay in _appContext.ChuyenBays on datcho.ChuyenBayID equals chuyenbay.Id
                        join maybay in _appContext.MayBays on chuyenbay.MayBayID equals maybay.Id
                        join khachhang in _khachHangRepository.FindAll() on datcho.KhachHangID equals khachhang.Id
                        //join ghe in _giuChoRepository.FindAll() on datcho.Id equals ghe.DatChoId
                        select new ThongTinKhachHangDatVeResponse
                        {
                           HoTen = khachhang.HoTen,
                           SoDienThoai= khachhang.SoDienThoai,
                           Email = khachhang.Email,
                           GioDi = chuyenbay.GioKhoiHanh.ToString("hh\\:mm"),
                           NgayDi = datcho.NgayDi.ToString(@"dd/MM/yyyy"),
                           NgayVe = datcho.NgayVe.HasValue ? datcho.NgayVe.Value.ToString(@"dd/MM/yyyy") : null,
                           TenMayBay = maybay.TenMayBay,
                           //SoGhe = string.Join(",", _giuChoRepository.FindByCondition(c=>c.DatChoId == datcho.Id).Select(c=>c.MaCho).ToList())
                        }).ToList();
            return await Task.FromResult(list);

        }
    }
}
