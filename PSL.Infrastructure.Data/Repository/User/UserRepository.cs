using PSL.Infrastructure.Data.ContextApp;
using PSL.Infrastructure.Data.Repository.Base;

namespace PSL.Infrastructure.Data.Repository.User;

public class UserRepository : BaseRepository<Domain.Entities.Account.User,int>, IUserRepository
{
    #region Constructure

    private readonly PSLContext _context;
    
    /// <summary></summary>
    /// <param name="context"></param>
    public UserRepository(PSLContext context) : base(context)
    {
        _context = context;
    }

    #endregion
    
}