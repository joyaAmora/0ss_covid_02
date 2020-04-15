using BillingManagement.UI.ViewModels.Commands;
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

		public ChangeViewCommand ChangeViewCommand { get; private set; }
		private void InitValues()
		{
			customerViewModel = new CustomerViewModel();
			invoiceViewModel = new InvoiceViewModel(customerViewModel.Customers);
			ChangeViewCommand = new ChangeViewCommand(ChangeView);
			ContentViewModel = customerViewModel;
		}
		private void ChangeView(string vm)
		{
			switch (vm)
			{
				case "customer":
					ContentViewModel = customerViewModel;
					break;
				case "invoice":
					ContentViewModel = invoiceViewModel;
					break;
			}
		}

		CustomerViewModel customerViewModel;
		InvoiceViewModel invoiceViewModel;

	

		public MainViewModel()
		{
			InitValues();

		}

	}
}
