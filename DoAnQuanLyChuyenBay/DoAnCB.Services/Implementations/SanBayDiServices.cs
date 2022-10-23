using DoAnCB.DataAccess;
using DoAnCB.Entity;
using DoAnCB.Model.SanBayDi;
using DoAnCB.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnCB.Services.Implementations
{
    public class SanBayDiServices:ISanBayDiServices
    {
        private ISanBayDiRepository _sanBayDiRepository;
        private ApplicationDbContext _appContext;
        public SanBayDiServices(ISanBayDiRepository sanBayDiRepository,ApplicationDbContext appContext)
        {
            _sanBayDiRepository = sanBayDiRepository;
            _appContext = appContext;
        }

        public async Task<List<SanBayDiGetResponse>> GetAll()
        {
            var listSanBayDi = _sanBayDiRepository.FindAll().Select(c => new SanBayDiGetResponse
            {
                Id = c.Id,
                Code = c.Code,
                TenSanBayDi = c.TenSanBayDi
            }).ToList();
            return await Task.FromResult(listSanBayDi);
        }
        public async Task<SanBayDiGetResponse> GetById(int Id)
        {
            var sanBayDi = _sanBayDiRepository.FindByCondition(c=>c.Id == Id).Select(c => new SanBayDiGetResponse
            {
                Id = c.Id,
                Code = c.Code,
                TenSanBayDi = c.TenSanBayDi
            }).FirstOrDefault();
            return await Task.FromResult(sanBayDi);
        }
         public async Task<SanBayDiCreateResponse> CreateSanBayDi(SanBayDiCreateRequest sanBayDiCreateRequest)
        {
            if (sanBayDiCreateRequest.Id == 0)
            {
                var sanBayModel = new SanBayDi
                {
                    Code = sanBayDiCreateRequest.Code,
                    TenSanBayDi = sanBayDiCreateRequest.TenSanBayDi
                };
                _sanBayDiRepository.Add(sanBayModel);
                _sanBayDiRepository.SaveChanges();

                var sanBayResponse = new SanBayDiCreateResponse
                {
                    Id = sanBayModel.Id,
                    Code = sanBayModel.Code,
                    TenSanBayDi = sanBayModel.TenSanBayDi
                };
                return await Task.FromResult(sanBayResponse);

            }
            else
            {
                return new SanBayDiCreateResponse();
            }
        }
        public async Task<SanBayDiUpdateResponse> UpdateSanBayDi(int Id, SanBayDiUpdateRequest sanBayDiUpdateRequest)
        {

            if(Id > 0)
            {
                var sanBayDi = _sanBayDiRepository.FindByCondition(c => c.Id == Id).FirstOrDefault();
                if(sanBayDi != null)
                {
                    var sanbayModel = new SanBayDi
                    {
                        Id = Id,
                        Code = sanBayDiUpdateRequest.Code,
                        TenSanBayDi = sanBayDiUpdateRequest.TenSanBayDi
                    };
                    _sanBayDiRepository.Update(sanbayModel);
                    _sanBayDiRepository.SaveChanges();

                    var sanBayDiResponse = new SanBayDiUpdateResponse
                    {
                        Id = sanbayModel.Id,
                        Code = sanbayModel.Code,
                        TenSanBayDi = sanbayModel.TenSanBayDi
                    };
                    return await Task.FromResult(sanBayDiResponse);
                }
                return new SanBayDiUpdateResponse();

            }
            else
            {
                return new SanBayDiUpdateResponse();
            }

        }

        public async Task<bool> DeleteSanBayDi(int Id)
        {
            var sanbaydi = _sanBayDiRepository.FindByCondition(c => c.Id == Id).FirstOrDefault();
            if (sanbaydi != null)
            {
                _sanBayDiRepository.Remove(sanbaydi);
                _sanBayDiRepository.SaveChanges();
                return await Task.FromResult(true);
            }
            return await Task.FromResult(false);
        }
    }
}
