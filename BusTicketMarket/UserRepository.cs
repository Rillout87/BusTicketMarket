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
    internal class UserRepository : IUserRepo
    {
        private static UserRepository? clientRepository;
        private List<User> clients;

        private UserRepository()
        {
            //имитация работы базы клиентов
            clients = new List<User>();
            clients.Add(new User(1, "Ivan", "1111".GetHashCode(), 2));
            clients.Add(new User(2, "Vasiliy", "2222".GetHashCode(), 3));
            clients.Add(new User(3, "Fedor", "3333".GetHashCode(), 4));
            clients.Add(new User(4, "Grigoriy", "4444".GetHashCode(), 5));
        }

        public static UserRepository GetClientRepository()
        {
            if (clientRepository == null)
            {
                clientRepository = new UserRepository();
            }
            return clientRepository;
        }


        public int Create(String userName, int passwordHash, long cardNumber)
        {
            int id = clients.Count + 1;
            User client = new User(id, userName, passwordHash, cardNumber);
            foreach (var currentClient in clients)
            {
                if (currentClient.Id == client.Id)
                {
                    throw new Exception("A client already exists");
                }
            }
            clients.Add(client);
            return client.Id;
        }

        public User Read(int id)
        {
            foreach (var client in clients)
            {
                if (client.Id == id)
                {
                    return client;
                }
            }
            throw new Exception("A client with this ID not found");
        }

        public User Read(string userName)
        {
            foreach (var client in clients)
            {
                var clientName = client.UserName;
                if (clientName.Equals(userName))
                {
                    return client;
                }
            }
            throw new Exception("A client with this ID not found");
        }


        public List<User> ReadAll()
        {
            if (clients is null || clients.Count == 0)
            {
                throw new Exception("List of clients is empty");
            }
            return clients;
        }

        public bool Update(User client)
        {
            //User tempClient = null;
            foreach (User currentClient in clients)
            {
                if (currentClient.Id == client.Id)
                {
                    clients.Remove(currentClient);
                    clients.Add(client);
                    return true;
                }
            }
            return false;
        }


        public bool Delete(User client)
        {
            foreach (User currentClient in clients)
            {
                if (currentClient.Equals(client))
                {
                    clients.Remove(currentClient);
                    return true;
                }
            }
            return false;
        }
    }
}
