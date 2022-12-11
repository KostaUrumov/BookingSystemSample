using System;
using System.Collections.Generic;
using System.Text;

namespace BookingSystem.Classes
{
    public class Room
    {
        private decimal price;
        public Room(string season, string hotelType, string type, decimal price)
        {
            Season = season;
            HotelType = hotelType;
            Type = type;
            Price = price;
        }

        public string Season { get; private set; }
        public string HotelType { get; private set; }
        public string Type { get; private set; }


        public decimal Price
        {  get => price;
            private set
            {
                if (this.Season == "Winter" && this.HotelType == "mid")
                {
                    if (this.Type == "1")
                    {
                        this.price = 65;
                    }
                    else
                    {
                        this.price = 58;
                    }
                }
                if (this.Season == "Winter" && this.HotelType == "high")
                {
                    if (this.Type == "1")
                    {
                        this.price = 75;
                    }
                    else
                    {
                        this.price = 65;
                    }

                }
                if ((this.Season == "Autumn" || this.Season == "Spring") && this.HotelType == "mid")
                {
                    if (this.Type == "1")
                    {
                        this.price = 50;
                    }
                    else
                    {
                        this.price = 43;
                    }
                }
                if ((this.Season == "Autumn" || this.Season == "Spring") && this.HotelType == "high")
                {
                    if (this.Type == "1")
                    {
                        this.price = 62;
                    }
                    else
                    {
                        this.price = 54;
                    }
                }
                if (this.Season == "Summer" && this.HotelType == "mid" )
                {
                    if (this.Type == "1")
                    {
                        this.price = 63;
                    }
                    else
                    {
                        this.price = 60;
                    }
                }
                if (this.Season == "Summer" && this.HotelType == "high")
                {
                    if (this.Type == "1")
                    {
                        this.price = 90;
                    }
                    else
                    {
                        this.price = 78;
                    }
                }
            }
        }


        public void SettingPrice()
        {
            
        }
               
        
        
    }
}
