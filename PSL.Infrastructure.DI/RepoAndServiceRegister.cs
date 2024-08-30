using Microsoft.Extensions.DependencyInjection;
using PSL.Infrastructure.Data.Repository.blog;
using PSL.Infrastructure.Data.Repository.blog.Category;
using PSL.Infrastructure.Data.Repository.blog.Comment;
using PSL.Infrastructure.Data.Repository.blog.Hashtag;
using PSL.Infrastructure.Data.Repository.CareerRecord;
using PSL.Infrastructure.Data.Repository.Skill;
using PSL.Infrastructure.Data.Repository.User;
using PSL.Infrastructure.Data.UnitOfWork;

namespace PSL.Infrastructure.DI;

public static class RepoAndServiceRegister 
{
    public static void ServiceRegister(this IServiceCollection service)
    {
        #region Repository

        service.AddScoped<IUserRepository, UserRepository>();
        service.AddScoped<ISkillRepository, SkillRepository>();
        service.AddScoped<ICareerRecordRepository, CareerRecordRepository>();
        service.AddScoped<IBlogRepository, BlogRepository>();
        service.AddScoped<ICategoryRepository, CategoryRepository>();
        service.AddScoped<IHashtagRepository, HashtagRepository>();
        service.AddScoped<ICommentRepository, CommentRepository>();
        service.AddScoped<IUnitOdWork, UnitOfWork>();

        #endregion
    }
}