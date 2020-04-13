using app_models;
using BillingManagement.Business;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;

namespace BillingManagement.UI.ViewModels
{
    public class CustomerViewModel : BaseViewModel
    {
        readonly CustomersDataService customersDataService = new CustomersDataService();

        private ObservableCollection<Customer> customers;
        private Customer selectedCustomer;

        public ObservableCollection<Customer> Customers
        {
            get => customers;
            private set
            {
                customers = value;
                OnPropertyChanged();
            }
        }

        public Customer SelectedCustomer
        {
            get => selectedCustomer;
            set
            {
                selectedCustomer = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(CustomerContactsInfos));
            }
        }

        private string customerContactsInfos;

        public string CustomerContactsInfos
        {
            get 
            {
                if (selectedCustomer != null)
                {
                    var contact = new StringBuilder();
                    foreach (var contacts in SelectedCustomer.ContactInfos)
                    {
                        contact.AppendLine(contacts.ContactType.ToString() + " : " + contacts.Contact.ToString());
                    }
                    return contact.ToString();
                }
                else
                    return "";

            }
            set 
            { 
                customerContactsInfos = value;
                OnPropertyChanged();
            }
        }


        public CustomerViewModel()
        {
            InitValues();
        }

        private void InitValues()
        {
            Customers = new ObservableCollection<Customer>(customersDataService.GetAll());
            ContactInfosDataService contact = new ContactInfosDataService();
            InvoicesDataService invoicesDataService = new InvoicesDataService();
            Debug.WriteLine(Customers.Count);
        }

    }
}
