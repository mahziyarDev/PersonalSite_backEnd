namespace PSL.Infrastructure.OperationResult;
public class OperationResult<TData> 
{
    public OperationResultCode Code { get; set; }
    public string Message { get; set; }
    public bool Success { get; set; }
    public TData Data { get; set; }


    public OperationResult(OperationResultCode code, bool success, string message = null, TData data = default(TData))
    {
        Code = code;
        Success = success;
        Message = message;
        Data = data;
    }

}

public class OperationResult
{
    public OperationResultCode Code { get; set; }
    public string Message { get; set; }
    public bool Success { get; set; }


    public OperationResult(OperationResultCode code, bool success, string message = null)
    {
        Code = code;
        Success = success;
        Message = message;
    }

}