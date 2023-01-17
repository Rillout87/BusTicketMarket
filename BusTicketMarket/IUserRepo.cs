using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    /**
     * Интерфейс взаимодействия с базой клиентов
     */
    internal interface IUserRepo
    {
        /// <summary>
        /// Создать нового пользователя
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="passwordHash"></param>
        /// <param name="cardNumber"></param>
        /// <returns></returns>
        int Create(string userName, int passwordHash, long cardNumber);

        /// <summary>
        /// получить пользователя по ID(для тестов, в приложении не используется)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        User Read(int id);

        /// <summary>
        /// Получить пользователя по имени
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        User Read(string userName);

        /// <summary>
        /// Получить список пользователей(для тестов, в приложении не используется)
        /// </summary>
        /// <returns></returns>
        List<User> ReadAll();

        /// <summary>
        /// Обновить пользователя(для тестов, в приложении не используется)
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        bool Update(User client);

        /// <summary>
        /// Удалить пользователя(для тестов, в приложении не используется)
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        bool Delete(User client);
    }
}
