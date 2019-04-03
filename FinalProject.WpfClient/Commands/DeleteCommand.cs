using FinalProject.WpfClient.TitleServiceReference;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FinalProject.WpfClient
{
	class DeleteCommand : ICommand
	{
		public event EventHandler CanExecuteChanged;

		public bool CanExecute(object parameter)
		{
			return true;
		}

		public void Execute(object parameter)
		{
			MainWindowViewModel mwvm = parameter as MainWindowViewModel;
			TitleServiceClient client = new TitleServiceClient();
			client.DeleteTitle(mwvm.SelectedTitle.TitleId);
			mwvm.TitleDataVirtualized.Remove(mwvm.SelectedTitle);
		}
	}
}
