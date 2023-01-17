using Core;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientApplication
{
    /**
     * Класс аутентификации пользователя
     */
    internal class Authentication
    {
        /// <summary>
        /// Метод производит аутентификацию
        /// </summary>
        /// <param name="userProvider"></param>
        /// <param name="login"></param>
        /// <param name="passHash"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static User AuthenticationRequest(UserProvider userProvider, string login, int passHash)
        {
            var client = userProvider.GetClientByName(login);
            if (client.HashPassword == passHash)
            {
                return client;
            }
            else
            {
                throw new Exception("Authentication fail");
            }
        }
    }
}
