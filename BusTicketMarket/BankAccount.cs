using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    /**
     * Модель банковского аккаунта
     */
    internal class BankAccount
    {
        private static long oldCard = 0;
        public long Card { get;  }
        public int Balance { get; set;  }
        
        public BankAccount()
        {
            this.Card = oldCard + 1;
            oldCard = this.Card;
            Balance = 1000;
        }

        public override string ToString()
        {
            return "BankAccount {" +
                    " card= " + String.Format("{0:d16}", Card) +
                    ", balance= " + Balance +
                    " }";
        }
    }
}
