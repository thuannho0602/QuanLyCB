using DoAnCB.DataAccess;
using DoAnCB.Entity;
using DoAnCB.Model.MayBay;
using DoAnCB.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnCB.Services.Implementations
{
    public class MayBayServices : IMayBayServices
    {
        private IMayBayRepository _mayBayRepository;
        private ApplicationDbContext _appContext;
        public MayBayServices(IMayBayRepository mayBayRepository, ApplicationDbContext appContext)
        {
            _mayBayRepository = mayBayRepository;
            _appContext = appContext;
        }
        public async Task<MayBayCreateResponse> CreateMayBay(MayBayCreateRequest mayBayCreateRequest)
        {
            if (mayBayCreateRequest.Id == 0)
            {
                var maybay = new MayBay
                {
                    TenMayBay = mayBayCreateRequest.TenMayBay,
                };
                _mayBayRepository.Add(maybay);
                _mayBayRepository.SaveChanges();

                var maybayResponse = new MayBayCreateResponse
                {
                    Id = maybay.Id,
                    TenMayBay = maybay.TenMayBay,
                };
                return await Task.FromResult(maybayResponse);

            }
            else
            {
                return new MayBayCreateResponse();
            }
        }

        public async Task<bool> DeleteMaybay(int Id)
        {
            var maybay = _mayBayRepository.FindByCondition(c => c.Id == Id).FirstOrDefault();
            if (maybay != null)
            {
                _mayBayRepository.Remove(maybay);
                _mayBayRepository.SaveChanges();
                return await Task.FromResult(true);
            }
            return await Task.FromResult(false);
        }

        public async Task<List<MayBayGetResponse>> GetAll()
        {
            var listMayBay = _mayBayRepository.FindAll().Select(c => new MayBayGetResponse
            {
                Id = c.Id,
                TenMayBay = c.TenMayBay
            }).ToList();
            return await Task.FromResult(listMayBay);
        }

        public async Task<MayBayGetResponse> GetById(int Id)
        {
            var maybay = _mayBayRepository.FindAll().Select(c => new MayBayGetResponse
            {
                Id = c.Id,
                TenMayBay = c.TenMayBay
            }).FirstOrDefault();
            return await Task.FromResult(maybay);
        }

        public async Task<MayBayUpdateResponse> UpdateMayBay(int Id, MaybayUpdateRequest maybayUpdateRequest)
        {
            if (Id > 0)
            {
                var sanBayDi = _mayBayRepository.FindByCondition(c => c.Id == Id).FirstOrDefault();
                if (sanBayDi != null)
                {
                    var maybay = new MayBay
                    {
                        Id = Id,
                        TenMayBay = maybayUpdateRequest.TenMayBay,
                    };
                    _mayBayRepository.Update(maybay);
                    _mayBayRepository.SaveChanges();

                    var maybayResponse = new MayBayUpdateResponse
                    {
                        Id = maybay.Id,
                        TenMayBay = maybay.TenMayBay
                    };
                    return await Task.FromResult(maybayResponse);
                }
                return new MayBayUpdateResponse();

            }
            else
            {
                return new MayBayUpdateResponse();
            }
        }
    }
}
