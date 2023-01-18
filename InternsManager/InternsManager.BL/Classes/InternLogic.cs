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
    public class InternLogic : IInternLogic
    {
        private readonly IRepository<Intern> _internRepository;
        private readonly IMapper _mapper;

        public InternLogic(IRepository<Intern> internRepository, IMapper mapper)
        {
            _internRepository = internRepository;
            _mapper = mapper;
        }

        public async Task AddIntern(InternDTO internDTO)
        {
            if (internDTO == null)
            {
                throw new ArgumentNullException(nameof(internDTO));
            }
            try
            {
                var entity = _mapper.Map<Intern>(internDTO);
                await _internRepository.Add(entity);
            }
            catch (DbUpdateException)
            {
                throw;
            }
        }


        public async Task<List<InternDTO>> GetAll()
        {
            var results = _mapper.Map<List<InternDTO>>(await _internRepository.GetAll());
            return results;
        }

        public async Task<InternDTO> GetById(int id)
        {
            InternDTO result;
            try
            {
                var results = _mapper.Map<List<InternDTO>>(await _internRepository.GetAll());
                result = results.FirstOrDefault(a => a.IdIntern == id);
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

        public async Task<int> GetNumberInterns()
        {
            int number = 0;
            try
            {
                var results = _mapper.Map<List<InternDTO>>(await _internRepository.GetAll());
                number = results.Count();

                return number;
            }
            catch (DbUpdateException)
            {
                throw;
            }
        }

        public async Task<bool> RemoveIntern(InternDTO internDTO)
        {
            if (internDTO == null)
            {
                throw new ArgumentNullException(nameof(internDTO));
            }
            try
            {
                await _internRepository.Delete(internDTO.IdIntern);
                return true;
            }
            catch (DbUpdateException)
            {
                throw;
            }
        }

        public async Task<bool> UpdateIntern(int id, InternDTO newInternDTO)
        {
            if (newInternDTO == null)
            {
                throw new ArgumentNullException(nameof(newInternDTO));
            }

            Intern oldIntern = await _internRepository.FindById(id);

            try
            {
                var entity = _mapper.Map<Intern>(newInternDTO);
                await _internRepository.Delete(oldIntern.IdIntern);
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
