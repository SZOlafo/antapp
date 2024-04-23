using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace antapp.Shared.Auth.DbConnection.Tables
{
    [Table("chat")]
    public class ChatTable
    {
        public required int id { get; set; }
        public required string chatname { get; set; }
        public required string description { get; set; }

        [ForeignKey("locationid")]
        public virtual LocationTable Location { get; set; }
    }
}
