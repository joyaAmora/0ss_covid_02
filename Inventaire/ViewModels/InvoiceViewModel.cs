using app_models;
using BillingManagement.Business;
using System.Collections.ObjectModel;

namespace BillingManagement.UI.ViewModels
{
    class InvoiceViewModel: BaseViewModel
    {

       // InvoicesDataService invoicesDataService = new InvoicesDataService(CustomersDataService CDS);
        private ObservableCollection<Invoice> customersInvoices;

        private Invoice selectedInvoice;

        public ObservableCollection<Invoice> CustomersInvoices
        {
            get => customersInvoices;
            private set
            {
                customersInvoices = value;
                OnPropertyChanged();
            }
        }

        public Invoice SelectedInvoice
        {
            get => selectedInvoice;
            set
            {
                selectedInvoice = value;
                OnPropertyChanged();
            }
        }

        public InvoiceViewModel()
        {
            InitValues();
        }

        private void InitValues()
        {
            //customersInvoices = new ObservableCollection<Invoice>(InvoicesDataService.GetAll());
            
        }

    }
}

