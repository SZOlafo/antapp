using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace antapp.Shared.Auth.DbConnection.Tables;

[Table("user_ant")]
public class UserAntTable
{
    [Key]
    public required int id { get; set; }
    [ForeignKey("userid")]
    public required string userid {  get; set; }
    [ForeignKey("antid")]
    public virtual AntTable Ants { get; set; }
    [ForeignKey("catchlocation")]
    public virtual LocationTable Location { get; set; }
    public required DateTime catchdate { get; set; }
}
