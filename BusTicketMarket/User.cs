using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Models
{
    /**
     * Модель пользователя
     */
    internal class User
    {
        public int Id { get; }
        public string UserName { get; }
        public int HashPassword { get; }
        public long CardNumber { get; }

        public User(int id, string userName, int hashPassword, long cardNumber)
        {
            this.Id = id;
            this.UserName = userName;
            this.HashPassword = hashPassword;
            this.CardNumber = cardNumber;
        }


        public override string ToString()
        {
            return "Client { " +
                    "id= " + Id +
                    ", userName= " + UserName +
                    ", cardNumber= " + string.Format("{0:d16}", CardNumber) +
                    " }";
        }

        public override bool Equals(Object? o)
        {
            if (o == null || this.GetType() != o.GetType()) return false;
            return this.Equals((User)o);
        }


        public bool Equals(User client)
        {
            return Id == client.Id && HashPassword == client.HashPassword && CardNumber == client.CardNumber && UserName.Equals(client.UserName);
        }

        public override int GetHashCode()
        {
            return (UserName.GetHashCode() + CardNumber.GetHashCode()) ^ (Id + HashPassword);
        }
    }
}
