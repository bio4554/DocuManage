using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DocuManage.DAL.Models.TypeConfig
{
    internal class DocumentEntityTypeConfiguration : IEntityTypeConfiguration<Document>
    {
        public void Configure(EntityTypeBuilder<Document> builder)
        {
            builder
                .Property(d => d.CreatedBy)
                .IsRequired();
            builder
                .Property(d => d.CreatedDate)
                .IsRequired();
            builder
                .Property(d => d.IsDeleted)
                .IsRequired();
            builder
                .Property(d => d.Name)
                .IsRequired();
            builder
                .Property(d => d.UpdatedBy)
                .IsRequired();
            builder
                .Property(d => d.UpdatedDate)
                .IsRequired();
        }
    }
}
