using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using BookingSystem.Contracts;

namespace BookingSystem.Classes
{
    internal class MidClassHotel : IHotel
    {
        private Dictionary<int, People> reservations;
        private List<string> luxury;
        private List<string> roomsD;
        public MidClassHotel(string name, int doubleRooms, int luxuryRooms, string sss) : base(name, doubleRooms, luxuryRooms, sss)
        {

            reservations= new Dictionary<int, People>();
            luxury= new List<string>();
            roomsD= new List<string>();
        }

        public override bool CheckAvaulability(People person)
        {
            if (person.RoomType == "1")
            {
                if (luxury.Count < this.LuxuryRoomsCount)
                {
                    return true;
                }
                else
                {
                    for (int i = 0; i < reservations.Count; i++)
                    {
                        if (reservations[i].RoomType == "1")
                        {
                            if (person.Start < reservations[i].Start && person.End < reservations[i].Start)
                            {
                                return true;
                            }

                            else if (person.Start > reservations[i].End)
                            {
                                return true;
                            }
                            
                        }

                    }

                }

                return false;
            }

            if (person.RoomType == "2")
            {
                if (roomsD.Count < this.DoubleRoomsCount)
                {
                    return true;
                }
                else
                {
                    for (int i = 0; i < reservations.Count; i++)
                    {
                        if (reservations[i].RoomType == "1")
                        {
                            if (person.Start < reservations[i].Start && person.End < reservations[i].Start)
                            {
                                return true;
                            }

                            else if (person.Start > reservations[i].End)
                            {
                                return true;
                            }

                        }

                    }

                }
            }

            return false;

        }

        public override void Reserve(int id, People person)
        {
            reservations.Add(id, person);
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
            toReturn.AppendLine($"New Hotel Build {this.Name}. Type is {this.GetType().Name} with double rooms {this.DoubleRoomsCount} and luxury rooms {this.LuxuryRoomsCount}");
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
        
        
    }
}
