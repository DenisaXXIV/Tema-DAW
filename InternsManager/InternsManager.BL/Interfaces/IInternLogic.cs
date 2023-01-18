using InternsManager.TL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternsManager.BL.Interfaces
{
    public interface IInternLogic
    {
        Task AddIntern(InternDTO internDTO);
        Task<List<InternDTO>> GetAll();
        Task<InternDTO> GetById(int id);
        Task<int> GetNumberInterns();
        Task<bool> RemoveIntern(InternDTO internDTO);
        Task<bool> UpdateIntern(int id, InternDTO newInternDTO);
    }
}
