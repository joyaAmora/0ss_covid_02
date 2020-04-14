using System;
using System.Collections.Generic;
using System.Text;

namespace BillingManagement.UI.ViewModels
{
    public class MainViewModel: BaseViewModel
    {
		private BaseViewModel contentViewModel 
;		

		public BaseViewModel ContentViewModel
		{
			get {
				return contentViewModel; }
			set
			{ 
				contentViewModel = value;
				OnPropertyChanged();
			}
		}

		CustomerViewModel customerViewModel;
		InvoiceViewModel invoiceViewModel;
		public MainViewModel()
		{
			customerViewModel = new CustomerViewModel();
			invoiceViewModel = new InvoiceViewModel(customerViewModel.Customers);
			ContentViewModel = customerViewModel;

		}

	}
}
