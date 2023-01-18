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
    public class InternshipLogic : IInternshipLogic
    {
        private readonly IRepository<Internship> _internRepository;
        private readonly IMapper _mapper;

        public InternshipLogic(IRepository<Internship> internRepository, IMapper mapper)
        {
            _internRepository = internRepository;
            _mapper = mapper;
        }

        public async Task AddInternship(InternshipDTO internshipDTO)
        {
            if (internshipDTO == null)
            {
                throw new ArgumentNullException(nameof(internshipDTO));
            }
            try
            {
                var entity = _mapper.Map<Internship>(internshipDTO);
                await _internRepository.Add(entity);
            }
            catch (DbUpdateException)
            {
                throw;
            }
        }

        public async Task<InternshipDTO> GetByName(string name)
        {
            if (name == null)
            {
                throw new ArgumentNullException(nameof(name));
            }
            InternshipDTO result;
            try
            {
                var results = _mapper.Map<List<InternshipDTO>>(await _internRepository.GetAll());
                result = results.FirstOrDefault(a => a.Name == name);
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

        public async Task<List<InternshipDTO>> GetAll()
        {
            var results = _mapper.Map<List<InternshipDTO>>(await _internRepository.GetAll());
            return results;
        }

        public async Task<InternshipDTO> GetById(int id)
        {
            InternshipDTO result;
            try
            {
                var results = _mapper.Map<List<InternshipDTO>>(await _internRepository.GetAll());
                result = results.FirstOrDefault(a => a.IdInternship == id);
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

        public async Task<bool> RemoveInternship(InternshipDTO internshipDTO)
        {
            if (internshipDTO == null)
            {
                throw new ArgumentNullException(nameof(internshipDTO));
            }
            try
            {
                await _internRepository.Delete(internshipDTO.IdInternship);
                return true;
            }
            catch (DbUpdateException)
            {
                throw;
            }
        }

        public async Task<bool> UpdateInternship(int id, InternshipDTO newInternshipDTO)
        {
            if (newInternshipDTO == null)
            {
                throw new ArgumentNullException(nameof(newInternshipDTO));
            }

            Internship internship = await _internRepository.FindById(id);

            try
            {
                var entity = _mapper.Map<Internship>(newInternshipDTO);
                await _internRepository.Delete(internship.IdInternship);
                await _internRepository.Add(entity);
                return true;
            }
            catch (DbUpdateException)
            {
                throw;
            }
        }
    }
}
