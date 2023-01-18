using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InternsManager.TL.DTO;

namespace InternsManager.BL.Interfaces
{
    public interface IInternshipLogic
    {
        Task AddInternship(InternshipDTO internshipDTO);
        Task<List<InternshipDTO>> GetAll();
        Task<InternshipDTO> GetById(int id);
        Task<InternshipDTO> GetByName(string name);
        Task<bool> RemoveInternship(InternshipDTO internshipDTO);
        Task<bool> UpdateInternship(int id, InternshipDTO newInternshipDTO);
    }
}
