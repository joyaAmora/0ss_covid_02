﻿using app_models;
using BillingManagement.Business;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace BillingManagement.UI.ViewModels
{
    class InvoiceViewModel: BaseViewModel
    {
        private ObservableCollection<Invoice> invoices;

        private Invoice selectedInvoice;

        public ObservableCollection<Invoice> Invoices
        {
            get => invoices;
            private set
            {
                invoices = value;
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

        public InvoiceViewModel(IEnumerable<Customer> customers)
        {
            InvoicesDataService ids = new InvoicesDataService(customers);
            Invoices = new ObservableCollection<Invoice>(ids.GetAll());
        }

    }
}

