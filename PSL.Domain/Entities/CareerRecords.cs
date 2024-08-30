namespace PSL.Domain.Entities;

public class CareerRecords : BaseEntity<int>
{
    public string CompanyLogoOrImage { get; set; }
    public string CompanyName { get; set; }
    public string CompanyAddress { get; set; }
    public string StartDate { get; set; }
    public string FinshDate { get; set; }
    public bool IsWorking { get; set; }
    public string LanguagesProgramingWorkedWith { get; set; }
    public string Description { get; set; }
    public bool IsUnivercity { get; set; }
}