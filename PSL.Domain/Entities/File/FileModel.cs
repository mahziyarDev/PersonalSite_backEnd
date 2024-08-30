namespace PSL.Domain.Entities.File;

public class FileModel : BaseEntity<Guid>
{
    public string Path { get; set; }
    
}