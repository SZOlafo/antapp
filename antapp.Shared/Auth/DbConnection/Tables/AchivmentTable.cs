using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace antapp.Shared.Auth.DbConnection.Tables;

[Table("achivment")]
public class AchivmentTable
{
    [Key]
    public required int id { get; set; }
    public required string achivmentname { get; set; }
    public required string description { get; set; }
    public required string imageurl { get; set; }
    public required string requirement {  get; set; }
}
