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

/* 
 * Student class:
 * 
 * Address property: This represents a 1:1 relationship. Each student has one address.
 * MarkList property: This represents a 1 to Many relationship. Each student can have multiple marks.
 * TeamList property: This represents a Many to Many relationship. Each student can belong to multiple teams, and each team can have multiple students.
 * 
 * Team class:
 * 
 * StudentList property: This represents a Many to Many relationship. Each team can have multiple students, and each student can belong to multiple teams.
 * 
 * So, overall, your comments are correct in describing the relationships between the classes.\
 * However, it's important to note that in a relational database, Many-to-Many relationships are typically implemented using a
 * junction table (also known as an associative or linking table) to avoid direct Many-to-Many relationships. 
 * You may need to configure such tables if you are working with a relational database like SQL Server or PostgreSQL.
 * 
 * Additionally, the use of nullable reference types (?) in your code indicates that some properties can be null, which is fine depending on your data model and business logic.
 */

