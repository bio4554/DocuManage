using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocuManage.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace DocuManage.Data.DB
{
    public class BackendContext : DbContext
    {
        public BackendContext(DbContextOptions<BackendContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Folder>();
            modelBuilder.Entity<Document>();

            base.OnModelCreating(modelBuilder);
        }
    }
}
