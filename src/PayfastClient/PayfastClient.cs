using PayfastClient.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayfastClient
{
    public class PayfastClient : IPayfastClient
    {
        public PayfastClient(string merchantId, string merchantKey)
        {
            
        }

        public Task<string> InitateTransaction(string itemName, double amount)
        {
            throw new NotImplementedException();
        }
    }
}
