using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Interfaces
{
    /**
    * Интерфейс взаимодействия с базой перевозчиков
    */
    internal interface ICarrierRepo
    {
        /// <summary>
        /// Получить модель перевозчика из базы по ID
        /// </summary>
        /// <param name="id">Идентификатор перевозчика в базе</param>
        /// <returns></returns>
        Carrier Read(int id);
    }
}
