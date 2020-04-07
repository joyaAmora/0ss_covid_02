using app_models;
using System;

namespace BillingManagement.UI.ViewModels
{
    public class InvoiceViewModel: BaseViewModel
    {
        const double txQC = 0.05;
        const double txCA = 0.09975;
        
        private Customer customer;
        private double subTotal;

        public static int InvoiceId { get; set; }
        public DateTime CreationDateTime { get; private set; }
        public Customer Customer {

            get => customer;
            set
            {
                customer = value;
                OnPropertyChanged();
            }
        }
        public double SubTotal {
            get => subTotal;
            set
            {
                subTotal = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(FedTax));
                OnPropertyChanged(nameof(ProvTax));
                OnPropertyChanged(nameof(Total));
            }
        }
        public double FedTax
        {
            get { return SubTotal * txCA; }
        }
        public double ProvTax 
        { 
            get { return SubTotal * txQC; }
        }
        public double Total 
        {
            get { return SubTotal + FedTax + ProvTax; }
        }

        public InvoiceViewModel(Customer client)
        {
            Customer = client;
            CreationDateTime = DateTime.Now;
            InvoiceId++;
        }

        public InvoiceViewModel()
        {
            CreationDateTime = DateTime.Now;
            InvoiceId++;
        }
    }
}
