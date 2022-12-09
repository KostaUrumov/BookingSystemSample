using System;
using System.Collections.Generic;
using System.Text;

namespace BookingSystem.Classes
{
    public class Room
    {
        private DateTime start;
        private DateTime end;

        public Room(DateTime start, DateTime end)
        {
            this.Start = start;
            this.End = end;
        }

        public DateTime Start { get => this.start; private set { this.start = value; } }
        public DateTime End { get=> this.end; private set { this.end = value; } }
    }
}
