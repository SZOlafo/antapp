using System.ComponentModel.DataAnnotations.Schema;

namespace antapp.Shared.Auth.DbConnection.Tables;

[Table("user_ant")]
public class UserAntTable
{
    [ForeignKey("UserId")]
    public required string UserId {  get; set; }
    [ForeignKey("AntId")]
    public required int AntId { get; set; }
    public required DateTime CathDate { get; set; }
    [ForeignKey("CatchLocation")]
    public required int CatchLocation {  get; set; }

    public virtual AntTable Ant {  get; set; }
    public virtual LocationTable Location { get; set; }

}
