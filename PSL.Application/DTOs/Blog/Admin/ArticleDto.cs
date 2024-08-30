namespace PSL.Application.DTOs.Blog.Admin;

public record class ArticleDto
    (
        string Title ,
        string ShortDescription ,
        string LongDescription ,
        string ImagePath,
        List<int> HashtagIds,
        int CategoryId
            );