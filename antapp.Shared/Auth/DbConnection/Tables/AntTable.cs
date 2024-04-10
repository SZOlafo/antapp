using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace antapp.Shared.Auth.DbConnection.Tables;

[Table("ant")]
public class AntTable
{
    [Key]
    public required int Id {  get; set; }
    public required string AntName { get; set; }
    public required string Description { get; set; }
    public required string? ImageUrl { get; set; }

    public required ICollection<UserAntTable> UserAntConnectors { get; set; }
}
