namespace Samples.Lib.Entities;

public class Attorney
{
    public string Name { get; set; }
    public string BarNumber { get; set; }
    public string FirmName { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
}

public class Defendant
{
    public string Name { get; set; }
    public string CaseNumber { get; set; }
}

public class Charge
{
    public string Description { get; set; }
    public string Statute { get; set; }
    public string Severity { get; set; }
}

public class Plaintiff
{
    public string Name { get; set; }
}

public class Judge
{
    public string Name { get; set; }
}

public class Juror
{
    public string Name { get; set; }
}

public class CourtReporter
{
    public string Name { get; set; }
}

public class Case
{
    public string Name { get; set; }
}

public class Inmate
{
    public string Name { get; set; }
}

public class PeaceOfficer
{
    public string Name { get; set; }
}
public class Witness
{
    public string Name { get; set; }
}
public class Victim
{
    public string Name { get; set; }
}
public class Court
{
    public string Name { get; set; }
}
public class Courtroom
{
    public string Name { get; set; }
}

public class Bailiff
{
    public string Name { get; set; }
}
public class Evidence
{
    public string Description { get; set; }
}