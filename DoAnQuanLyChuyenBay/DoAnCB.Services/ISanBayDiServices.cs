using DoAnCB.Model.SanBayDi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnCB.Services
{
    public interface ISanBayDiServices
    {
        Task<List<SanBayDiGetResponse>> GetAll();
        Task<SanBayDiGetResponse> GetById(int Id);
        Task<SanBayDiCreateResponse> CreateSanBayDi(SanBayDiCreateRequest sanBayDiCreateRequest);
        Task<SanBayDiUpdateResponse> UpdateSanBayDi(int Id, SanBayDiUpdateRequest sanBayDiUpdateRequest);
        Task<bool> DeleteSanBayDi(int Id);
    }
}
