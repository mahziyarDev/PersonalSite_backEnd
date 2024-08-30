namespace PSL.Application.DTOs.Blog.Admin;

public record class ArticlesDto
    (
        int Id ,
        string Title ,
        string ShortDescription ,
        string ImagePath,
        string CategoryName
        );