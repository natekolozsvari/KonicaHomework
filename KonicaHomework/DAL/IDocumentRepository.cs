using KonicaHomework.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KonicaHomework.DAL
{
    public interface IDocumentRepository
    {
        Document GetDocument(int id);
        IEnumerable<Document> GetTopLevelDocuments();
        IEnumerable<Document> GetChildrenForDocument(int parentId);
        IEnumerable<Document> GetDocumentsByTitle(string title);
    }
}
