using ASH.COMMON.Models;
using ASH.DATA.Models;
using ASH.DATA.Repos.interfaces;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace ASH.DATA.Repos.implementations
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        private readonly ASHContext _context;
        private readonly DbSet<T> _dbSet;

        public BaseRepository(ASHContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();

        }

        public T Delete(int id)
        {
            T existing = _dbSet.FirstOrDefault(x => x.Id == id);
            if (existing != null)
            {
                existing.IsDeleted = true;
                _context.Set<T>().Update(existing);
                _context.SaveChanges();
            }
            return existing;
        }

        public IEnumerable<T> Get()
        {
            return includeAll().AsEnumerable();
        }

        public T Get(int id)
        {
            return includeAll().FirstOrDefault(x => x.Id == id);
        }

        public T Save(T request, int userId)
        {
            if (request.Id <= 0)
            {
                request.CreatedBy = userId;
                request.CreatedOn = DateTime.Now;
                request.IsActive = true;
                request.IsDeleted = false;
                _dbSet.Add(request);
            }
            else
            {
                var existing = _dbSet.First(x => x.Id == request.Id);
                request.CreatedBy = existing.CreatedBy;
                request.CreatedOn = existing.CreatedOn;
                request.IsActive = existing.IsActive;
                request.IsDeleted = existing.IsDeleted;
                request.ModifiedBy = userId;
                request.ModifiedOn = DateTime.Now;
                _dbSet.Update(request);
            }
            _context.SaveChanges();
            return request;
        }
        private IQueryable<T> includeAll()
        {
            IQueryable<T> querry = _dbSet.AsQueryable();
            PropertyInfo[] properties = typeof(T).GetProperties().Where(p => p.GetGetMethod().IsVirtual).ToArray();
            foreach (var prop in properties)
            {
                querry = querry.Include(prop.Name);
            }
            return querry;
        }
    }
}
