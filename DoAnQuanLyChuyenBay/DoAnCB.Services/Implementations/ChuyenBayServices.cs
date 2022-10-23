using DoAnCB.DataAccess;
using DoAnCB.Entity;
using DoAnCB.Model.ChuyenBay;
using DoAnCB.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnCB.Services.Implementations
{
    public class ChuyenBayServices : IChuyenBayServices
    {
        private IChuyenBayRepository _chuyenBayRepository;
        private ApplicationDbContext _appContext;
        public ChuyenBayServices(IChuyenBayRepository chuyenBayRepository, ApplicationDbContext appContext)
        {
            _chuyenBayRepository = chuyenBayRepository;
            _appContext = appContext;
        }
        public async Task<ChuyenBayCreateResponse> CreateChuyenBay(ChuyenBayCreateRequest chuyenBayCreateRequest)
        {
            if (chuyenBayCreateRequest.Id == 0)
            {
                var chuyenbay = new ChuyenBay
                {
                    GioKhoiHanh = TimeSpan.Parse(chuyenBayCreateRequest.GioKhoiHanh),//chuyenBayCreateRequest.GioKhoiHanh,
                    Gia = chuyenBayCreateRequest.Gia,
                    ThoiGian = chuyenBayCreateRequest.ThoiGian,
                    MayBayID = chuyenBayCreateRequest.MayBayID,
                    SanBayDenID = chuyenBayCreateRequest.SanBayDenID,
                    SanBayDiID = chuyenBayCreateRequest.SanBayDiID
                };
                _chuyenBayRepository.Add(chuyenbay);
                _chuyenBayRepository.SaveChanges();

                var chuyenbayResponse = new ChuyenBayCreateResponse
                {
                    Id = chuyenbay.Id,
                    GioKhoiHanh = chuyenbay.GioKhoiHanh.ToString("hh\\:mm"),
                    Gia = chuyenbay.Gia,
                    ThoiGian = chuyenbay.ThoiGian,
                    MayBayID = chuyenbay.MayBayID,
                    TenMayBay = _appContext.MayBays.Where(x => x.Id == chuyenbay.MayBayID).FirstOrDefault().TenMayBay,
                    SanBayDiID = chuyenbay.SanBayDiID,
                    TenSanBayDi = _appContext.SanBayDis.Where(x => x.Id == chuyenbay.SanBayDiID).FirstOrDefault().TenSanBayDi,
                    SanBayDenID = chuyenbay.SanBayDenID,
                    TenSanBayDen = _appContext.SanBayDens.Where(x => x.Id == chuyenbay.SanBayDenID).FirstOrDefault().TenSanBayDden,

                };
                return await Task.FromResult(chuyenbayResponse);
            }
            return new ChuyenBayCreateResponse();

        }

        public async Task<bool> DeleteMaybay(int Id)
        {
            var chuyenbay = _chuyenBayRepository.FindByCondition(c => c.Id == Id).FirstOrDefault();
            if (chuyenbay != null)
            {
                _chuyenBayRepository.Remove(chuyenbay);
                _chuyenBayRepository.SaveChanges();
                return await Task.FromResult(true);
            }
            return false;

        }

        public async Task<List<ChuyenBayGetResponse>> GetAll()
        {
            var listChuyenBay = _chuyenBayRepository.FindAll().Select(c => new ChuyenBayGetResponse
            {
                Id = c.Id,
                Gia = c.Gia,
                GioKhoiHanh = c.GioKhoiHanh.ToString("hh\\:mm"),
                ThoiGian = c.ThoiGian,
                MayBayID = c.MayBayID,
                TenMayBay = _appContext.MayBays.Where(x => x.Id == c.MayBayID).FirstOrDefault().TenMayBay,
                SanBayDiID = c.SanBayDiID,
                TenSanBayDi = _appContext.SanBayDis.Where(x => x.Id == c.SanBayDiID).FirstOrDefault().TenSanBayDi,
                SanBayDenID = c.SanBayDenID,
                TenSanBayDen = _appContext.SanBayDens.Where(x => x.Id == c.SanBayDenID).FirstOrDefault().TenSanBayDden,
            }).ToList();
            return await Task.FromResult(listChuyenBay);
        }

        public async Task<ChuyenBayGetResponse> GetById(int Id)
        {
            var chuyenbay = _chuyenBayRepository.FindByCondition(c => c.Id == Id).Select(c => new ChuyenBayGetResponse
            {
                Id = c.Id,
                Gia = c.Gia,
                GioKhoiHanh = c.GioKhoiHanh.ToString("hh\\:mm"),
                ThoiGian = c.ThoiGian,
                MayBayID = c.MayBayID,
                TenMayBay = _appContext.MayBays.Where(x => x.Id == c.MayBayID).FirstOrDefault().TenMayBay,
                SanBayDiID = c.SanBayDiID,
                TenSanBayDi = _appContext.SanBayDis.Where(x => x.Id == c.SanBayDiID).FirstOrDefault().TenSanBayDi,
                SanBayDenID = c.SanBayDenID,
                TenSanBayDen = _appContext.SanBayDens.Where(x => x.Id == c.SanBayDenID).FirstOrDefault().TenSanBayDden,
            }).FirstOrDefault();
            return await Task.FromResult(chuyenbay);
        }

        public async Task<List<ChuyenBayGetResponse>> GetChuyenBayBySanBay(ChuyenBayBySanBayRequest chuyenBayBySanBayRequest)
        {
            var listChuyenBay = _chuyenBayRepository.FindByCondition(c => c.SanBayDenID == chuyenBayBySanBayRequest.SanBayDenID && c.SanBayDiID == chuyenBayBySanBayRequest.SanBayDiID).Select(c => new ChuyenBayGetResponse
            {
                Id = c.Id,
                Gia = c.Gia,
                GioKhoiHanh = c.GioKhoiHanh.ToString("hh\\:mm"),
                ThoiGian = c.ThoiGian,
                MayBayID = c.MayBayID,
                TenMayBay = _appContext.MayBays.Where(x => x.Id == c.MayBayID).FirstOrDefault().TenMayBay,
                SanBayDiID = c.SanBayDiID,
                TenSanBayDi = _appContext.SanBayDis.Where(x => x.Id == c.SanBayDiID).FirstOrDefault().TenSanBayDi,
                SanBayDenID = c.SanBayDenID,
                TenSanBayDen = _appContext.SanBayDens.Where(x => x.Id == c.SanBayDenID).FirstOrDefault().TenSanBayDden,
            }).ToList();
            return await Task.FromResult(listChuyenBay);
        }
        public async Task<ChuyenBayUpdateResponse> UpdateChuyenBay(int Id, ChuyenBayUpdateRequest chuyenBayUpdateRequest)
        {
            var chuyenbay = _chuyenBayRepository.FindByCondition(c => c.Id == Id).FirstOrDefault();
            if (chuyenbay != null)
            {
                chuyenbay = new ChuyenBay
                {
                    Id = Id,
                    GioKhoiHanh = TimeSpan.Parse(chuyenBayUpdateRequest.GioKhoiHanh),
                    Gia = chuyenBayUpdateRequest.Gia,
                    ThoiGian = chuyenBayUpdateRequest.ThoiGian,
                    MayBayID = chuyenBayUpdateRequest.MayBayID,
                    SanBayDenID = chuyenBayUpdateRequest.SanBayDenID,
                    SanBayDiID = chuyenBayUpdateRequest.SanBayDiID
                };
                _chuyenBayRepository.Update(chuyenbay);
                _chuyenBayRepository.SaveChanges();

                var chuyenbayResponse = new ChuyenBayUpdateResponse
                {
                    Id = chuyenbay.Id,
                    GioKhoiHanh = chuyenbay.GioKhoiHanh.ToString("hh\\:mm"),
                    Gia = chuyenbay.Gia,
                    ThoiGian = chuyenbay.ThoiGian,
                    MayBayID = chuyenbay.MayBayID,
                    TenMayBay = _appContext.MayBays.Where(x => x.Id == chuyenbay.MayBayID).FirstOrDefault().TenMayBay,
                    SanBayDiID = chuyenbay.SanBayDiID,
                    TenSanBayDi = _appContext.SanBayDis.Where(x => x.Id == chuyenbay.SanBayDiID).FirstOrDefault().TenSanBayDi,
                    SanBayDenID = chuyenbay.SanBayDenID,
                    TenSanBayDen = _appContext.SanBayDens.Where(x => x.Id == chuyenbay.SanBayDenID).FirstOrDefault().TenSanBayDden,

                };
                return await Task.FromResult(chuyenbayResponse);
            }
            return new ChuyenBayUpdateResponse();
        }
    }
}
