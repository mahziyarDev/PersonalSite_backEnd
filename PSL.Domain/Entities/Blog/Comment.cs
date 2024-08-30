using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PSL.Domain.Entities.Blog;

public class Comment : BaseEntity<int>
{
    public string FullName { get; set; }
    public string Text { get; set; }
    public string BlogId { get; set; }
    #region Relation
    public Blog Blog { get; set; }
    #endregion
    
}
public class CommentConfigureProperties : IEntityTypeConfiguration<Comment>
{
    public void Configure(EntityTypeBuilder<Comment> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasOne(x => x.Blog)
            .WithMany(x => x.Comments)
            .HasForeignKey(x => x.BlogId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}