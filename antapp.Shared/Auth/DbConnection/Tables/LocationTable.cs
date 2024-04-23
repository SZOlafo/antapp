using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace antapp.Shared.Auth.DbConnection.Tables;

[Table("location")]
public class LocationTable
{
    [Key]
    public required int id { get; set; }
    public required string locationname { get; set; }
    public required string description { get; set; }
    public required string coordinates { get; set; }
    public required int range { get; set; }
}
