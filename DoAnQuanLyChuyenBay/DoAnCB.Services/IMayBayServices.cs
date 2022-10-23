using DoAnCB.Model.MayBay;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnCB.Services
{
    public interface IMayBayServices
    {
        Task<List<MayBayGetResponse>> GetAll();
        Task<MayBayGetResponse> GetById(int Id);
        Task<MayBayCreateResponse> CreateMayBay(MayBayCreateRequest mayBayCreateRequest);
        Task<MayBayUpdateResponse> UpdateMayBay(int Id, MaybayUpdateRequest maybayUpdateRequest);
        Task<bool> DeleteMaybay(int Id);
    }
}
