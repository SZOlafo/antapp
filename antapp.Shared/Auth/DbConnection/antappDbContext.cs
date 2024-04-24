using antapp.Shared.Auth.DbConnection.Tables;
using Microsoft.EntityFrameworkCore;

namespace antapp.Shared.Auth.DbConnection;

public class antappDbContext : DbContext
{
    public required DbSet<AspUserTable> Users { get; set; }
    public required DbSet<AntTable> Ants { get; set; }
    public required DbSet<UserAntTable> UserAnts { get; set; }
    public required DbSet<LocationTable> Locations { get; set; }
    public required DbSet<ChatTable> Chats { get; set; }
    public required DbSet<ChatEntryTable> ChatEntries { get; set; }
    public required DbSet<AchivmentTable> Achivments { get; set; }
    public required DbSet<UserAchivmentTable> UserAchivments { get; set; }
    public antappDbContext(DbContextOptions<antappDbContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        //builder.UseIdentityByDefaultColumns();
        //builder.Entity<UserAntTable>()
        //    .HasNoKey();

        //builder.Entity<AntTable>()
        //    .HasMany(e => e.UserAntCollection)
        //    .WithOne(e => e.Ants)
        //    .HasForeignKey(e => e.antid);
    }
}
