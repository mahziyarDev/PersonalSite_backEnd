using PSL.Domain.Entities;
using PSL.Infrastructure.Data.ContextApp;
using PSL.Infrastructure.Data.Repository.Base;

namespace PSL.Infrastructure.Data.Repository.Skill;

public class SkillRepository : BaseRepository<Skills,int>,ISkillRepository
{
    #region Constructure

    private readonly PSLContext _context;
    
    /// <summary></summary>
    /// <param name="context"></param>
    public SkillRepository(PSLContext context) : base(context)
    {
        _context = context;
    }

    #endregion
}