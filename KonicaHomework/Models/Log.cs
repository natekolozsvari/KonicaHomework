using System;
using System.Collections.Generic;

#nullable disable

namespace KonicaHomework.Models
{
    public partial class Log
    {
        public byte DokumentumId { get; set; }
        public byte EsemenyId { get; set; }
        public DateTime HappenedAt { get; set; }
    }
}
