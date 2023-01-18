using InternsManager.TL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternsManager.BL.Interfaces
{
    public interface IUserLogic
    {
        Task AddUser(UserDTO auserDTO);
        Task<List<UserDTO>> GetAll();
        Task<UserDTO> GetById(int id);
        Task<UserDTO> GetByUsername(string username);
        Task<bool> RemoveUser(UserDTO userDTO);
        Task<bool> UpdateUser(int id, UserDTO userDTO);
    }
}
