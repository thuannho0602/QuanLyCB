using DoAnCB.Model.ChuyenBay;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnCB.Services
{
    public interface IChuyenBayServices
    {
        Task<List<ChuyenBayGetResponse>> GetAll();
        Task<ChuyenBayGetResponse> GetById(int Id);
        Task<ChuyenBayCreateResponse> CreateChuyenBay(ChuyenBayCreateRequest chuyenBayCreateRequest);
        Task<ChuyenBayUpdateResponse> UpdateChuyenBay(int Id, ChuyenBayUpdateRequest chuyenBayUpdateRequest);
        Task<bool> DeleteMaybay(int Id);
        Task<List<ChuyenBayGetResponse>> GetChuyenBayBySanBay(ChuyenBayBySanBayRequest chuyenBayBySanBayRequest);
    }
}
