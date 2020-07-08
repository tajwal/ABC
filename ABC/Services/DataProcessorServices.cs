using ABC.Broker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ABC.Services
{
    public class DataProcessorServices : IDataProcessorServices
    {
        private readonly IStorageBroker storageBroker;
        public DataProcessorServices(IStorageBroker storageBroker)
        {
            this.storageBroker = storageBroker;
        }
        public List<string> ProcessData()
        {
            
           return this.storageBroker.GetAllData()
                .Select(item=>item.ToUpper()).ToList();

        }
    }
}
