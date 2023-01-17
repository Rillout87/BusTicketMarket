using Models;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    /**
     * Класс репозиторий для имитации работы с базой данных перевозчиков
     */
    internal class CarrierRepository : ICarrierRepo
    {
        private static CarrierRepository? carrierRepository;
        private List<Carrier> carriers;

        private CarrierRepository()
        {
            // Заполняем базу данных
            carriers = new List<Carrier>();
            carriers.Add(new Carrier(1, 1));

        }

        public static CarrierRepository GetCarrierRepository()
        {
            if (carrierRepository == null)
            {
                carrierRepository = new CarrierRepository();
            }
            return carrierRepository;
        }

        public Carrier Read(int id)
        {
            foreach (var carrier in carriers)
            {
                if (carrier.Id == id)
                {
                    return carrier;
                }
            }
            throw new Exception("A carrier with this ID not found");
        }
    }
}
