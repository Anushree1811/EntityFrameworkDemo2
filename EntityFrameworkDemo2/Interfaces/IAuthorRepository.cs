using EntityFrameworkDemo2.Models;

namespace EntityFrameworkDemo2.Interfaces;

public interface IAuthorRepository
{
    public List<Author> GetAuthors();
}
