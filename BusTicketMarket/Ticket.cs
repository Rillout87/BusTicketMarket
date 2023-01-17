using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    /**
     * Модель билета
     */
    internal class Ticket
    {
        private long id;
        private int place;
        public DateTime Date { get; }
        
        public int RouteNumber { get; }
        private int zoneStart;
        private int zoneStop;
        public int Price { get; }
        private bool isValid;

        public Ticket(int routeNumber, int place, int price, DateTime date, bool isValid)
        {
            this.RouteNumber = routeNumber;
            this.place = place;
            this.Price = price;
            this.Date = date;
            this.isValid = isValid;
        }

        public bool GetValid() => isValid;
        public void SetValid(bool value) => isValid = value;

        public override string ToString()
        {
            return "Ticket" +
                    " Route Number " + RouteNumber +
            ", Place " + place +
                    ", Price " + Price + " rub." +
                    ", Date " + Date +
                    ", " + (isValid ? "Free" : "Busy");
        }


        public string ToPrint()
        {
            return "Ticket" +
                    "\nRoute Number " + RouteNumber +
                    "\nPlace " + place +
                    "\nPrice " + Price + "rub." +
                    "\nDate " + Date;
        }

        public override int GetHashCode()
        {
            return Date.GetHashCode() ^ (RouteNumber + place + Price);
        }


        public override bool Equals(Object? obj)
        {
            if (obj == null || obj.GetType() != this.GetType())
            {
                return false;
            }
            return this.Equals((Ticket)obj);
        }


        public bool Equals(Ticket ticket)
        {
            bool isIt = ticket != null
                    && ticket.GetHashCode() == this.GetHashCode()
                    && ticket.RouteNumber == this.RouteNumber
                    && ticket.place == this.place
                    && ticket.Price == this.Price
                    && ticket.Date.Equals(this.Date);
                    

            if (isIt)
            {
                return true;
            }
            return false;
        }
    }
}
