using PSL.Infrastructure.Data.Repository.Base;

namespace PSL.Infrastructure.Data.Repository.User;

public interface IUserRepository :  IBaseRepository<Domain.Entities.Account.User,int>;