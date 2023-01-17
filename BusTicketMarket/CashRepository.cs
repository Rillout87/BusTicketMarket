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
     * Класс репозиторий для имитации работы с базой данных банка
     */
    internal class CashRepository : ICashRepo
    {
        private static CashRepository? cashRepository;

        private List<BankAccount> clients;

        public List<BankAccount> GetClients()
        {
            return clients;
        }

        private CashRepository()
        {
            //имитация работы банка
            clients = new List<BankAccount>();
            for (int i = 1; i <= 5; i++)
            {
                clients.Add(new BankAccount());
            }

        }

        public static CashRepository GetCashRepository()
        {
            if (cashRepository == null)
            {
                cashRepository = new CashRepository();
            }
            return cashRepository;
        }

        public bool Transaction(int payment, long cardFrom, long carrierСard)
        {
            // Проводим валидацию аккаунтов
            BankAccount? from = null;
            BankAccount? to = null;
            foreach (var client in clients)
            {
                if (client.Card == cardFrom)
                {
                    from = client;
                }
                if (client.Card == carrierСard)
                {
                    to = client;
                }
            }
            // Проверяем наличие банковских карт продавца и покупателя
            if (from == null)
            {
                throw new Exception("No withdrawal account.");
            }
            if (to == null)
            {
                throw new Exception("No money account.");
            }
            // Проверяем баланс средств на картах
            if (from.Balance - payment < 0)
            {
                throw new Exception("Insufficient funds.");
            }
            if (to.Balance > int.MaxValue - payment)
            {
                throw new Exception("Too much amount.");
            }
            // Блок finally выполнится в любом случае, даже если произойдет исключение.
            // Помещая операции по переводу денег в блок finally, мы создаем дополнительную безопасность
            // проведения транзакции.
            try
            {
            }
            finally
            {
                clients.Remove(from);
                clients.Remove(to);
                from.Balance = from.Balance - payment;
                to.Balance = to.Balance + payment;
                clients.Add(from);
                clients.Add(to);
            }
            return true;
        }
    }
}
