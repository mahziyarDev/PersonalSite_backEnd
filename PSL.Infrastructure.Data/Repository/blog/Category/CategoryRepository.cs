using PSL.Infrastructure.Data.ContextApp;
using PSL.Infrastructure.Data.Repository.Base;

namespace PSL.Infrastructure.Data.Repository.blog.Category;

public class CategoryRepository : BaseRepository<Domain.Entities.Blog.Category,int>,ICategoryRepository
{
    #region Constructure

    private readonly PSLContext _context;
    
    /// <summary></summary>
    /// <param name="context"></param>
    public CategoryRepository(PSLContext context) : base(context)
    {
        _context = context;
    }

    #endregion
}