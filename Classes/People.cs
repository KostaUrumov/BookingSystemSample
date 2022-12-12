using BookingSystem.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace BookingSystem.Classes
{
    public class People
    {
        private string firstname;
        private string lastname;
        private DateTime startdate;
        private DateTime enddate;
        private int total;
        private string roomType;
        private string hotel;
        public People(string firstname, string lastname, DateTime startdate, DateTime endDate, int total, string roomtype, string hotelName)
        {
            this.Firstname = firstname;
            this.Lastname = lastname;
            this.Start = startdate;
            this.End = endDate;
            this.Total = total;
            this.RoomType = roomtype;
            this.HotelName= hotelName;
        }

        public string Firstname
        {
            get => this.firstname;
            private set
            {
                if (value.Length< 3)
                {
                    throw new ArgumentException("Minumim length s 3 symbols");
                }
                for (int i = 0; i < value.Length; i++)
                {
                    if (char.IsDigit(value[i]))
                    {
                        throw new ArgumentException("No gigits allowed in");
                    }
                }
                this.firstname = value;
            }
        }
        public string Lastname
        {
            get => this.lastname;
            private set
            {
                if (value.Length < 3)
                {
                    throw new ArgumentException("Minumim length s 3 symbols");
                }
                for (int i = 0; i < value.Length; i++)
                {
                    if (char.IsDigit(value[i]))
                    {
                        throw new ArgumentException("No gigits allowed in");
                    }
                }
                this.lastname = value;
            }
            
        }
        public DateTime Start { get => this.startdate; private set { this.startdate = value; } }
        public DateTime End { get => this.enddate; private set { this.enddate = value; } }
        public int Total { get => this.total; private set { this.total = value; } }
        public string RoomType { get => this.roomType; private set { this.roomType = value; } }
        public string HotelName { get => this.hotel; private set { this.hotel = value; } }
    }
}
