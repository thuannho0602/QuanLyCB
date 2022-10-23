using DoAnCB.Model.SanBayDen;
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
    public class SanBayDenController : BaseController
    {
        private ISanBayDenServices _sanBayDenServices;

        public SanBayDenController(ISanBayDenServices sanBayDenServices)
        {
            _sanBayDenServices = sanBayDenServices;
        }
        [HttpGet]
        public async Task<IEnumerable<SanBayDenGetResponse>> GetAll()
        {
            return await _sanBayDenServices.GetAll();
        }
        [HttpGet("{Id}")]
        public async Task<SanBayDenGetResponse> GetById(int Id)
        {
            return await _sanBayDenServices.GetById(Id);
        }
        [HttpPost]
        public async Task<SanBayDenCreateResponse> Create(SanBayDenCreateRequest sanBayDenCreateRequest)
        {
            return await _sanBayDenServices.CreateSanBayDen(sanBayDenCreateRequest);
        }
        [HttpPut("{Id}")]
        public async Task<SanBayDenUpdateResponse> Update(int Id, SanBayDenUpdateRequest sanBayDenUpdateRequest)
        {
            return await _sanBayDenServices.UpdateSanBayDen(Id, sanBayDenUpdateRequest);
        }
        [HttpDelete("{Id}")]
        public async Task<bool> Delete(int Id)
        {
            return await _sanBayDenServices.DeleteSanBayDi(Id);
        }
    }
}
