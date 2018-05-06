using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REHOMAS.Business_Layer
{
    class Room
    {
        private int roomNo;
        private int noPeople;
        private Collection<Booking> bookings;
        private decimal cost;

        public int RoomNo { get => roomNo; set => roomNo = value; }
        public int NoPeople { get => noPeople; set => noPeople = value; }
        public decimal Cost { get => cost; set => cost = value; }
        internal Collection<Booking> Bookings { get => bookings; set => bookings = value; }

        public Room(int roomNo, int noPeople, decimal cost)
        {
            Bookings = new Collection<Booking>();
            this.roomNo = roomNo;
            this.noPeople = noPeople;
            this.cost = cost;
        }

        public void addBooking(Booking b)
        {
            bookings.Add(b);
        }

        public int isAvailable(Booking b)
        {
            DateRange range;
            foreach (Booking value in Bookings)
            {
                range = new DateRange(value.StartDate, value.EndDate);
                if (range.Includes(b.StartDate) || range.Includes(b.EndDate)){
                    return 1;
                    //return b.Confirmed;
                }
            }
            foreach (Booking value in Bookings)
            {
                range = new DateRange(b.StartDate, b.EndDate);
                if (range.Includes(value.StartDate) || range.Includes(value.EndDate))
                {
                    return 1;
                    //return b.Confirmed;
                }
            }
            return -1;
        }
    }
}
