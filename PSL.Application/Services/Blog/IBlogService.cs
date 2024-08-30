using PSL.Application.DTOs.Blog;
using PSL.Application.DTOs.Blog.Admin;
using PSL.Infrastructure.OperationResult;

namespace PSL.Application.Services.Blog;

public interface IBlogService
{
    Task<OperationResult<ArticleDto>> GetArticleById(int id);
    Task<OperationResult<List<ArticlesDto>>> GetArticles();
    Task<OperationResult> InsertAsync(CreateArticleDto dto);
    Task<OperationResult> UpdateAsync(UpdateArticleDto dto);
    Task<OperationResult> DeleteAsync(int id);
}