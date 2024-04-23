using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace antapp.Shared.Auth.DbConnection.Tables;

[Table("ant")]
public class AntTable
{
    [Key]
    public required int id {  get; set; }
    public required string antname { get; set; }
    public required string description { get; set; }
    public required string? imageurl { get; set; }

    public virtual ICollection<UserAntTable> UserAntCollection { get; set; }
}
