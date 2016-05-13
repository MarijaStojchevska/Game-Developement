using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ПроектВП
{
   public class User
    {
        public string UserName { get; set; }
        public int Points { get; set; }
        public User(string userName)
        {
            this.UserName = userName;
            Points = 0;
        }
        public override string ToString()
        {
            return String.Format("Име: {0} Поени: {1}", UserName, Points);
        }
    }
}
