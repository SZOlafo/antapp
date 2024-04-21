using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace antapp.Shared.Auth.DbConnection.Tables
{
    public class ChatEntryDto
    {
        public required int id { get; set; }
        public required string message { get; set; }
        public required bool messageVisibility { get; set; }
        public required DateOnly EntryDate { get; set; }
        public required int chatId { get; set; }
        public required int userId { get; set; }
    }
}
