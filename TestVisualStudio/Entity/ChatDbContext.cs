using System;
using Microsoft.EntityFrameworkCore;

namespace TestVisualStudio.Entity;

public class ChatDbContext : DbContext
{
    public DbSet<MessageEntity> Messages { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Database=postgres;Username=postgres;Password=postgres");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}

