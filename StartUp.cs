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


            while (true)
            {
               int thisPersonReserved = 0;
               Console.WriteLine("What is your name");
               string[] names = Console.ReadLine()
                .Split(" ");
                if (names[0] == "end")
                {
                    break;
                }
                
                Console.WriteLine("What dates do you want to reserve");
                DateTime startDate = DateTime.Parse(Console.ReadLine());
                DateTime endDate = DateTime.Parse(Console.ReadLine());
                while (true)
                {
                    if (thisPersonReserved == 1)
                    {
                        break;
                    }
                    Console.WriteLine("Where do you want to stay. Select a hotel from the list");
                    string nameOfTheHotel = Console.ReadLine();
                    foreach (var hot in hotelsAvailable)
                    {
                        if (hot.Name == nameOfTheHotel)
                        {
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


            foreach (var reserved in hotelsAvailable)
            {
              Console.WriteLine(reserved.ReservationsList());
            }
           
        }
    }
}
