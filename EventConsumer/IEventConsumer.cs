using System;
using System.Collections.Generic;
using System.Text;

namespace EventTracer
{
    interface IEventConsumer
    {
        Event ReadEvent(int eventRow);
    }
}
