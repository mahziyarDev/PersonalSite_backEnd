using PSL.Application.DTOs.Blog;
using PSL.Application.DTOs.Blog.Admin;
using PSL.Domain.Entities.Blog;
using PSL.Domain.Entities.File;
using PSL.Infrastructure.Commons;

namespace PSL.Application.Mappers.Blog;

public static class BlogMapper
{
    public static ArticleDto ArticleDto(this Domain.Entities.Blog.Blog blog) =>
        new ArticleDto(blog.Title,
            blog.ShortDescription,
            blog.LongDescription,
            blog.File.Path,
            blog.BlogHashtags.Select(x => x.HashtagId).ToList(),
            blog.CategoryId);
    
    private static ArticlesDto ToArticlesDto(this Domain.Entities.Blog.Blog blog) =>
        new ArticlesDto(
            blog.Id,
            blog.Title,
            blog.ShortDescription,
            blog.File.Path,
            blog.Category.Title
            );

    public static List<ArticlesDto> ToListArticlesDto(this List<Domain.Entities.Blog.Blog> blogs) =>
        [..blogs.Select(x => x.ToArticlesDto())];

    public static Domain.Entities.Blog.Blog ToBlog(this CreateArticleDto dto) =>
        new Domain.Entities.Blog.Blog()
        {
            ShortDescription = dto.ShortDescription,
            LongDescription = dto.LongDescription,
            CategoryId = dto.CategoryId,
            BlogHashtags = dto.HashTagIds.Select(x => new BlogHashtag() { HashtagId = x }).ToList(),
            Title = dto.Title,
            File = dto.BlogImage != null
                ? new FileModel()
                {
                    Path = dto.BlogImage.FileSave(Guid.NewGuid()),
                }
                : new FileModel()

        };
}