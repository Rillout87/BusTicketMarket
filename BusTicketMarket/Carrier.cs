using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    /**
     * Модель перевозчика
     */
    internal class Carrier
    {
        public int Id { get; }
        public long CardNumber { get; }
        private List<int> zones = new(2);

        public Carrier(int id, long cardNumber)
        {
            this.Id = id;
            this.CardNumber = cardNumber;
        }
    }
}
