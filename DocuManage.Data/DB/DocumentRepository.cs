using DocuManage.Data.Interfaces;
using DocuManage.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace DocuManage.Data.DB
{
    public class DocumentRepository : IDocumentRepository
    {
        public DbContext _context { get; }

        public DocumentRepository(DbContext context)
        {
            _context = context;
        }

        public T? Single<T>(Guid key) where T : class, IUniqueIdentifier
        {
            return _context.Set<T>().SingleOrDefault(e => e.Id == key);
        }

        public IQueryable<T> GetAll<T>() where T : class
        {
            return _context.Set<T>();
        }

        public bool Exists<T>(Guid key) where T : class
        {
            return _context.Set<T>().Find(key) != null;
        }

        public void Insert<T>(T entity) where T : class
        {
            _context.Set<T>().Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            if (_context.Entry(entity).State == EntityState.Detached)
            {
                _context.Set<T>().Attach(entity);
            }

            _context.Set<T>().Remove(entity);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void DeleteChanges()
        {
            throw new NotImplementedException();
        }
    }
}