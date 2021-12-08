using KonicaHomework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            //var events = from log in context.EventLogs
            //             join e in context.Events on log.EventId equals e.Id
            //             where log.DocumentId == id
            //             select log;
            //IEnumerable<EventLog> events = context.EventLogs.Where(log => log.DocumentId == id)
            //    .Join(context.Events, log => log.EventId, e => e.Id, (log, e) => log)
            //    .OrderBy(log => log.HappenedAt);
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
