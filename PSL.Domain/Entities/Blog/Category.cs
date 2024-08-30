namespace PSL.Domain.Entities.Blog;

public class Category : BaseEntity<int>
{
    public int? ParentId { get; set; }
    public string Title { get; set; }
    public Category Parent { get; set; }
    public List<Blog> Blogs { get; set; }
}