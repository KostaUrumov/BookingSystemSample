using BookingSystem.Classes;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace BookingSystem
{
    internal class StartUp
    {
        static void Main(string[] args)
        {

            List<Hotel> hotelsAvailable = new List<Hotel>();
            Hotel hotel1 = new MidClassHotel("Magnolia", 10, 5, "mid");
            Hotel hotel2 = new LuxuryHotel("Desperado", 10, 5, "high");
            Hotel hostel = new MidClassHotel("StayHere", 5, 0, "mid");
            Hotel highclas = new LuxuryHotel("Kayman", 10, 6, "high");
            Hotel hotel = new MidClassHotel("StayWithMe", 4, 1, "mid");
            hotelsAvailable.Add(hotel1);
            hotelsAvailable.Add(hotel2);
            hotelsAvailable.Add(hostel);
            hotelsAvailable.Add(highclas);
            hotelsAvailable.Add(hotel);

            foreach (var item in hotelsAvailable)
            {
                Console.WriteLine(item.MyData());
            }

            Console.WriteLine("What do you want to do? Select [1] - reservations, or [2] - cancelation reservarion.");
            Console.WriteLine("Remember it is not possible to cancel reservation if it starts within next 48 hrs!");

            string action = Console.ReadLine();
            if (action == "1")
            {

                while (true)
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
                    DateTime endDate = DateTime.Parse(Console.ReadLine());
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
                                    if (hot.CheckAvaulability(startDate, endDate, roomtype, totalGuests) == true)
                                    {
                                        People person = new People(names[0], names[1], startDate, endDate, totalGuests, roomtype);
                                        hot.Reserve(person);
                                        Console.WriteLine($"{person.Firstname} {person.Lastname} reserved {nameOfTheHotel} from {person.Start} until {person.End}");
                                        if (hot.CheckSeason(person) == "Winter")
                                        {
                                            room = new Room("Winter", hot.Class, "1");
                                        }
                                        if (hot.CheckSeason(person) == "Summer")
                                        {
                                            room = new Room("Winter", hot.Class, "1");
                                        }
                                        if (hot.CheckSeason(person) == "Autumn")
                                        {
                                            room = new Room("Winter", hot.Class, "1");
                                        }
                                        if (hot.CheckSeason(person) == "Spring")
                                        {
                                            room = new Room("Winter", hot.Class, "1");
                                        }
                                        Console.WriteLine($"Total payment is {hot.Payment(person, room),0:f2}");
                                        thisPersonReserved++;
                                        break;
                                    }
                                    else
                                    {
                                        continue;
                                    }

                                }
                                else if (roomtype == "2")
                                {
                                    Console.WriteLine("How many Guests do we expect?");
                                    int totalGuests = int.Parse(Console.ReadLine());
                                    if (hot.CheckAvaulability(startDate, endDate, roomtype, totalGuests) == true)
                                    {
                                        People person = new People(names[0], names[1], startDate, endDate, totalGuests, roomtype);
                                        hot.Reserve(person);
                                        Console.WriteLine($"{person.Firstname} {person.Lastname} reserved {nameOfTheHotel} from {person.Start} until {person.End}");
                                        if (hot.CheckSeason(person) == "Winter")
                                        {
                                            room = new Room("Winter", hot.Class, "2");

                                        }
                                        if (hot.CheckSeason(person) == "Spring")
                                        {
                                            room = new Room("Winter", hot.Class, "2");
                                        }
                                        if (hot.CheckSeason(person) == "Summer")
                                        {
                                            room = new Room("Winter", hot.Class, "2");
                                        }
                                        if (hot.CheckSeason(person) == "Autumn")
                                        {
                                            room = new Room("Winter", hot.Class, "2");
                                        }
                                        Console.WriteLine($"Total payment is {hot.Payment(person, room),0:f2}");
                                        break;
                                    }
                                    else
                                    {
                                        continue;
                                    }
                                }
                            }
                        }

                    }


                }
            }

            if (action == "2")
            {
                Console.WriteLine("In which hotel is your reservation");
                string reservedHotel = Console.ReadLine();
                foreach (var item in hotelsAvailable)
                {
                    if (item.Name == reservedHotel)
                    {
                        Console.WriteLine("What is your name?");
                        string nameOfReservation = Console.ReadLine();
                        if (item.Class == "mid")
                        {
                            MidClassHotel htel = (MidClassHotel)item;
                            foreach (var peopleIn in htel.Reserved)
                            {
                                if (peopleIn.Firstname + peopleIn.Lastname == nameOfReservation)
                                {
                                    Console.WriteLine(nameOfReservation);
                                }
                            }
                        }
                        if (item.Class == "high")
                        {
                            LuxuryHotel htel = (LuxuryHotel)item;
                            foreach (var peopleIn in htel.Reserved)
                            {
                                if (peopleIn.Firstname + peopleIn.Lastname == nameOfReservation)
                                {
                                    Console.WriteLine(nameOfReservation);
                                }
                            }
                        }
                    }
                }
               
                
            }


            foreach (var reserved in hotelsAvailable)
            {
                if (reserved.ReservationsList() == "none")
                {
                    continue;
                }
              
              Console.WriteLine(reserved.ReservationsList());
            }
           
        }
    }
}
