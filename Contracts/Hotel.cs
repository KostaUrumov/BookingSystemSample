using BookingSystem.Classes;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Reflection.Metadata;
using System.Text;

namespace BookingSystem.Contracts
{
    public abstract class IHotel
    {

        public IHotel(string name, int doubleRooms, int luxuryRooms, string sss)
        {
            Name = name;
            DoubleRoomsCount = doubleRooms;
            LuxuryRoomsCount = luxuryRooms;
            Class = sss;
        }

        public string Name { get; private set; }
        public int DoubleRoomsCount { get; private set; }
        public int LuxuryRoomsCount { get; private set; }
        public string Class { get; private set; }
        public abstract string MyData();
        public abstract bool CheckAvaulability(People person);
        public abstract void  Reserve(int id, People person);
        public abstract decimal Payment(People person, Room room);
        public abstract string CheckSeason(People person);
    }
}
