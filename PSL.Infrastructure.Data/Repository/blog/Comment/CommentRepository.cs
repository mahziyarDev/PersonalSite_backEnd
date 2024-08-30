using PSL.Infrastructure.Data.ContextApp;
using PSL.Infrastructure.Data.Repository.Base;

namespace PSL.Infrastructure.Data.Repository.blog.Comment;

public class CommentRepository : BaseRepository<Domain.Entities.Blog.Comment,int> ,ICommentRepository
{
    #region Constructure

    private readonly PSLContext _context;
    
    /// <summary></summary>
    /// <param name="context"></param>
    public CommentRepository(PSLContext context) : base(context)
    {
        _context = context;
    }

    #endregion
}