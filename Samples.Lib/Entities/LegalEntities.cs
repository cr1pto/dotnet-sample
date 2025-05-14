namespace Samples.Lib.Entities;
public class Case
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string CaseNumber { get; set; }
    public IEnumerable<Attorney> DefenseAttorneys { get; set; }
    public IEnumerable<Attorney> DistrictAttorneys { get; set; }
    public IEnumerable<Juror> Jury { get; set; }
    public Judge Judge { get; set; }
    public Inmate Inmate { get; set; }
    public Defendant Defendant { get; set; }
}

public enum AttorneyType
{
    Defense,
    District
}

public class Attorney
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string BarNumber { get; set; }
    public string FirmName { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public AttorneyType AttorneyType { get; set; }
}

public class Defendant
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string CaseNumber { get; set; }
}

public class Judge
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}

public class Juror
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}

public class Inmate
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public DateTime ArraignmentDate { get; set; }
    public DateTime ArrestDate { get; set; }
    public DateTime SentencingDate { get; set; }
}
