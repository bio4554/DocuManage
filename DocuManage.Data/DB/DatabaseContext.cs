using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocuManage.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace DocuManage.Data.DB
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FolderDto>();
            modelBuilder.Entity<DocumentDto>();

            base.OnModelCreating(modelBuilder);
        }
    }
}
