using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PSL.Domain.Entities.Blog;

public class Blog : BaseEntity<int>
{
    public Guid? FileId { get; set; }
    public string Title { get; set; }
    public string ShortDescription { get; set; }
    
    public string LongDescription { get; set; }

    public int CategoryId { get; set; }

    #region Relations

    public PSL.Domain.Entities.File.FileModel File { get; set; }
    public Category Category { get; set; }
    public List<BlogHashtag> BlogHashtags { get; set; }
    public List<Comment> Comments  { get; set; }
    #endregion
    
}

public class BlogConfigureProperties : IEntityTypeConfiguration<Blog>
{
    public void Configure(EntityTypeBuilder<Blog> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasMany(x => x.BlogHashtags)
            .WithOne(x => x.Blog)
            .HasForeignKey(x=>x.BlogId)
            .OnDelete(DeleteBehavior.NoAction);
        
        builder.HasOne(x => x.Category)
            .WithMany(x => x.Blogs)
            .HasForeignKey(x=>x.CategoryId)
            .OnDelete(DeleteBehavior.NoAction);
        
    }
}