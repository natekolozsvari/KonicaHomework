using KonicaHomework.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KonicaHomework.DAL
{
    public interface IEventRepository
    {
        IEnumerable<EventLog> GetEventsForDocument(int id);
    }
}
