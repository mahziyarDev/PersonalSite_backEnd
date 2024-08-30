using PSL.Infrastructure.OperationResult;

namespace PSL.Application.Services.Blog.Hashtag;

public interface IHashtagService
{
    Task<OperationResult> InserAsync()
}