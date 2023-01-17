using Interfaces;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    /**
     * Класс репозиторий для имитации работы с базой данных
     */
    internal class TicketRepository : ITicketRepo
    {
        private static TicketRepository? ticketRepository;
        public List<Ticket> Tickets { get; set; }

        private TicketRepository()
        {
            //здесь симуляция работы с БД
            Tickets = new List<Ticket>();
            string strDate = "2022-10-27";
            //DateOnly sdf = new DateOnly();
            DateTime date;
            try
            {
                date = DateTime.Parse(strDate);
            }
            catch (Exception)
            {
                date = default;
            }
            GenerateTickets(1, 6, 10, date);
            GenerateTickets(2, 4, 15, date);
        }

        public static TicketRepository GetTicketRepository()
        {
            if (ticketRepository == null)
            {
                ticketRepository = new TicketRepository();
            }
            return ticketRepository;
        }


        public bool Create(Ticket ticket)
        {
            //функционал не используется
            Tickets.Add(ticket);
            return true;
        }

        public List<Ticket> ReadAll(int routeNumber)
        {
            List<Ticket> routeTickets = new ();
            foreach (Ticket ticket in Tickets)
            {
                if (ticket.RouteNumber == routeNumber && ticket.GetValid() == true)
                {
                    routeTickets.Add(ticket);
                }
            }
            if (routeTickets.Count == 0)
            {
                throw new Exception("There are no tickets for this bus.");
            }
            return routeTickets;
        }


        public bool Update(Ticket ticket)
        {
            foreach (Ticket tick in Tickets)
            {
                if (tick.Equals(ticket))
                {
                    Tickets.Remove(tick);
                    ticket.SetValid(false);
                    Tickets.Add(ticket);
                    return true;
                }
            }
            return false;
        }


        public bool Delete(Ticket ticket)
        {
            //функционал не используется
            if (Tickets.Contains(ticket))
            {
                Tickets.Remove(ticket);
                return true;
            }
            return false;
        }

        private void GenerateTickets(int routeNumber, int countPlaces, int price, DateTime date)
        {
            for (int i = 1; i <= countPlaces; i++)
            {
                Tickets.Add(new Ticket(routeNumber, i, price, date, true));
            }
        }
    }
}
