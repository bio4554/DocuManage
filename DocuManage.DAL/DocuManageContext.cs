using DocuManage.DAL.Models;
using DocuManage.DAL.Models.TypeConfig;
using Microsoft.EntityFrameworkCore;

namespace DocuManage.DAL
{
    public class DocuManageContext : DbContext
    {
        public DocuManageContext(DbContextOptions<DocuManageContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new DocumentEntityTypeConfiguration().Configure(modelBuilder.Entity<Document>());

            base.OnModelCreating(modelBuilder);
        }
    }
}
