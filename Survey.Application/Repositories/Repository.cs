using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Survey.Application.Repositories.Interfaces;
using Survey.Domain.Common;
using Survey.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Survey.Application.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly SurveyDbContext _dbContext;

        public Repository(SurveyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> Create(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            return await Save();
        }

        public async Task<T> Find(Expression<Func<T, bool>> expression)
        {
            return await _dbContext.Set<T>().AsNoTracking().FirstOrDefaultAsync(expression);
        }

        public async Task<List<T>> GetAll()
        {
            return await _dbContext.Set<T>().AsQueryable().AsNoTracking().ToListAsync();
        }

        public async Task<List<T>> GetAll(Expression<Func<T, bool>> expression)
        {
            return await _dbContext.Set<T>().AsQueryable().AsNoTracking().Where(expression).ToListAsync();
        }

        public async Task<int> Update(T entity)
        {
            _dbContext.Set<T>().Update(entity);
            return await Save();
        }

        public async Task<int> Save()
        {
            return await _dbContext.SaveChangesAsync();
        }
        public async Task<bool> Any(Expression<Func<T, bool>> expression)
        {
            return await _dbContext.Set<T>().AsNoTracking().AnyAsync(expression);
        }
        public async Task<int> Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            return await Save();
        }
    }
}
