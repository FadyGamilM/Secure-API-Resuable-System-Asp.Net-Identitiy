using Microsoft.EntityFrameworkCore;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations;
public class BookConfigurations : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.HasData(
            new Book
            {
                Id= 1,
                Title= "How to master DevOps",
                AuthorName= "fady gamil"
            },
            new Book
            {
                Id = 2,
                Title = "azure for .net developers",
                AuthorName = "magy magdy"
            },
            new Book
            {
                Id = 3,
                Title = ".net security with identitiy server 4",
                AuthorName = "ahmed mostafa"
            }
        );
    }
}
