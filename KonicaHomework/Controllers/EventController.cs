using KonicaHomework.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KonicaHomework.Controllers
{
    public class EventController : Controller
    {
        private IEventRepository eventRepository;

        public EventController(IEventRepository repo)
        {
            eventRepository = repo;
        }

        [HttpGet("{id}")]
        public IEnumerable<Event> GetEventsForDocument(int id)
        {
            return 
        }
    }
}
