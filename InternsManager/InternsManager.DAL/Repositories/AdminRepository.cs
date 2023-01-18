using InternsManager.DAL.Entities;
using InternsManager.DAL.Migrations;
using InternsManager.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bCrypt = BCrypt.Net.BCrypt;

namespace InternsManager.DAL.Repositories
{
    public class AdminRepository : IRepository<User>
    {
        private readonly ApplicationDbContext _context;

        public AdminRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<User> Add(User entity)
        {
            if (entity != null)
            {
                _context.Set<User>().Add(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            throw new DbUpdateException();
        }

        public async Task<User> AddAdmin(User entity)
        {
            if (entity != null)
            {
                var entities = _context.Set<User>().ToListAsync();
                bool unique = true;
                foreach (var myEntity in entities.Result)
                {
                    if (myEntity.Username == entity.Username && myEntity.Password == entity.Password)
                    {
                        unique = false;
                        throw new ArgumentException("This user already exist");
                    }

                    if (myEntity.Username == entity.Username)
                    {
                        unique = false;
                        throw new ArgumentException("This username is already used");
                    }

                    if (myEntity.Password == entity.Password)
                    {
                        unique = false;
                        throw new ArgumentException("This password is already used");
                    }
                }

                if (unique == true)
                {
                    entity.Password = bCrypt.HashPassword(entity.Password).ToString();
                    _context.Set<User>().Add(entity);
                    await _context.SaveChangesAsync();
                    return entity;
                }
            }

            throw new DbUpdateException();
        }


        public async Task<User> Delete(int id)
        {
            User entity = await _context.Set<User>().FindAsync(id);
            if (entity == null)
            {
                return null;
            }
            try
            {
                _context.Set<User>().Remove(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            catch (DbUpdateException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<User> FindById(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException(nameof(id));
            }
            var result = await _context.Set<User>().FindAsync(id);
            if (result != null)
            {
                return result;
            }
            throw new DbUpdateException();
        }

        public async Task<List<User>> GetAll()
        {
            return await _context.Set<User>().ToListAsync();
        }



        public async Task<User> Update(User entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            try
            {
                _context.Entry(entity).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return entity;
            }
            catch (DbUpdateException)
            {
                throw;
            }
        }
    }
}
