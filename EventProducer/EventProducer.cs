using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace EventTracer
{
    public class EventProducer : IEventProducer
    {
        public static List<Event> EventList { get; set; } = new List<Event>();

        public Event GenerateRandomEvent(int i)
        {
            return new Event
            {
                eventName = "E" + EventList.Count.ToString(),
                priority = new Random().Next(1, 3),
                eventRow = i
            };
        }

        public async Task PutEvent(Event evnt)
        {
            await AddEvent(evnt);
        }

        async Task<int> AddEvent(Event evnt)
        {
            return await Task.Run(() =>
            {
                Thread.Sleep(300);
                EventList.Add(evnt);
                return EventList.Count();
            });
        }

        public Event GetEvent(int rowNumber)
        {
            return EventList.Where(a => a.eventName == "E" + rowNumber.ToString()).FirstOrDefault();
        }
    }
}
