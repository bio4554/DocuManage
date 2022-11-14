using DocuManage.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DocuManage.Data.Interfaces
{
    public interface IDocumentRepository
    {
        // return a single db row by primary key
        T? Single<T>(Guid key) where T : class, IUniqueIdentifier;

        // returns all rows for a model
        IQueryable<T> GetAll<T>() where T : class;

        // returns bool if object exists
        bool Exists<T>(Guid key) where T : class;

        // insert a model into db
        void Insert<T>(T entity) where T : class;

        // delete a row from db
        void Delete<T>(T entity) where T : class;

        // saves db changes
        void SaveChanges();

        // discards all changes
        void DeleteChanges();
    }
}
