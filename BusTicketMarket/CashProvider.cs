using Interfaces;
using Models;
using Services;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace Core
{
    /**
     * Класс - провайдер для взаимодействия с банком и базой перевозчиков
     */
    internal class CashProvider
    {
        private long cardNumber;
        private bool isAuthorized;
        private ICashRepo cashRepository;
        private ICarrierRepo carrierRepository;

        /**
         * Конструктор класса
         */
        public CashProvider()
        {
            // Класс репозитория находится в единственном экземпляре для того, чтобы не создавать несколько подключений
            // к базе данных. Реализация паттерна Синглтон.
            this.carrierRepository = CarrierRepository.GetCarrierRepository();
            this.cashRepository = CashRepository.GetCashRepository();
        }

        /**
         * Метод покупки билета
         *
         * @param ticket билет
         * @return результат выполнения операции
         * @throws RuntimeException
         */
        public bool Buy (Ticket ticket)
        {
            Carrier carrier = carrierRepository.Read(1);
            if (isAuthorized)
            {
                return cashRepository.Transaction(ticket.Price, cardNumber, carrier.CardNumber);
            }
            else
            {
                throw new Exception("Client is not Authorized");
            }
        }



        /**
         * Метод авторизации клиента. Здесь должно быть реализовано обращение к банку для подтверждения личности клиента.
         *
         * @param client
         */
        public void Authorization (User? user)
        {
            if (((CashRepository)cashRepository).GetClients().Select(x =>x.Card).Contains(user.CardNumber))
            {
                cardNumber = user.CardNumber;
                isAuthorized = true;
            }
        }
    }
}
