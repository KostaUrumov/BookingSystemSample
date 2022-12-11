using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace BookingSystem.Classes
{
    internal class MidClassHotel : Hotel
    {
        private decimal doubleRoomCost = 30;
        private decimal lixuryRoomCost = 45;
        private List<People> reservations;
        private List<Room> luxury;
        private List<Room> roomsD;
        public MidClassHotel(string name, int doubleRooms, int luxuryRooms, string sss) : base(name, doubleRooms, luxuryRooms, sss)
        {

            reservations= new List<People>();
            luxury= new List<Room>();
            roomsD= new List<Room>();
        }

        public decimal DoubleRoomCost
        {
            get => this.doubleRoomCost;
            private set
            {
                this.doubleRoomCost = value;
            }
        }

        public decimal LxuryRoomCost
        {
            get => this.lixuryRoomCost;
            private set
            {
                this.lixuryRoomCost = value;
            }
        }

        public int count { get { return reservations.Count;} }

        public override bool CheckAvaulability(DateTime startDate, DateTime endDate, string roomtype, int totalGuests)
        {
            if (roomtype == "1")
            {
                if (luxury.Count < this.LuxuryRoomsCount)
                {
                    return true;
                }
                else
                {
                    foreach (var st in reservations)
                    {
                        if (st.RoomType == "1")
                        {
                            if (startDate < st.Start && endDate < st.Start)
                            {
                                return true;
                            }

                            else if (startDate > st.End)
                            {
                                return true;
                            }

                        }

                    }

                }

                return false;
            }

            if (roomtype == "2")
            {
                if (roomsD.Count < this.DoubleRoomsCount)
                {
                    return true;
                }
                else
                {
                    foreach (var st in reservations)
                    {
                        if (st.RoomType == "2")
                        {
                            if (startDate < st.Start && endDate < st.Start)
                            {
                                return true;
                            }

                            else if (startDate > st.End)
                            {
                                return true;
                            }

                        }

                    }

                }

                return false;

            }

            return false;

        }

        public override void Reserve(People person)
        {
            reservations.Add(person);

        }

        public override string MyData()
        {
            StringBuilder toReturn = new StringBuilder();
            toReturn.AppendLine($"New Hotel Build {this.Name} with double rooms {this.DoubleRoomsCount} and luxury rooms {this.LuxuryRoomsCount}");
            toReturn.AppendLine($"Prices are: Double room {this.doubleRoomCost}, Luxury room {this.LxuryRoomCost} all per one night");
            return toReturn.ToString();
        }

        public override string ReservationsList()
        {
            StringBuilder toReturn = new StringBuilder();
            toReturn.AppendLine("Reservations:");
            foreach (var rese in reservations)
            {
                toReturn.Append($"- {rese.Firstname} {rese.Lastname} will stay at {this.Name} from {rese.Start.Date} till {rese.End.Date}");
            }
            Console.WriteLine();

            return toReturn.ToString();
        }
    }
}
