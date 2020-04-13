using app_models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace BillingManagement.Business
{
   public class InvoicesDataService : IDataService<Invoice>
    {
        List<Invoice> invoices = new List<Invoice>();

        public InvoicesDataService()
        {
            Random rnd = new Random();

            for (int i = 0; i < 500; i++)
            {
                var subTotalRnd = rnd.Next(10, 1000);
                Invoice newInvoice = new Invoice()
                {
                    SubTotal = subTotalRnd
                };
                invoices.Add(newInvoice);
            }
        }
        public IEnumerable<Invoice> GetAll()
        {
            foreach (Invoice i in invoices)
            {
                yield return i;
            }
        }
    }
}
