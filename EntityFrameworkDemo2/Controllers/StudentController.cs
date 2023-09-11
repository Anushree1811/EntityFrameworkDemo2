using EntityFrameworkDemo.Db;
using EntityFrameworkDemo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EntityFrameworkDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly DemoDbContext dbContext;

        public StudentController(DemoDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        // GET: api/<StudentController>
        [HttpGet]
        public async Task <List<TeamListViewModel>> GetAsync()
        {
            //Student s1 = new Student()
            //{
            //    FirstName = "Vipin",
            //    LastName = "kumar PS",

            //    MarkList = new List<Mark>()
            //    {
            //        new Mark() { Name = "Biology", MarkObtained = 100 },
            //        new Mark() { Name = "Botany", MarkObtained = 100 }
            //    },

            //    TeamList = new List<Team>()
            //    {
            //       new Team() {Name="Chess"},
            //      new Team() {Name="Table Tennis"}
            //    }
            //};
            //dbContext.Students.Add(s1);
            //await dbContext.SaveChangesAsync();

            Student s2 = new Student()
            {
                FirstName = "Vishnu",
                LastName = "kumar",

                MarkList = new List<Mark>()
                {
                    new Mark() { Name = "Physics", MarkObtained = 90 },
                    new Mark() { Name = "Maths", MarkObtained = 95 }
                },

                TeamList = new List<Team>()
                {
                   new Team() {Name="Cricket"},
                  new Team() {Name="Football"}
                }
            };

            dbContext.Students.Add(s2);
            await dbContext.SaveChangesAsync();
           

            List<TeamListViewModel>? result = await dbContext.Teams.Include(x => x.StudentList).Select(team=> new TeamListViewModel()
            {
                TeamName = team.Name,
                StudentList=team.StudentList.Select(student=> new StudentViewModel()
                {
                    LastName = student.LastName,
                    FirstName = student.FirstName,
                }).ToList()

            } ).ToListAsync();


            return result;
        }

        // GET api/<StudentController>/5
        [HttpGet("{search}")]
        public async Task<List<StudentListViewModel>> GetAsync(string search)
        {
            return   await dbContext.Students
                .Include(student => student.TeamList)
                .Include(student => student.MarkList)
                .Select(student => new StudentListViewModel()
                {
                    Name = student.FirstName + student.LastName,
                    MarkList = student.MarkList,
                    TotalMark = student.MarkList.Sum(x => x.MarkObtained),
                    Highest = student.MarkList.OrderByDescending(x=>x.MarkObtained).FirstOrDefault(),

                   SearchTeam=student.TeamList.Where(x=>EF.Functions.Like(x.Name,$"%{search}%")).FirstOrDefault()
                 
                })
                .ToListAsync();



        }


        // POST api/<StudentController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<StudentController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<StudentController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }

    public class StudentFilter
    {
        public StudentOrder StudentOrder { get; set; }
    }
    public enum StudentOrder
    {
        OrderNameAsc,
        OrderNameDesc,
        OrderSubNameAsc,
        OrderSubNameDesc,
    }
}
