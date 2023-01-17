using Models;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    /**
     * Класс, содержащий основную логику покупки билетов
     */
    internal class Customer : ICustomer
    {
        private TicketProvider ticketProvider;
        private CashProvider cashProvider;
        private UserProvider userProvider;
        private User? client;
        private List<Ticket>? selectedTickets;

        /**
         * Конструктор класса
         */
        public Customer()
        {
            //Здесь создаются экземпляры классов работы с базами данных
            //Так как при уничтожении класса Customer нам больше не нужны экземпляры классов - провайдеров,
            //было решено организовать композицию с классами - провайдерами.
            this.cashProvider = new CashProvider();
            this.ticketProvider = new TicketProvider();
            this.userProvider = new UserProvider();
        }


        public List<Ticket> GetSelectedTickets()
        {
            return selectedTickets;
        }

        public void SetSelectedTickets(List<Ticket> selectedTickets)
        {
            this.selectedTickets = selectedTickets;
        }


        public UserProvider GetUserProvider()
        {
            return userProvider;
        }


        public User GetUser()
        {
            return client;
        }

        public void SetUser(User client)
        {
            this.client = client;
        }

        public bool BuyTicket(Ticket ticket)
        {
            bool flag;
            cashProvider.Authorization(client);
            flag = cashProvider.Buy(ticket);
            if (flag)
            {
                flag = ticketProvider.UpdateTicketStatus(ticket);
            }
            return flag;
        }

        public List<Ticket> SearchTicket(DateTime date, int route)
        {
            List<Ticket> result = new ();
            var list = ticketProvider.GetTickets(route);
            foreach (Ticket ticket in list)
            {
                if (ticket.Date.Equals(date))
                {
                    result.Add(ticket);
                }
            }
            if (result.Count == 0)
            {
                throw new Exception("There are no tickets for this date");
            }
            return result;
        }
    }
}
