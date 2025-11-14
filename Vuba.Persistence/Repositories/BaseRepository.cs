using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vuba.Domain.Entities;
using Vuba.Domain.Interfaces;
using Vuba.Persistence.Context;

namespace Vuba.Persistence.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        protected readonly AppDbContext _context;

        public BaseRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Create(T entity)
        {
            entity.DateCreated = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc);
            _context.Add(entity);
        }

        public void Update(T entity)
        {
            entity.DateUpdated = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc);
            _context.Update(entity);
        }

        public void Delete(T entity)
        {
            entity.DateDeleted = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc);
            _context.Remove(entity);
        }

        public async Task<T> Get(int id, CancellationToken cancellationToken)
        {
            return await _context.Set<T>().FirstOrDefaultAsync(w => w.Id == id, cancellationToken);
        }

        public async Task<List<T>> GetAll(CancellationToken cancellationToken)
        {
            return await _context.Set<T>().ToListAsync(cancellationToken);
        }

    }
}
