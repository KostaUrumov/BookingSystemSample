using BookingSystem.Classes;
using BookingSystem.Contracts;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Transactions;
using System.Xml.Linq;

namespace BookingSystem
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            Dictionary <int,People> reseravionDict = new Dictionary<int,People>();
            List<IHotel> hotelsAvailable = new List<IHotel>();
            IHotel hotel1 = new MidClassHotel("Magnolia", 10, 5, "mid");
            IHotel hotel2 = new LuxuryHotel("Desperado", 10, 5, "high");
            IHotel hostel = new MidClassHotel("StayHere", 5, 0, "mid");
            IHotel highclas = new LuxuryHotel("Kayman", 10, 6, "high");
            IHotel hotel = new MidClassHotel("StayWithMe", 4, 1, "mid");
            hotelsAvailable.Add(hotel1);
            hotelsAvailable.Add(hotel2);
            hotelsAvailable.Add(hostel);
            hotelsAvailable.Add(highclas);
            hotelsAvailable.Add(hotel);
            

            foreach (var item in hotelsAvailable)
            {
                Console.WriteLine(item.MyData());
            }

            while (true)
            {
                Console.WriteLine("What do you want to do? Select [1] - reservations, [2] - cancelation reservarion, or [3] - No action.");
                Console.WriteLine("Remember it is not possible to cancel reservation if it starts within next 48 hrs!");
                string action = Console.ReadLine();

                if (action == "3")
                {
                    break;
                }
                if (action == "1")
                {
                    int thisPersonReserved = 0;
                    Console.WriteLine("Please enter your name. Type end if no more reservations needed.");
                    string[] names = Console.ReadLine()
                     .Split(" ");
                    if (names[0] == "end")
                    {
                        break;
                    }

                    Console.WriteLine("What dates do you want to reserve?");

                    DateTime startDate = DateTime.Parse(Console.ReadLine());
                    DateTime now = DateTime.Now;
                    if (startDate <= now)
                    {
                        Console.WriteLine("You can not select earlier than today date.");
                        continue;
                    }
                    DateTime endDate = DateTime.Parse(Console.ReadLine());

                    if (endDate <= startDate)
                    {
                        Console.WriteLine("End date of your styay can not be earlier or equal to start date");
                        continue;
                    }
                    while (true)
                    {
                        if (thisPersonReserved == 1)
                        {
                            break;
                        }
                        Console.WriteLine("Where do you want to stay? Select a hotel from the list:");
                        for (int i = 0; i < hotelsAvailable.Count; i++)
                        {
                            if (i == hotelsAvailable.Count - 1)
                            {
                                Console.WriteLine(hotelsAvailable[i].Name);
                            }
                            else
                            {
                                Console.Write($"{hotelsAvailable[i].Name}, ");
                            }

                        }
                        string nameOfTheHotel = Console.ReadLine();
                        foreach (var hot in hotelsAvailable)
                        {
                            if (hot.Name == nameOfTheHotel)
                            {
                                Room room = null;
                                Console.WriteLine("What room do you prefer? [1] - luxuryRoom or [2] - doubleRoom ");
                                string roomtype = Console.ReadLine();
                                if (roomtype == "1")
                                {

                                    Console.WriteLine("How many Guests do we expect?");
                                    int totalGuests = int.Parse(Console.ReadLine());
                                    People person = new People(names[0], names[1], startDate, endDate, totalGuests, roomtype, nameOfTheHotel);
                                    if (hot.CheckAvaulability(person) == true)
                                    {
                                        
                                        Random rand = new Random();
                                        int random = rand.Next(1000000);
                                        reseravionDict.Add(random, person);
                                        hot.Reserve(random, person);
                                        Console.WriteLine($"Reservation {random} of {person.Firstname} {person.Lastname} reserved {nameOfTheHotel} from {person.Start} until {person.End}");
                                        string season = hot.CheckSeason(person);

                                        if (season == "Winter")
                                        {
                                            room = new Room("Winter", hot.Class, "1", 0);
                                        }
                                        if (season == "Summer")
                                        {
                                            room = new Room("Winter", hot.Class, "1", 0);
                                        }
                                        if (season == "Autumn")
                                        {
                                            room = new Room("Winter", hot.Class, "1", 0);
                                        }
                                        if (season == "Spring")
                                        {
                                            room = new Room("Winter", hot.Class, "1", 0);
                                        }

                                        Console.WriteLine($"Total payment is {hot.Payment(person, room),0:f2}");
                                        thisPersonReserved++;
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("No rooms available during this period.");
                                        continue;
                                    }

                                }
                                else if (roomtype == "2")
                                {
                                    Console.WriteLine("How many Guests do we expect?");
                                    int totalGuests = int.Parse(Console.ReadLine());
                                    People person = new People(names[0], names[1], startDate, endDate, totalGuests, roomtype, nameOfTheHotel);
                                    if (hot.CheckAvaulability(person) == true)
                                    {
                                        Random rand = new Random();
                                        int random = rand.Next(1000);
                                        reseravionDict.Add(random, person);
                                        hot.Reserve(random, person);
                                        Console.WriteLine($"Reservation {random} of {person.Firstname} {person.Lastname} reserved {nameOfTheHotel} from {person.Start} until {person.End}");
                                        if (hot.CheckSeason(person) == "Winter")
                                        {
                                            room = new Room("Winter", hot.Class, "2", 0);

                                        }
                                        if (hot.CheckSeason(person) == "Spring")
                                        {
                                            room = new Room("Winter", hot.Class, "2", 0);
                                        }
                                        if (hot.CheckSeason(person) == "Summer")
                                        {
                                            room = new Room("Winter", hot.Class, "2", 0);
                                        }
                                        if (hot.CheckSeason(person) == "Autumn")
                                        {
                                            room = new Room("Winter", hot.Class, "2", 0);
                                        }
                                        Console.WriteLine($"Total payment is {hot.Payment(person, room),0:f2}");
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("No rooms available during this period.");
                                        continue;
                                    }
                                }
                            }

                            else
                            {
                                continue;
                            }
                        }

                    }
                }

                if (action == "2")
                {
                    Console.WriteLine("Add your reservation ID");
                    int reservationID = int.Parse(Console.ReadLine());

                    if (reseravionDict.ContainsKey(reservationID))
                    {
                        Console.WriteLine($"Reservation with ID {reservationID} of {reseravionDict[reservationID].Firstname} {reseravionDict[reservationID].Lastname} starting on {reseravionDict[reservationID].Start} has been sucessfully deleted");
                        
                        reseravionDict.Remove(reservationID);
                    }
                }
            }
        }
    }
}
