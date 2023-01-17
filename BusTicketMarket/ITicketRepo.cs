using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    /**
     * Интерфейс взаимодействия с базой билетов
     */
    internal interface ITicketRepo
    {
        /// <summary>
        /// Создать новый билет
        /// </summary>
        /// <param name="ticket"><Билет</param>
        /// <returns></returns>
        bool Create(Ticket ticket);

        /// <summary>
        /// Получить список билетов по номеру маршрута
        /// </summary>
        /// <param name="routeNumber">номер маршрута</param>
        /// <returns></returns>
        List<Ticket> ReadAll(int routeNumber);

        /// <summary>
        /// Обновить билет
        /// </summary>
        /// <param name="ticket"></param>
        /// <returns></returns>
        bool Update(Ticket ticket);

        /// <summary>
        /// Удалить билет
        /// </summary>
        /// <param name="ticket"></param>
        /// <returns></returns>
        bool Delete(Ticket ticket);
    }
}
