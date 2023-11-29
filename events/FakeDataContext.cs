﻿using Microsoft.Extensions.Logging;

namespace events
{
    public class FakeDataContext : IDataContext
    {
        public List<Event> Events { get; set; }
        public FakeDataContext()
        {
            Events = new List<Event>()
            {  new Event { Id = 1, Title = "adi",Start=new DateTime(2023,10,25) },
               new Event { Id = 2, Title = "noa",Start=new DateTime(2023,11,25) },
               new Event { Id = 3, Title = "yael",Start=new DateTime(2023,11,22) }
            };
        }
    }
    

}
