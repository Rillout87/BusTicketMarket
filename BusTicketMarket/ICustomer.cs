using Models;
using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Interfaces
{

    /**
     * Интерфейс взаимодействия с клиентским приложением
     */
    internal interface ICustomer
    {
        List<Ticket> GetSelectedTickets();

        void SetSelectedTickets(List<Ticket> selectedTickets);

        User GetUser();

        void SetUser(User client);

        UserProvider GetUserProvider();

        /// <summary>
        /// Метод покупки билета
        /// </summary>
        /// <param name="ticket">билет</param>
        /// <returns>успешность выполненной операции</returns>
        bool BuyTicket(Ticket ticket);

        /// <summary>
        /// Метод поиска билетов по дате и номеру маршрута
        /// </summary>
        /// <param name="date">дата</param>
        /// <param name="route">номер маршрута</param>
        /// <returns>список доступных для приобретения билетов</returns>
        List<Ticket> SearchTicket(DateTime date, int route);

    }
}
