using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ABC.Broker
{
    public class StorageBroker : IStorageBroker
    {
        public List<string> GetAllData()
        {
            return new List<string>()
           {
               "Javed",
               "Khan",
               "Jan",
               "Olfath"
           };
        }
    }
}
