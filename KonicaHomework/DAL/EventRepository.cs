using KonicaHomework.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KonicaHomework.DAL
{
    public class EventRepository : IEventRepository
    {
        private readonly AppDBContext context;

        public EventRepository(AppDBContext context)
        {
            this.context = context;
        }

        public IEnumerable<EventLog> GetEventsForDocument(int id)
        {
            var logs = context.EventLogs
                .Where(log => log.DocumentId == id)
                .OrderBy(log => log.HappenedAt).ToList();
            foreach (var log in logs) {
                log.Title = context.Events.First(e => e.Id == log.EventId).Title;
            }
            return logs;
        }
    }
}
