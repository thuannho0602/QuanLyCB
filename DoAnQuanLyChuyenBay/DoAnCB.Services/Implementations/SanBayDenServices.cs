using DoAnCB.DataAccess;
using DoAnCB.Entity;
using DoAnCB.Model.SanBayDen;
using DoAnCB.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnCB.Services.Implementations
{
    public class SanBayDenServices:ISanBayDenServices
    {
        private ISanBayDenRepository _sanBayDenRepository;
        private ApplicationDbContext _appContext;
        public SanBayDenServices(ISanBayDenRepository sanBayDenRepository, ApplicationDbContext appContext)
        {
            _sanBayDenRepository = sanBayDenRepository;
            _appContext = appContext;
        }

        public async Task<List<SanBayDenGetResponse>> GetAll()
        {
            var listSanBayDi = _sanBayDenRepository.FindAll().Select(c => new SanBayDenGetResponse
            {
                Id = c.Id,
                Code = c.Code,
                TenSanBayDden = c.TenSanBayDden
            }).ToList();
            return await Task.FromResult(listSanBayDi);
        }
        public async Task<SanBayDenGetResponse> GetById(int Id)
        {
            var sanBayDi = _sanBayDenRepository.FindByCondition(c => c.Id == Id).Select(c => new SanBayDenGetResponse
            {
                Id = c.Id,
                Code = c.Code,
                TenSanBayDden = c.TenSanBayDden
            }).FirstOrDefault();
            return await Task.FromResult(sanBayDi);
        }
        public async Task<SanBayDenCreateResponse> CreateSanBayDen(SanBayDenCreateRequest sanBayDenCreateRequest)
        {
            if (sanBayDenCreateRequest.Id == 0)
            {
                var sanBayModel = new SanBayDen
                {
                    Code = sanBayDenCreateRequest.Code,
                    TenSanBayDden = sanBayDenCreateRequest.TenSanBayDden
                };
                _sanBayDenRepository.Add(sanBayModel);
                _sanBayDenRepository.SaveChanges();

                var sanBayResponse = new SanBayDenCreateResponse
                {
                    Id = sanBayModel.Id,
                    Code = sanBayModel.Code,
                    TenSanBayDden = sanBayModel.TenSanBayDden
                };
                return await Task.FromResult(sanBayResponse);

            }
            else
            {
                return new SanBayDenCreateResponse();
            }
        }
        public async Task<SanBayDenUpdateResponse> UpdateSanBayDen(int Id, SanBayDenUpdateRequest sanBayDenUpdateRequest)
        {

            if (Id > 0)
            {
                var sanBayDi = _sanBayDenRepository.FindByCondition(c => c.Id == Id).FirstOrDefault();
                if (sanBayDi != null)
                {
                    var sanbayModel = new SanBayDen
                    {
                        Id = Id,
                        Code = sanBayDenUpdateRequest.Code,
                        TenSanBayDden = sanBayDenUpdateRequest.TenSanBayDden
                    };
                    _sanBayDenRepository.Update(sanbayModel);
                    _sanBayDenRepository.SaveChanges();

                    var sanBayDiResponse = new SanBayDenUpdateResponse
                    {
                        Id = sanbayModel.Id,
                        Code = sanbayModel.Code,
                        TenSanBayDden = sanbayModel.TenSanBayDden
                    };
                    return await Task.FromResult(sanBayDiResponse);
                }
                return new SanBayDenUpdateResponse();

            }
            else
            {
                return new SanBayDenUpdateResponse();
            }

        }

        public async Task<bool> DeleteSanBayDi(int Id)
        {
            var sanbayden = _sanBayDenRepository.FindByCondition(c => c.Id == Id).FirstOrDefault();
            if (sanbayden != null)
            {
                _sanBayDenRepository.Remove(sanbayden);
                _sanBayDenRepository.SaveChanges();
                return await Task.FromResult(true);
            }
            return await Task.FromResult(false);
        }
    }
}
