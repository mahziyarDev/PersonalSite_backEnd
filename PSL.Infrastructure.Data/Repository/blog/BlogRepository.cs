using PSL.Domain.Entities.Blog;
using PSL.Infrastructure.Data.ContextApp;
using PSL.Infrastructure.Data.Repository.Base;

namespace PSL.Infrastructure.Data.Repository.blog;

public class BlogRepository : BaseRepository<Blog,int>,IBlogRepository
{
    #region Constructure

    private readonly PSLContext _context;
    
    /// <summary></summary>
    /// <param name="context"></param>
    public BlogRepository(PSLContext context) : base(context)
    {
        _context = context;
    }

    #endregion
}