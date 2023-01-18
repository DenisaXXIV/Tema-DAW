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
    public class RoleLogic : IRoleLogic
    {
        private readonly IRepository<Role> _roleRepository;
        private readonly IMapper _mapper;

        public RoleLogic(IRepository<Role> roleRepository, IMapper mapper)
        {
            _roleRepository = roleRepository;
            _mapper = mapper;
        }

        public async Task AddRole(RoleDTO roleDTO)
        {
            if (roleDTO == null)
            {
                throw new ArgumentNullException(nameof(roleDTO));
            }
            try
            {
                var entity = _mapper.Map<Role>(roleDTO);
                await _roleRepository.Add(entity);
            }
            catch (DbUpdateException)
            {
                throw;
            }
        }

        public async Task<RoleDTO> GetByName(string name)
        {
            if (name == null)
            {
                throw new ArgumentNullException(nameof(name));
            }
            RoleDTO result;
            try
            {
                var results = _mapper.Map<List<RoleDTO>>(await _roleRepository.GetAll());
                result = results.FirstOrDefault(a => a.RoleName == name) ?? throw new ArgumentNullException(nameof(name));
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

        public async Task<List<RoleDTO>> GetAll()
        {
            var results = _mapper.Map<List<RoleDTO>>(await _roleRepository.GetAll());
            return results;
        }

        public async Task<RoleDTO> GetById(int id)
        {
            RoleDTO result;
            try
            {
                var results = _mapper.Map<List<RoleDTO>>(await _roleRepository.GetAll());
                result = results.FirstOrDefault(a => a.IdRole == id) ?? throw new ArgumentNullException(nameof(id));
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

        public async Task<bool> RemoveRole(RoleDTO roleDTO)
        {
            if (roleDTO == null)
            {
                throw new ArgumentNullException(nameof(roleDTO));
            }
            try
            {
                await _roleRepository.Delete(roleDTO.IdRole);
                return true;
            }
            catch (DbUpdateException)
            {
                throw;
            }
        }

        public async Task<bool> UpdateRole(int id, RoleDTO newRoleDTO)
        {
            if (newRoleDTO == null)
            {
                throw new ArgumentNullException(nameof(newRoleDTO));
            }

            var role = await _roleRepository.FindById(id);

            try
            {
                var entity = _mapper.Map<Role>(newRoleDTO);
                await _roleRepository.Delete(role.IdRole);
                await _roleRepository.Add(entity);
                return true;
            }
            catch (DbUpdateException)
            {
                throw;
            }
        }
    }
}

