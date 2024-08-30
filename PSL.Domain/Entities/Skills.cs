namespace PSL.Domain.Entities;

public class Skills : BaseEntity<int>
{
    public string SkillName { get; set; }
    public string Description { get; set; }
}