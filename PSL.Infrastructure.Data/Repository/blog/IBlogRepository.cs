using PSL.Domain.Entities.Blog;
using PSL.Infrastructure.Data.Repository.Base;

namespace PSL.Infrastructure.Data.Repository.blog;

public interface IBlogRepository : IBaseRepository<Blog,int>;