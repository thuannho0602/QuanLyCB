using DoAnCB.Entity;
using DoAnCB.Model.SanBayDi;
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
    public class SanBayDiController : BaseController
    {
        private ISanBayDiServices _sanBayDiServices;

        public SanBayDiController(ISanBayDiServices sanBayDiServices)
        {
            _sanBayDiServices = sanBayDiServices;
        }
        [HttpGet]
        public async Task<IEnumerable<SanBayDiGetResponse>> GetAll()
        {
            return await _sanBayDiServices.GetAll();
        }
        [HttpGet("{Id}")]
        public async Task<SanBayDiGetResponse> GetById(int Id)
        {
            return await _sanBayDiServices.GetById(Id);
        }
        [HttpPost]
        public async Task<SanBayDiCreateResponse> Create(SanBayDiCreateRequest sanBayDiCreateRequest)
        {
            return await _sanBayDiServices.CreateSanBayDi(sanBayDiCreateRequest);
        }
        [HttpPut("{Id}")]
        public async Task<SanBayDiUpdateResponse> Update(int Id,SanBayDiUpdateRequest sanBayDiUpdateRequest)
        {
            return await _sanBayDiServices.UpdateSanBayDi(Id,sanBayDiUpdateRequest);
        }
        [HttpDelete("{Id}")]
        public async Task<bool> Delete(int Id)
        {
            return await _sanBayDiServices.DeleteSanBayDi(Id);
        }
    }
}
