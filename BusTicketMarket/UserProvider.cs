using Interfaces;
using Services;
using Models;

namespace Core
{
    /**
     * Класс - провайдер для работы с базой данных клиентов
     */
    internal class UserProvider
    {
        private IUserRepo clientRepository;

        /**
         * Конструктор класса
         */
        public UserProvider()
        {
            // Класс репозитория находится в единственном экземпляре для того, чтобы не создавать несколько подключений
            // к базе данных. Реализация паттерна Синглтон.
            this.clientRepository = UserRepository.GetClientRepository();
        }


        /// <summary>
        /// Метод создания нового клиента
        /// </summary>
        /// <param name="userName">имя клиента</param>
        /// <param name="passwordHash">хэш пароля</param>
        /// <param name="cardNumber">номер банковской карты</param>
        /// <returns>ID клиента в базе</returns>
        public int CreateClient(string userName, int passwordHash, long cardNumber)
        {
            int id = clientRepository.Create(userName, passwordHash, cardNumber);
            return id;
        }

        /// <summary>
        /// Метод поиска клиента из базы по имени
        /// </summary>
        /// <param name="userName">имя клиента</param>
        /// <returns>модель клиента</returns>
        public User GetClientByName(string userName)
        {
            var client = clientRepository.Read(userName);
            return client;
        }


        /// <summary>
        /// Метод получения списка всех клиентов(для реализации тестов и администрирования), не используется
        /// </summary>
        /// <returns>список клиентов</returns>
        public List<User> GetAllClients()
        {
            var clients = clientRepository.ReadAll();
            return clients;
        }
    }
}
