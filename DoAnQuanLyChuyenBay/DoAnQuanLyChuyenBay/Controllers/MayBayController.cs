using DoAnCB.Model.MayBay;
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
    public class MayBayController : BaseController
    {
        private IMayBayServices _maybayServices;

        public MayBayController(IMayBayServices maybayServices)
        {
            _maybayServices = maybayServices;
        }
        [HttpGet]
        public async Task<IEnumerable<MayBayGetResponse>> GetAll()
        {
            return await _maybayServices.GetAll();
        }
        [HttpGet("{Id}")]
        public async Task<MayBayGetResponse> GetById(int Id)
        {
            return await _maybayServices.GetById(Id);
        }
        [HttpPost]
        public async Task<MayBayCreateResponse> Create(MayBayCreateRequest mayBayCreateRequest)
        {
            return await _maybayServices.CreateMayBay(mayBayCreateRequest);
        }
        [HttpPut("{Id}")]
        public async Task<MayBayUpdateResponse> Update(int Id, MaybayUpdateRequest maybayUpdateRequest)
        {
            return await _maybayServices.UpdateMayBay(Id, maybayUpdateRequest);
        }
        [HttpDelete("{Id}")]
        public async Task<bool> Delete(int Id)
        {
            return await _maybayServices.DeleteMaybay(Id);
        }
    }
}
