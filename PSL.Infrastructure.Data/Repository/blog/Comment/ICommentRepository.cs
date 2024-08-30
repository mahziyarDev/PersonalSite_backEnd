using PSL.Infrastructure.Data.Repository.Base;

namespace PSL.Infrastructure.Data.Repository.blog.Comment;

public interface ICommentRepository : IBaseRepository<Domain.Entities.Blog.Comment,int>;