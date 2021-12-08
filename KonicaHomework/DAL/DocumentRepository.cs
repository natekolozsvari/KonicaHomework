using KonicaHomework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KonicaHomework.DAL
{
    public class DocumentRepository : IDocumentRepository
    {
        private readonly AppDBContext context;

        public DocumentRepository(AppDBContext context)
        {
            this.context = context;
        }

        public IEnumerable<Document> GetTopLevelDocuments()
        {
            return context.Documents.Where(doc => doc.MainId == 0);
        }

        public IEnumerable<Document> GetChildrenForDocument(int parentId)
        {
            return context.Documents.Where(doc => doc.MainId == parentId);
        }

        public IEnumerable<Document> GetDocumentsByTitle(string title)
        {
            return context.Documents.Where(doc => doc.Title.Contains(title));
        }
    }
}
