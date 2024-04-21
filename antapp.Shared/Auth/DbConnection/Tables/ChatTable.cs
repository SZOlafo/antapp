using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace antapp.Shared.Auth.DbConnection.Tables
{
    [Table("Location")]
    public class ChatTable
    {
        public required int Id { get; set; }
        public required string ChatName { get; set; }
        public string Description { get; set; }

        [ForeignKey("LocationId")]
        public required int LocationId { get; set; }
    }
}
