﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace antapp.Shared.Auth.DbConnection.Tables
{
    [Table("chatentry")]
    public class ChatEntryTable
    {
        [Key]
        public int id { get; set; }
        public required string message { get; set; }
        public required bool messagevisibility {  get; set; }
        public required DateOnly entrydate { get; set; }

        [ForeignKey("chatid")]
        public required int chatid { get; set; }

        [ForeignKey("userid")]
        public string userid { get; set; }
        [ForeignKey("userid")]
        public virtual AspUserTable User { get; set; }
    }
}
