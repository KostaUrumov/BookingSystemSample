using System;
using System.Collections.Generic;
using System.Text;

namespace BookingSystem.Classes
{
    public class Room
    {
        private decimal price;
        public Room(string season, string hotelType, string type)
        {
            Season = season;
            HotelType = hotelType;
        }

        public string Season { get; private set; }
        public string HotelType { get; private set; }
        public string Type { get; private set; }

        public  decimal Price
        {  get => price;
            private set
            {
                if (this.Season == "Winter" && this.HotelType == "mid")
                {
                    if (this.Type == "1")
                    {
                        this.Price = 65;
                    }
                    else
                    {
                        this.Price = 58;
                    }
                    

                }
                if (this.Season == "Winter" && this.HotelType == "high")
                {
                    if (this.Type == "1")
                    {
                        this.Price = 75;
                    }
                    else
                    {
                        this.Price = 65;
                    }

                }
                if ((this.Season == "Autumn" || this.Season == "Spring") && this.HotelType == "mid")
                {
                    if (this.Type == "1")
                    {
                        this.Price = 50;
                    }
                    else
                    {
                        this.Price = 43;
                    }
                }
                if ((this.Season == "Autumn" || this.Season == "Spring") && this.HotelType == "high")
                {
                    if (this.Type == "1")
                    {
                        this.Price = 62;
                    }
                    else
                    {
                        this.Price = 54;
                    }
                }
                if (this.Season == "Summer" && this.HotelType == "mid" )
                {
                    if (this.Type == "1")
                    {
                        this.Price = 63;
                    }
                    else
                    {
                        this.Price = 60;
                    }
                }
                if (this.Season == "Summer" && this.HotelType == "high")
                {
                    if (this.Type == "1")
                    {
                        this.Price = 90;
                    }
                    else
                    {
                        this.Price = 78;
                    }
                }


            }


        }    
               
        
        
    }
}
