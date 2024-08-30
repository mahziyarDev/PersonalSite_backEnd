using PSL.Domain.Entities;
using PSL.Infrastructure.Data.ContextApp;
using PSL.Infrastructure.Data.Repository.Base;

namespace PSL.Infrastructure.Data.Repository.CareerRecord;

public class CareerRecordRepository : BaseRepository<CareerRecords, int>,ICareerRecordRepository
{
    #region Constructure

    private readonly PSLContext _context;
    
    /// <summary></summary>
    /// <param name="context"></param>
    public CareerRecordRepository(PSLContext context) : base(context)
    {
        _context = context;
    }

    #endregion
}