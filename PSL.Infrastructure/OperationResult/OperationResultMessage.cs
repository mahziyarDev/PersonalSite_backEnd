namespace PSL.Infrastructure.OperationResult;

public class OperationResultMessage
{
    public static string Success = "عملیات موفقیت آمیز بود";
    public static string NotFound = "چیزی یافت نشد";
    public static string Error = "عملیات با شکست مواجه شد";
    public static string NotFoundForEdit = "چیزی برای ویرایش یافت نشد";
    public static string NotFoundUser = "کاربر یافت نشد.";
    #region Register

    public static string RegisterError = "ثبت نام کاربر با شکست مواجه شد";
    public static string DuplicateUsername = "نام کاربری قابل انتخاب نیست";
    public static string DuplicateEmail = "ایمیل قابل انتخاب نیست";
    public static string PasswordNotLikeRePassword = "رمز عبور و تکرار آن باهم یکسان نیست";
    public static string LoginError = "کاربر با مشخصات وارد شده یافت نشد";
    public static string LoginSuccess = "عملیات لاگین با موفقیت انجام شد";

    #endregion

}