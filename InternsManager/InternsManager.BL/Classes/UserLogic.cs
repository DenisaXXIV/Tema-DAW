using AutoMapper;
using InternsManager.BL.Interfaces;
using InternsManager.DAL.Entities;
using InternsManager.DAL.Repositories.Interfaces;
using InternsManager.TL.DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bCrypt = BCrypt.Net.BCrypt;

namespace InternsManager.BL.Classes
{
    public class UserLogic : IUserLogic
    {
        private readonly IRepository<User> _userRepository;
        private readonly IMapper _mapper;

        public UserLogic(IRepository<User> userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task AddUser(UserDTO userDTO)
        {
            if (userDTO == null)
            {
                throw new ArgumentNullException(nameof(userDTO));
            }
            try
            {
                var entity = _mapper.Map<User>(userDTO);
                await _userRepository.Add(entity);
            }
            catch (DbUpdateException)
            {
                throw;
            }
        }

        public async Task<List<UserDTO>> GetAll()
        {
            var results = _mapper.Map<List<UserDTO>>(await _userRepository.GetAll());
            return results;
        }

        public async Task<UserDTO> GetById(int id)
        {
            UserDTO result;
            try
            {
                var results = _mapper.Map<List<UserDTO>>(await _userRepository.GetAll());
                result = results.FirstOrDefault(a => a.IdUser == id) ?? throw new ArgumentNullException(nameof(id));
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

        public async Task<UserDTO> GetByUsername(string username)
        {
            UserDTO result;
            try
            {
                var results = _mapper.Map<List<UserDTO>>(await _userRepository.GetAll());
                result = results.FirstOrDefault(a => a.Username == username) ?? throw new ArgumentNullException(nameof(username));
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

        public async Task<bool> RemoveUser(UserDTO adminDTO)
        {
            if (adminDTO == null)
            {
                throw new ArgumentNullException(nameof(adminDTO));
            }
            try
            {
                await _userRepository.Delete(adminDTO.IdUser);
                return true;
            }
            catch (DbUpdateException)
            {
                throw;
            }
        }

        public async Task<bool> UpdateUser(int id, UserDTO newUserDTO)
        {
            if (newUserDTO == null)
            {
                throw new ArgumentNullException(nameof(newUserDTO));
            }

            User oldUser = await _userRepository.FindById(id);

            try
            {
                if (!bCrypt.Verify(newUserDTO.Password, oldUser.Password))
                {
                    newUserDTO.Password = bCrypt.HashPassword(newUserDTO.Password);
                }
                var entity = _mapper.Map<User>(newUserDTO);
                await _userRepository.Delete(oldUser.IdUser);
                await _userRepository.Add(entity);
                return true;
            }
            catch (DbUpdateException)
            {
                throw;
            }
        }
    }
}
