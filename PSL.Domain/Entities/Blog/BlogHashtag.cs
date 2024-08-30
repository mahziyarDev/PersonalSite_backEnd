namespace PSL.Domain.Entities.Blog;

public class BlogHashtag : BaseEntity<int>
{
    public int HashtagId { get; set; }
    public Hashtag Hashtag { get; set; }
    
    public int BlogId { get; set; }
    public Blog Blog { get; set; }
}