using System.ComponentModel.DataAnnotations.Schema;

namespace antapp.Shared.Auth.DbConnection.Tables;

[Table("Location")]
public class LocationTable
{
    public required int Id { get; set; }
    public required string LocationName { get; set; }
    public required string Description { get; set; }
    public required string Coordinates { get; set; }
    public required int Range { get; set; }
}
