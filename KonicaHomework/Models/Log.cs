using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace KonicaHomework.Models
{
    public partial class Log
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public byte Id { get; set; }
        public string Ip { get; set; }
        public DateTime? Date { get; set; }
        public string Username { get; set; }
        public string Event { get; set; }
    }
}
