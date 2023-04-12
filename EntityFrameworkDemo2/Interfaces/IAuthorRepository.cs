using EntityFrameworkDemo.Models;

namespace EntityFrameworkDemo.Interfaces;

public interface IAuthorRepository
{
    public List<Author> GetAuthors();
}
