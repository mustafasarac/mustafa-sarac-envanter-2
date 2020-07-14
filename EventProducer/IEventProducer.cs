using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EventTracer
{
    interface IEventProducer
    {
        Event GenerateRandomEvent(int i);
        Task PutEvent(Event evnt);
    }
}
