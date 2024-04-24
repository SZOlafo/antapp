using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace antapp.Shared.Auth.DbConnection.Tables;

[Table("achivment_user")]
public class UserAchivmentTable
{
    [Key]
    public required int id { get; set; }
    [ForeignKey("userid")]
    public required string userid { get; set; }
    [ForeignKey("achivmentid")]
    public virtual AchivmentTable Achivment { get; set; }
    public required DateOnly aquiredate { get; set; }
    public required string progress {  get; set; }
}
