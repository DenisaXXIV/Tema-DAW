using AutoMapper;
using InternsManager.BL.Interfaces;
using InternsManager.DAL.Entities;
using InternsManager.DAL.Repositories.Interfaces;
using InternsManager.TL.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternsManager.BL.Classes
{
    public class PersonLogic : IPersonLogic
    {
        private readonly IRepository<Person> _personRepository;
        private readonly IMapper _mapper;

        public PersonLogic(IRepository<Person> personRepository, IMapper mapper)
        {
            _personRepository = personRepository;
            _mapper = mapper;
        }

        public async Task AddPerson(PersonDTO personDTO)
        {
            if (personDTO == null)
            {
                throw new ArgumentNullException(nameof(personDTO));
            }
            try
            {
                var entity = _mapper.Map<Person>(personDTO);
                await _personRepository.Add(entity);
            }
            catch (DbUpdateException)
            {
                throw;
            }
        }

        public async Task<PersonDTO> GetByName(string name)
        {
            if (name == null)
            {
                throw new ArgumentNullException(nameof(name));
            }
            PersonDTO result;
            try
            {
                var results = _mapper.Map<List<PersonDTO>>(await _personRepository.GetAll());
                result = results.FirstOrDefault(a => a.Name == name) ?? throw new ArgumentNullException(nameof(name));
                if (result == null)
                {
                    throw new DbUpdateException();
                }
                return result;
            }
            catch (DbUpdateException)
            {
                throw;
            }
        }

        public async Task<List<PersonDTO>> GetAll()
        {
            var results = _mapper.Map<List<PersonDTO>>(await _personRepository.GetAll());
            return results;
        }

        public async Task<PersonDTO> GetById(int id)
        {
            PersonDTO result;
            try
            {
                var results = _mapper.Map<List<PersonDTO>>(await _personRepository.GetAll());
                result = results.FirstOrDefault(a => a.IdPerson == id) ?? throw new ArgumentNullException(nameof(id));
                if (result == null)
                {
                    throw new DbUpdateException();
                }
                return result;
            }
            catch (DbUpdateException)
            {
                throw;
            }
        }

        public async Task<bool> RemovePerson(PersonDTO personDTO)
        {
            if (personDTO == null)
            {
                throw new ArgumentNullException(nameof(personDTO));
            }
            try
            {
                await _personRepository.Delete(personDTO.IdPerson);
                return true;
            }
            catch (DbUpdateException)
            {
                throw;
            }
        }

        public async Task<bool> UpdatePerson(int id, PersonDTO newPersonDTO)
        {
            if (newPersonDTO == null)
            {
                throw new ArgumentNullException(nameof(newPersonDTO));
            }

            Person person = await _personRepository.FindById(id);

            try
            {
                var entity = _mapper.Map<Person>(newPersonDTO);
                await _personRepository.Delete(person.IdPerson);
                await _personRepository.Add(entity);
                return true;
            }
            catch (DbUpdateException)
            {
                throw;
            }
        }
    }
}
