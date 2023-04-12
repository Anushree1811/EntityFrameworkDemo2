using EntityFrameworkDemo.Db;
using EntityFrameworkDemo.Interfaces;
using EntityFrameworkDemo.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace EntityFrameworkDemo.Services;

public class AuthorRepository : IAuthorRepository
{
    private readonly DemoDbContext _context;

    public AuthorRepository(DemoDbContext context)
    {
        _context = context;

        Intializer();
    }

    private void Intializer()
    {
        var authors = new List<Author>
                {
                new Author
                {
                    FirstName ="Joydip",
                    LastName ="Kanjilal",
                       Books = new List<Book>()
                    {
                        new Book { Title = "Mastering C# 8.0", FeedBackRequiredKeyword="twat",
                        Price=12
                        },
                       // new Book { Title = "Entity Framework Tutorial"},
                       // new Book { Title = "ASP.NET 4.0 Programming"}
                    }
                },
                new Author
                {
                    FirstName ="Yashavanth",
                    LastName ="Kanetkar",
                    Books = new List<Book>()
                    {
                        new Book { Title = "Let us C",FeedBackRequiredKeyword="twat",
                        Price=12},
                       // new Book { Title = "Let us C++"},
                        //new Book { Title = "Let us C#"}
                    }
                }
                };
        _context.Authors.AddRange(authors);
        _context.SaveChanges();

    }
    public List<Author> GetAuthors()
    {

        var list = _context.Authors
            .Include(a => a.Books)
            .ToList();
        return list;
    }
}
