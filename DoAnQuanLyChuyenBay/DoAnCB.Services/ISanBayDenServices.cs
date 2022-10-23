using DoAnCB.Model.SanBayDen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnCB.Services
{
    public interface ISanBayDenServices
    {
        Task<List<SanBayDenGetResponse>> GetAll();
        Task<SanBayDenGetResponse> GetById(int Id);
        Task<SanBayDenCreateResponse> CreateSanBayDen(SanBayDenCreateRequest sanBayDenCreateRequest);
        Task<SanBayDenUpdateResponse> UpdateSanBayDen(int Id, SanBayDenUpdateRequest sanBayDenUpdateRequest);
        Task<bool> DeleteSanBayDi(int Id);
    }
}
