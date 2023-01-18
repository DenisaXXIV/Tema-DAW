using InternsManager.TL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternsManager.BL.Interfaces
{
    public interface IPersonLogic
    {
        Task AddPerson(PersonDTO personDTO);
        Task<List<PersonDTO>> GetAll();
        Task<PersonDTO> GetById(int id);
        Task<PersonDTO> GetByName(string name);
        Task<bool> RemovePerson(PersonDTO personDTO);
        Task<bool> UpdatePerson(int id, PersonDTO newPersonDTO);
    }
}
