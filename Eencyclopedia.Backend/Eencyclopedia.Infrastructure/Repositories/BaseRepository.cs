using System.Linq.Expressions;
using Eencyclopedia.Domain.Abstractions;
using Eencyclopedia.Domain.Entities;
using Eencyclopedia.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Eencyclopedia.Infrastructure.Repositories;

public class BaseRepository<T>(EencyclopediaDbContext context) 
    : IBaseRepository<T> where T : class
{
    private readonly EencyclopediaDbContext _context= context;

    public async Task<List<T>> GetAllAsync(
        params Expression<Func<T, object>>[] includes)
    {
        var query =  _context.Set<T>().AsQueryable();

        return await includes
            .Aggregate(query, (current, next) => current.Include(next))
            .ToListAsync();
    }

    public async Task<List<T>> GetByConditionsAsync(
        Expression<Func<T, bool>> expression,
        params Expression<Func<T, object>>[] includes)
    {
        var query = _context.Set<T>()
            .Where(expression)
            .AsQueryable();

        return await includes
            .Aggregate(query, (current, next) => current.Include(next))
            .ToListAsync();
    }

    public async Task<T?> GetSingleByConditionAsync(
        Expression<Func<T, bool>> expression,
        params Expression<Func<T, object>>[] includes)
    {
        var result = context.Set<T>()
            .Where(expression)
            .AsQueryable();

        return await includes
            .Aggregate(result, (current, next) => current.Include(next))
            .FirstOrDefaultAsync();


    }

    public async Task InsertAsync(T entity)
    {
        await _context.Set<T>().AddAsync(entity);
    }

    public async Task InsertRangeAsync(List<T> entities)
    {
        await _context.AddRangeAsync(entities);
    }

    public async Task Delete(Guid id)
    {
        await context.Set<T>().FindAsync(id);
    }
}