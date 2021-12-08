using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KonicaHomework.DAL;
using KonicaHomework.Models;
using Microsoft.AspNetCore.Mvc;


namespace KonicaHomework.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DocumentsController : Controller
    {
        private IDocumentRepository documentRepository;

        public DocumentsController(IDocumentRepository repo)
        {
            documentRepository = repo;
        }

        [HttpGet]
        public IEnumerable<Document> GetTopLevelDocuments()
        {
            return documentRepository.GetTopLevelDocuments();
        }

        [HttpGet("{id}")]
        public Document GetDocument(int id)
        {
            return documentRepository.GetDocument(id);
        }

        [HttpGet("children/{id}")]
        public IEnumerable<Document> GetChildrenForDocument(int id)
        {
            return documentRepository.GetChildrenForDocument(id);
        }
        
        [HttpGet("search")]
        public IEnumerable<Document> GetDocumentsByTitle(string query)
        {
            return documentRepository.GetDocumentsByTitle(query);
        }
    }
}
