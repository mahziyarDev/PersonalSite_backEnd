using Microsoft.EntityFrameworkCore;
using PSL.Application.DTOs.Blog.Admin;
using PSL.Application.Mappers.Blog;
using PSL.Domain.Entities.Blog;
using PSL.Domain.Entities.File;
using PSL.Infrastructure.Commons;
using PSL.Infrastructure.Data.Repository.Base;
using PSL.Infrastructure.Data.Repository.blog;
using PSL.Infrastructure.Data.UnitOfWork;
using PSL.Infrastructure.OperationResult;

namespace PSL.Application.Services.Blog;

public class BlogService : IBlogService
{
    #region Ctor

    private readonly IBaseRepository<BlogHashtag, int> _blogHashtagRepository;
    private readonly IBaseRepository<FileModel, Guid> _fileRepository;
    private readonly IBlogRepository _blogRepository;
    private readonly IUnitOdWork _unitOdWork;


    /// <param name="blogRepository"></param>
    /// <param name="unitOdWork"></param>
    /// <param name="blogHashtagRepository"></param>
    /// <param name="fileRepository"></param>
    public BlogService(IBlogRepository blogRepository,
        IUnitOdWork unitOdWork,
        IBaseRepository<BlogHashtag, int> blogHashtagRepository, IBaseRepository<FileModel, Guid> fileRepository)
    {
        _blogRepository = blogRepository;
        _unitOdWork = unitOdWork;
        _blogHashtagRepository = blogHashtagRepository;
        _fileRepository = fileRepository;
    }

    #endregion

    public async Task<OperationResult<ArticleDto>> GetArticleById(int id)
    {
        
        var article = await _blogRepository
            .GetQuery()
            .Include(x=>x.File)
            .FirstOrDefaultAsync(x=>x.Id == id);
        
        if (article == null)
            return new OperationResult<ArticleDto>
                (OperationResultCode.Service, false, OperationResultMessage.NotFound);
        var res = article.ArticleDto();
        return new OperationResult<ArticleDto>(OperationResultCode.Service, true, OperationResultMessage.Success, res);

    }

    public async Task<OperationResult<List<ArticlesDto>>> GetArticles()
    {
        var articles = await _blogRepository
            .GetQuery()
            .Include(x => x.Category)
            .Include(x => x.File)
            .ToListAsync();
        var res = articles.ToListArticlesDto();
        return new OperationResult<List<ArticlesDto>>(OperationResultCode.Service, true, OperationResultMessage.Success,
            res);
    }

    public async Task<OperationResult> InsertAsync(CreateArticleDto dto)
    {
        var res = dto.ToBlog();
        var repoRes = await _blogRepository.AddAsync(res);
        if (repoRes.Success == false)
            return new OperationResult(repoRes.Code, repoRes.Success, repoRes.Message);
        return await _unitOdWork.SaveChangeAsync();
    }

    public async Task<OperationResult> UpdateAsync(UpdateArticleDto dto)
    {
        var article = await _blogRepository
            .GetQuery()
            .Include(x => x.BlogHashtags)
            .FirstOrDefaultAsync(x => x.Id == dto.Id);
        
        if (article == null)
            return new OperationResult(OperationResultCode.Service, false, OperationResultMessage.NotFound);
        if (dto.HashTagIds.Count<=1)
        {
            var blogHashtags = article.BlogHashtags.ToList();
            await _blogHashtagRepository.DeleteListAsync(blogHashtags);
            
        }

        if (!string.IsNullOrEmpty(dto.Image.ContentType))
        {
            if (article.FileId.HasValue)
            {
                var fileModel = await _fileRepository.GetByIdAsync(article.FileId.Value);
                if (fileModel != null)
                    await _fileRepository.DeleteAsync(fileModel);    
            }

            article.File = new FileModel()
            {
                Path = dto.Image.FileSave(Guid.NewGuid())
            };
        }

        article.Title = dto.Title;
        article.ShortDescription = dto.ShortDescription;
        article.LongDescription = dto.LongDescription;
        return await _unitOdWork.SaveChangeAsync();
    }

    public async Task<OperationResult> DeleteAsync(int id)
    {
        var article = await _blogRepository.GetByIdAsync(id);
        if (article == null)
            return new OperationResult(OperationResultCode.Service, true, OperationResultMessage.NotFound);
        var repoRes =  await _blogRepository.DeleteAsync(article);
        if (repoRes.Success == false)
            return new OperationResult(repoRes.Code, repoRes.Success, repoRes.Message);
        return await _unitOdWork.SaveChangeAsync();
    }
}