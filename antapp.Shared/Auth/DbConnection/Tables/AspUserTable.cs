using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;

namespace antapp.Shared.Auth.DbConnection.Tables;

[Table("AspNetUsers")]
public class AspUserTable
{
    [Key]
    public required string Id { get; init; }
    public required string UserName { get; init; }
}
