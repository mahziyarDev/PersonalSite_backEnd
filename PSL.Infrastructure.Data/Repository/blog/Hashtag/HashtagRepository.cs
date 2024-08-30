using PSL.Domain.Entities.Blog;
using PSL.Infrastructure.Data.ContextApp;
using PSL.Infrastructure.Data.Repository.Base;

namespace PSL.Infrastructure.Data.Repository.blog.Hashtag;

public class HashtagRepository : BaseRepository<Domain.Entities.Blog.Hashtag,int>,IHashtagRepository
{
#region Constructure

private readonly PSLContext _context;
    
/// <summary></summary>
/// <param name="context"></param>
public HashtagRepository(PSLContext context) : base(context)
{
    _context = context;
}

#endregion
}