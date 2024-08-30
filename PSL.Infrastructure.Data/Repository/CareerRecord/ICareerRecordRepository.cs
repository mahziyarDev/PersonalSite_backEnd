using PSL.Domain.Entities;
using PSL.Infrastructure.Data.Repository.Base;

namespace PSL.Infrastructure.Data.Repository.CareerRecord;

public interface ICareerRecordRepository : IBaseRepository<CareerRecords,int>;