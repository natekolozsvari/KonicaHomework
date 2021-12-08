using KonicaHomework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KonicaHomework.DAL
{
    interface IEventRepository
    {
        IEnumerable<Event> GetEventsForDocument(int id);
    }
}
