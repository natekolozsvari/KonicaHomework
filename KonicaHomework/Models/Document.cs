using System;
using System.Collections.Generic;

#nullable disable

namespace KonicaHomework.Models
{
    public partial class Document
    {
        public byte Id { get; set; }
        public string Title { get; set; }
        public string Extension { get; set; }
        public byte MainId { get; set; }
        public string Source { get; set; }
    }
}
