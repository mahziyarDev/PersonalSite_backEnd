using PSL.Infrastructure.Data.Repository.blog.Hashtag;

namespace PSL.Application.Services.Blog.Hashtag;

public class HashtagService : IHashtagService
{
    private readonly IHashtagRepository _hashtagRepository;
    
    
    /// <param name="hashtagRepository"></param>
    public HashtagService(IHashtagRepository hashtagRepository)
    {
        _hashtagRepository = hashtagRepository;
    }
    
}