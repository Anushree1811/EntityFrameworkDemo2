using EntityFrameworkDemo2.Models;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkDemo2.Db;

public class DemoDbContext : DbContext
{
    public DemoDbContext(DbContextOptions<DemoDbContext> options) : base(options)
    {

    }

    public DbSet<User> Users { get; set; }

    public DbSet<BankAccount> BankAccounts { get; set; }

    public DbSet<UserAddress> UserAddress { get; set; }

    public DbSet<Author> Authors { get; set; }

    public DbSet<Book> Books { get; set; }

    //Not need at the meoment
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        //Fluent api creations
        var user = modelBuilder.Entity<User>();

        user.HasKey(x => x.Id);
        user.Property(p => p.FirstName).IsRequired();

        var address = modelBuilder.Entity<UserAddress>();
        address.HasKey(x => x.Id); //pk

        address.HasOne(x => x.User)
               .WithOne(x => x.Address)
               .HasForeignKey<UserAddress>(fk => fk.UserId);
    }
}

