using Microsoft.AspNetCore.Http;

namespace PSL.Application.DTOs.Blog.Admin;

public record class CreateArticleDto
    (
        string Title,
        string ShortDescription,
        string LongDescription,
        List<int> HashTagIds,
        int CategoryId,
        IFormFile BlogImage
        );