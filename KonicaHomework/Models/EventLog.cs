using System;
using System.Collections.Generic;

#nullable disable

namespace KonicaHomework.Models
{
    public partial class EventLog
    {
        public byte DocumentId { get; set; }
        public byte EventId { get; set; }
        public DateTime HappenedAt { get; set; }
    }
}
