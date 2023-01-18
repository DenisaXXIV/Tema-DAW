using InternsManager.TL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternsManager.BL.Interfaces
{
    public interface IRoleLogic
    {
        Task AddRole(RoleDTO roleDTO);
        Task<List<RoleDTO>> GetAll();
        Task<RoleDTO> GetById(int id);
        Task<RoleDTO> GetByName(string name);
        Task<bool> RemoveRole(RoleDTO roleDTO);
        Task<bool> UpdateRole(int id, RoleDTO newRoleDTO);
    }
}
