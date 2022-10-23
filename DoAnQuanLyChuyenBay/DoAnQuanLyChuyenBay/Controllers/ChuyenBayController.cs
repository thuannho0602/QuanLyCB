using DoAnCB.Model.ChuyenBay;
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
    public class ChuyenBayController : BaseController
    {
        private IChuyenBayServices _chuyenBayServices;

        public ChuyenBayController(IChuyenBayServices chuyenBayServices)
        {
            _chuyenBayServices = chuyenBayServices;
        }
        [HttpGet]
        public async Task<IEnumerable<ChuyenBayGetResponse>> GetAll()
        {
            return await _chuyenBayServices.GetAll();
        }
        [HttpGet("{Id}")]
        public async Task<ChuyenBayGetResponse> GetById(int Id)
        {
            return await _chuyenBayServices.GetById(Id);
        }
        [HttpPost]
        public async Task<ChuyenBayCreateResponse> Create(ChuyenBayCreateRequest chuyenBayCreateRequest)
        {
            return await _chuyenBayServices.CreateChuyenBay(chuyenBayCreateRequest);
        }
        [HttpPut("{Id}")]
        public async Task<ChuyenBayUpdateResponse> Update(int Id, ChuyenBayUpdateRequest chuyenBayUpdateRequest)
        {
            return await _chuyenBayServices.UpdateChuyenBay(Id, chuyenBayUpdateRequest);
        }
        [HttpDelete("{Id}")]
        public async Task<bool> Delete(int Id)
        {
            return await _chuyenBayServices.DeleteMaybay(Id);
        }

        [HttpPost("ChuyenBayBySanBay")]
        public async Task<IEnumerable<ChuyenBayGetResponse>> GetChuyenBayBySanBay(ChuyenBayBySanBayRequest chuyenBayBySanBayRequest)
        {
            return await _chuyenBayServices.GetChuyenBayBySanBay(chuyenBayBySanBayRequest);
        }
    }
}
