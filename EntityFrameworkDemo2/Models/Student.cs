namespace EntityFrameworkDemo.Models;

public class Student
{
    public int Id { get; set; }

    public string FirstName { get; set; }

    public string? LastName { get; set; }

    public List<Mark>? MarkList { get; set; } = new();

    public List<Team>? TeamList { get; set; } = new();


}

public class Mark
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int  MarkObtained { get; set; }

    public int MaxMark { get; set; } = 100;

}

public class Team
{
    public int Id { get; set; }

    public string Name { get; set; }=null!;

    public List<Student>? StudentList { get; set; } = new();

}


public class StudentListViewModel
{
    public int Id { get; set; }

    public string Name { get; set; }

    public List<Mark>? MarkList { get; set; }

    public int TotalMark { get; set; }

    public Mark Highest { get; set; }

    public Team SearchTeam { get; set; }

    

}
