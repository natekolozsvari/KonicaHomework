using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace KonicaHomework.Models
{
    public partial class EventLog
    {
        public byte DocumentId { get; set; }
        public byte EventId { get; set; }
        public DateTime HappenedAt { get; set; }

        [NotMapped]
        public string Title { get; set; }
    }
}
