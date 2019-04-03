using FinalProject.WpfClient.TitleServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace FinalProject.WpfClient
{
	class UpdateCommand : ICommand
	{
		public event EventHandler CanExecuteChanged;

		public bool CanExecute(object parameter)
		{
			return true;
		}

		public void Execute(object parameter)
		{
			MainWindowViewModel mwvm = parameter as MainWindowViewModel;
			if (mwvm.SelectedTitle != null)
			{
				TitleStoreWindow tsWindow = new TitleStoreWindow
				{
					Owner = mwvm.Owner,
					SelectedTitle = mwvm.SelectedTitle
				
				};

				tsWindow.textBoxTitleId.IsEnabled = false;

				tsWindow.ShowDialog();

				if (tsWindow.IsSaved)
				{
					TitleServiceClient client = new TitleServiceClient();
					
					if (client.UpdateTitle(tsWindow.SelectedTitle))
					{ 
						mwvm.SelectedTitle = tsWindow.SelectedTitle;
					}
				}
			}
			else
			{
				MessageBox.Show("No title selected for update.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}
	}
}
