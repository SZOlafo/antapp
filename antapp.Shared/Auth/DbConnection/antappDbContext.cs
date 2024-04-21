using antapp.Shared.Auth.DbConnection.Tables;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace antapp.Shared.Auth.DbConnection;

public class antappDbContext : DbContext
{
    public required DbSet<AntTable> Ants { get; set; }
    public required DbSet<UserAntTable> UserAnts { get; set; }
    public required DbSet<LocationTable> Locations { get; set; }
    public required DbSet<ChatTable> Chats { get; set; }
    public required DbSet<ChatEntryTable> ChatEntries { get; set; }
    public antappDbContext(DbContextOptions<antappDbContext> options) : base(options)
    {
    }
}
