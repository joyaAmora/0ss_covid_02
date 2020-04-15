using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;

namespace app_models
{
    public class Invoice: INotifyPropertyChanged
    {
        const double txQC = 0.05;
        const double txCA = 0.09975;
        
        private Customer customer;
        private double subTotal;

        public event PropertyChangedEventHandler PropertyChanged;

        public static int invoiceId;
        public int InvoiceId { get;  private set; }
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

        public Invoice(Customer client)
        {
            Customer = client;
            CreationDateTime = DateTime.Now;
            InvoiceId = Interlocked.Increment(ref invoiceId);
        }

        public Invoice()
        {
            CreationDateTime = DateTime.Now;
            InvoiceId = Interlocked.Increment(ref invoiceId);
        }

        protected virtual void OnPropertyChanged([CallerMemberName]string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}
