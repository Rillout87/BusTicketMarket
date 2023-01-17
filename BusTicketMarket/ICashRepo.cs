using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    /**
     * Интерфейс взаимодействия с базой банковских операций
     */
    internal interface ICashRepo
    {    
        /// <summary>
        /// Метод проведения транзакции
        /// </summary>
        /// <param name="payment">платеж</param>
        /// <param name="cardFrom">карта покупателя</param>
        /// <param name="cardTo">карта продавца</param>
        /// <returns>результат выполнения операции</returns>
        bool Transaction(int payment, long cardFrom, long cardTo);
    }
}
