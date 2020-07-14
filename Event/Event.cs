using System;
using System.Collections.Generic;
using System.Text;

namespace EventTracer
{
    public class Event
    {
        public string eventName { get; set; }
        public int eventRow { get; set; }
        public int priority { get; set; }
    }
}
