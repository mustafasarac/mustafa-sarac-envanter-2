using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace EventTracer
{
    public class EventConsumer
    {
        public Event _event;
        public EventConsumer()
        {

        }

        public async Task<Event> ReadEvent(int eventRow)
        {
            var evt = await Read(eventRow);
            return evt;
        }

        async Task<Event> Read(int eventRow)
        {
            return await Task.Run(() =>
            {
                Thread.Sleep(500);
                var _event = EventProducer.EventList.Where(a => a.eventRow == eventRow).FirstOrDefault();
                return _event;
            });
        }

        public void Alert(Event e1, Event e2, Event e3)
        {
            var priorityTitle = e1.priority == 0 ? "Düşük" : e1.priority == 1 ? "Orta" : "Yüksek";
            MessageBox.Show(e1.eventName + "-" + e2.eventName + "-" + e3.eventName + " " + priorityTitle + " öncelikli eventlar ardarda sıralanmıştır.");
        }
    }
}
