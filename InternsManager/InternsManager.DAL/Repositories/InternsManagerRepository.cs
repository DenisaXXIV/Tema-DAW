﻿using InternsManager.DAL.Entities;
using InternsManager.DAL.Migrations;
using InternsManager.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternsManager.DAL.Repositories
{
    public class InternsManagerRepository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;

        public InternsManagerRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<T> Add(T entity)
        {
            if (entity != null)
            {
                _context.Set<T>().Add(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            throw new DbUpdateException();
        }

        public async Task<T> Delete(int id)
        {
            T entity = await _context.Set<T>().FindAsync(id);
            if (entity == null)
            {
                return null;
            }
            try
            {
                _context.Set<T>().Remove(entity);
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

        public async Task<T> FindById(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException(nameof(id));
            }
            var result = await _context.Set<T>().FindAsync(id);
            if (result != null)
            {
                return result;
            }
            throw new DbUpdateException();
        }

        public async Task<List<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }



        public async Task<T> Update(T entity)
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
