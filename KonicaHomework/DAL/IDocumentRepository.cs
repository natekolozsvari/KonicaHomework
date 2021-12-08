using KonicaHomework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KonicaHomework.DAL
{
    public interface IDocumentRepository
    {
        IEnumerable<Document> GetTopLevelDocuments();
        IEnumerable<Document> GetChildrenForDocument(int parentId);
        IEnumerable<Document> GetDocumentsByTitle(string title);
        //void AddDocument(Document document);
        //void DeleteDocument(int docId);
        //void UpdateDocument(Document document);
    }
}
