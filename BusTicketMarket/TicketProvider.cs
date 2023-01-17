using Interfaces;
using Models;
using Services;

namespace Core
{
    /**
     * Класс - провайдер для работы с базой данных билетов
     */
    internal class TicketProvider
    {
        private ITicketRepo ticketRepo;
        public TicketProvider()
        {
            // Класс репозитория находится в единственном экземпляре для того, чтобы не создавать несколько подключений
            // к базе данных. Реализация паттерна Синглтон.
            this.ticketRepo = TicketRepository.GetTicketRepository();
        }

        /// <summary>
        /// Метод получения билетов из базы данных
        /// </summary>
        /// <param name="routeNumber">номер маршрута</param>
        /// <returns>список билетов</returns>
        public List<Ticket> GetTickets(int routeNumber) => ticketRepo.ReadAll(routeNumber);


        /**
         * Метод обновления статуса билета
         *
         * @param ticket билет
         * @return результат выполнения операции
         */
        public bool UpdateTicketStatus(Ticket ticket) => ticketRepo.Update(ticket);
    }
}
