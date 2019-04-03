using FinalProject.Domain;
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
	class CreateCommand : ICommand
	{
		public event EventHandler CanExecuteChanged;

		public bool CanExecute(object parameter)
		{
			return true;
		}

		public void Execute(object parameter)
		{
			MainWindowViewModel mwvm = parameter as MainWindowViewModel;
			TitleStoreWindow tsWindow = new TitleStoreWindow
			{
				Owner = mwvm.Owner,
				SelectedTitle = new Title()
			};
			tsWindow.textBoxTitleId.IsEnabled = true;
			tsWindow.ShowDialog();

			if (tsWindow.IsSaved)
			{
				TitleServiceClient client = new TitleServiceClient();
				if (client.InsertTitle(tsWindow.SelectedTitle))
				{
					/* 
					 * dbset has no concept of index, so we cannot tell the observable collection where it was inserted
					 * if EF was local and not data virtualized, then I would just use public ObservableCollection<T> Local { get; }
					 * instead, we have to reset the page in case the add insert it into the current page - not so pretty but it works
					 */
					//mwvm.TitleDataVirtualized.Insert(?, tsWindow.SelectedTitle);
					mwvm.TitleDataVirtualized.ResetAsync();
				}
			}
		}
	}
}
