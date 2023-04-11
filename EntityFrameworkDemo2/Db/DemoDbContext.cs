using EntityFrameworkDemo2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
//using System.Data.Entity;


namespace EntityFrameworkDemo2.Db;


public class DemoDbContext : DbContext
{
    public DemoDbContext(DbContextOptions<DemoDbContext> options) : base(options)
    {
      
    }

    public DbSet<User> Users { get; set; }
    public DbSet<BankAccount> BankAccounts { get; set; }
    public DbSet<UserAddress> UserAddress { get; set; }

    //InMemory Database
    public DbSet<Author> Authors { get; set; }
    public DbSet<Book> Books { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        //Fluent api creations
        var user = modelBuilder.Entity<User>();

        user.HasKey(x => x.Id);
        user.Property(p =>p.FirstName).IsRequired();

        var address = modelBuilder.Entity<UserAddress>();
        address.HasKey(x => x.Id); //pk

        address.HasOne(x => x.User)
               .WithOne(x => x.Address)
               .HasForeignKey<UserAddress>(fk => fk.UserId);


    }

    //protected override void OnConfiguring(DbModelBuilder modelBuilder)
    //{
    //    base.OnModelCreating(modelBuilder);
    //}
}

