using EntityFrameworkDemo2.Db;
using EntityFrameworkDemo2.Interfaces;
using EntityFrameworkDemo2.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace EntityFrameworkDemo2.Services;

public class AuthorRepository : IAuthorRepository
{
    private readonly DemoDbContext context;

    public AuthorRepository(DemoDbContext context)
    {
        this.context = context;
    }

    public AuthorRepository()
    {
 
        
            var authors = new List<Author>
                {
                new Author
                {
                    FirstName ="Joydip",
                    LastName ="Kanjilal",
                       Books = new List<Book>()
                    {
                        new Book { Title = "Mastering C# 8.0"},
                        new Book { Title = "Entity Framework Tutorial"},
                        new Book { Title = "ASP.NET 4.0 Programming"}
                    }
                },
                new Author
                {
                    FirstName ="Yashavanth",
                    LastName ="Kanetkar",
                    Books = new List<Book>()
                    {
                        new Book { Title = "Let us C"},
                        new Book { Title = "Let us C++"},
                        new Book { Title = "Let us C#"}
                    }
                }
                };
        context.Authors.AddRange(authors);
            context.SaveChanges();
        
    }
    public List<Author> GetAuthors()
    {
        
            var list = context.Authors
                .Include(a => a.Books)
                .ToList();
            return list;
        

    }
    
}
