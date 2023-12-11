using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exEncomendas.Entidades
{
    internal class Client
    {
        public string Name { private set; get; }
        private string email;
        private DateTime birthday;

        public Client(string name, string email, DateTime birthday)
        {
            this.Name = name;
            this.email = email;
            this.birthday = birthday;
        }
        public override string ToString()
        {
            return $"\n\nDados do cliente:" +
                $"\n\tNome: {Name}," +
                $"\n\tEmail: {email}," +
                $"\n\tData de nascimento: {birthday.ToLongDateString()}";
        }
    }
}
