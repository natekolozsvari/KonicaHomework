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

        public Document GetDocument(int id)
        {
            return context.Documents.FirstOrDefault(doc => doc.Id == id);
        }

        public IEnumerable<Document> GetTopLevelDocuments()
        {
            int eventId = context.Events.First(e => e.Title.Equals("Beérkezés")).Id;
            return context.Documents.Where(doc => doc.MainId == 0).OrderBy(doc => context.EventLogs.First(log => log.DocumentId == doc.Id && log.EventId == eventId).HappenedAt);
        }

        public IEnumerable<Document> GetChildrenForDocument(int parentId)
        {
            int eventId = context.Events.First(e => e.Title.Equals("Létrehozás")).Id;
            return context.Documents.Where(doc => doc.MainId == parentId).OrderBy(doc => context.EventLogs.First(log => log.DocumentId == doc.Id && log.EventId == eventId).HappenedAt);
        }

        public IEnumerable<Document> GetDocumentsByTitle(string title)
        {
            return context.Documents.Where(doc => doc.Title.Contains(title));
        }
    }
}
