﻿using Darts.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace Darts.DAL.Repositories
{
    public class PlayersRepository<T> : IRepository<T> where T : Entity, new()
    {
        private readonly DbContext context;
        private readonly DbSet<T> dbSet;

        public PlayersRepository(DbContext context)
        {
            this.context = context;
            dbSet = context.Set<T>();
        }

        public async Task<T> Add(T entity)
        {
            var result =  await dbSet.AddAsync(entity);
            return result.Entity;
        }

        public void Delete(T entity)
        {
            dbSet.Remove(entity);
        }

        public async Task Delete(int id)
        {
            T data = await dbSet.FindAsync(id);
            dbSet.Remove(data);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await dbSet.ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await dbSet.FindAsync(id);
        }

        public void Update(T entity)
        {
            context.Entry(entity).State = EntityState.Modified;
        }
    }
}
