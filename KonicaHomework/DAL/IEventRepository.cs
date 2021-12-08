using KonicaHomework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KonicaHomework.DAL
{
    public interface IEventRepository
    {
        IEnumerable<EventLog> GetEventsForDocument(int id);
    }
}
