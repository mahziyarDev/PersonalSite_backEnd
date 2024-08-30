using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PSL.Domain.Entities.Blog;

public class Hashtag:BaseEntity<int>
{
    public string Title { get; set; }

    #region Relations

    public List<BlogHashtag> BlogHashtags { get; set; }

    #endregion
}

public class HashtagConfigureProperties : IEntityTypeConfiguration<Hashtag>
{
    public void Configure(EntityTypeBuilder<Hashtag> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasMany(x => x.BlogHashtags)
            .WithOne(x => x.Hashtag)
            .HasForeignKey(x => x.HashtagId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}