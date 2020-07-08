using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ABC.Broker
{
   public interface IStorageBroker
    {
        List<string> GetAllData();
    }
}
