using REHOMAS.BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REHOMAS.Business_Layer
{
    class Booking
    {
        int costPerRoom = 1200;
        int costPerExtra = 1200;
        private string refNo;
        private Guest guest;
        private DateTime startDate;
        private DateTime endDate;
        private int numPeople;
        private int confirmed;
        private int totalCost;

        public string RefNo { get => refNo; set => refNo = value; }
        public Guest Guest { get => guest; set => guest = value; }
        public DateTime StartDate { get => startDate; set => startDate = value; }
        public DateTime EndDate { get => endDate; set => endDate = value; }
        public int NumPeople { get => numPeople; set => numPeople = value; }
        public int Confirmed { get => confirmed; set => confirmed = value; }
        public int TotalCost { get => totalCost; set => totalCost = value; }

        public Booking(string refNo, Guest guest, DateTime startDate, DateTime endDate, int numPeople, int confirmed)
        {
            this.refNo = refNo;
            this.guest = guest;
            this.startDate = startDate;
            this.endDate = endDate;
            this.numPeople = numPeople;
            this.confirmed = confirmed;
            totalCost = (costPerRoom + costPerExtra * (numPeople - 1)) * DaysBetween(startDate, endDate);
            if (totalCost < 0)
            {
                totalCost = -totalCost;
                DateTime temp = startDate;
                startDate = endDate;
                endDate = temp;

            }
        }

        public Booking()
        {
        }

        int DaysBetween(DateTime d1, DateTime d2)
        {
            TimeSpan span = d2.Subtract(d1);
            return (int)span.TotalDays;
        }
    }
}
