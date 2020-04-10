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
        List<Invoice> invoices;
        List<Customer> customers;

        public InvoicesDataService(CustomersDataService customerDS)
        {
            customers = customerDS.GetAll().ToList();

            Random rnd = new Random();

            foreach (Customer c in customers)
            {
                c.Invoices = new ObservableCollection<Invoice>();

                var nbInvoices = rnd.Next(1, 5);

                for (int i = 0; i < nbInvoices; i++)
                {
                    var invoice = new Invoice();
                    invoice.Customer = c;
                    invoice.SubTotal = rnd.Next(5, 1001);
                    c.Invoices.Add(invoice);
                }
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
