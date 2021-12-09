using KonicaHomework.DAL;
using KonicaHomework.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KonicaHomework.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventController : Controller
    {
        private IEventRepository eventRepository;

        public EventController(IEventRepository repo)
        {
            eventRepository = repo;
        }

        [HttpGet("{id}")]
        public IEnumerable<EventLog> GetEventsForDocument(int id)
        {
            return eventRepository.GetEventsForDocument(id);
        }
    }
}
