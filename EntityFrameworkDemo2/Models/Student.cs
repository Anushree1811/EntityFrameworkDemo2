using Newtonsoft.Json;

namespace EntityFrameworkDemo.Models;

public class Student
{
    public int Id { get; set; }

    public string FirstName { get; set; }

    public string? LastName { get; set; }

    public List<Mark>? MarkList { get; set; } = new(); //1 to Many

    
    public List<Team>? TeamList { get; set; } = new(); // Manay To Many


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

    public List<Student>? StudentList { get; set; } = new(); //Manay to Many

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

public class TeamListViewModel
{
    public string TeamName { get; set; }
    public List<StudentViewModel>? StudentList { get; set; } = new();
}

public class StudentViewModel
{
    public string FirstName { get; set; }

    public string? LastName { get; set; }
}
