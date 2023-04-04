using EntityFrameworkDemo2.Models;
using Microsoft.EntityFrameworkCore;
//using System.Data.Entity;
using System.Data.Entity.Core.Objects;

namespace EntityFrameworkDemo2.Db;


public class DemoDbContext : DbContext
{
    public DemoDbContext(DbContextOptions<DemoDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<BankAccount> BankAccounts { get; set; }
    public DbSet<UserAddress> UserAccounts { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }

    //protected override void OnConfiguring(DbModelBuilder modelBuilder)
    //{
    //    base.OnModelCreating(modelBuilder);
    //}
}

