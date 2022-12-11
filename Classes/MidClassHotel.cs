using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using BookingSystem.Contracts;

namespace BookingSystem.Classes
{
    internal class MidClassHotel : IHotel
    {
        private List<People> reservations;
        private List<string> luxury;
        private List<string> roomsD;
        public MidClassHotel(string name, int doubleRooms, int luxuryRooms, string sss) : base(name, doubleRooms, luxuryRooms, sss)
        {

            reservations= new List<People>();
            luxury= new List<string>();
            roomsD= new List<string>();
        }

        public int count { get { return reservations.Count;} }
        public IReadOnlyCollection<People> Reserved { get { return reservations.AsReadOnly(); } }

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
            if (person.RoomType == "1")
            {
                luxury.Add("one");
            }

            else if (person.RoomType == "2")
            {
                roomsD.Add("one");
            }

        }

        public override string MyData()
        {
            StringBuilder toReturn = new StringBuilder();
            toReturn.AppendLine($"New Hotel Build {this.Name} with double rooms {this.DoubleRoomsCount} and luxury rooms {this.LuxuryRoomsCount}");
            return toReturn.ToString();
        }

        public override string ReservationsList()
        {
            if (this.reservations.Count == 0)
            {
                return "none";
            }

            StringBuilder toReturn = new StringBuilder();
            toReturn.AppendLine("Reservations:");
            foreach (var rese in reservations)
            {
                toReturn.Append($"- {rese.Firstname} {rese.Lastname} will stay at {this.Name} from {rese.Start.Date} till {rese.End.Date}");
            }
            Console.WriteLine();

            return toReturn.ToString();
        }
        public override decimal Payment(People person, Room room)
        {
            TimeSpan duration = person.End - person.Start;
            int stayLength = int.Parse(duration.TotalDays.ToString());
            decimal payment = 1;
            if (person.RoomType == "1")
            {
                if (stayLength > 5)
                {
                    payment = (payment * room.Price) * 0.85m;
                }
                else
                {
                    payment = payment * room.Price;
                }
            }

            if (person.RoomType == "2")
            {
                if (stayLength > 5)
                {
                    payment = (payment * room.Price) * 0.85m;
                }
                else
                {
                    payment = payment * room.Price;
                }
            }

            return payment;
        }
        public override string CheckSeason(People person)
        {
            if (person.Start.Month == 1)
            {
                return "Winter";
            }
            if (person.Start.Month == 2)
            {
                return "Winter";
            }
            if (person.Start.Month == 3)
            {
                return "Winter";
            }
            if (person.Start.Month == 4)
            {
                return "Spring";
            }
            if (person.Start.Month == 5)
            {
                return "Spring";
            }
            if (person.Start.Month == 6)
            {
                return "Spring";
            }
            if (person.Start.Month == 7)
            {
                return "Summer";
            }
            if (person.Start.Month == 8)
            {
                return "Summer";
            }
            if (person.Start.Month == 9)
            {
                return "Summer";
            }
            if (person.Start.Month == 10)
            {
                return "Autumn";
            }
            if (person.Start.Month == 11)
            {
                return "Autumn";
            }
            if (person.Start.Month == 12)
            {
                return "Autumn";
            }

            return "Autumn";
        }
        public override string Cancelreservation(string name)
        {
            StringBuilder toReturn = new StringBuilder();

            foreach (var item in reservations)
            {
                if (item.Firstname + item.Lastname == name)
                {
                    TimeSpan timeSpan = item.Start - DateTime.Now;

                    if (timeSpan.Hours < 48)
                    {
                        return "Less than 48 hrs";
                    }
                    else
                    {
                        reservations.Remove(item);
                        toReturn.AppendLine($"Reservation of {item.Firstname} {item.Lastname} on {item.Start} has been sucessfully removed;");
                    }

                }
            }

            return toReturn.ToString();

        }
    }
}
