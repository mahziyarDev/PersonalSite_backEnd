using PSL.Domain.Entities.Blog;
using PSL.Infrastructure.Data.Repository.Base;

namespace PSL.Infrastructure.Data.Repository.blog.Hashtag;

public interface IHashtagRepository : IBaseRepository<Domain.Entities.Blog.Hashtag,int>;