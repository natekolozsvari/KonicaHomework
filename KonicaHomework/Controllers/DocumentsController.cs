using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KonicaHomework.DAL;
using Microsoft.AspNetCore.Mvc;


namespace KonicaHomework.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DocumentsController
    {
        public IDocumentRepository DocumentRepository { get; set; }

        public DocumentsController(IDocumentRepository repo)
        {
            DocumentRepository = repo;
        }

    }
}
