using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace antapp.Shared.Auth.Dtos
{
    public class ChatDto
    {
        public required int Id { get; set; }
        public required string Chatname { get; set; }
        public required string Description { get; set; }
        public required int LocationId { get; set; }
    }
}
