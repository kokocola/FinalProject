using FinalProject.Domain;
using FinalProject.WpfClient.TitleServiceReference;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace FinalProject.WpfClient
{
	class SearchCommand : ICommand
	{
		public event EventHandler CanExecuteChanged;

		public bool CanExecute(object parameter)
		{
			return true;
		}

		public async void Execute(object parameter)
		{
			MainWindowViewModel mwvm = parameter as MainWindowViewModel;
			if (!string.IsNullOrEmpty(mwvm.Query))
			{ 
				mwvm.ResultCount = $"Searching for '{mwvm.Query}'";
			}
			
			mwvm.TitleProvider.TitleName = mwvm.Query;
			// reset scroll position (but how do we access the view from the view model, and isn't this bad? - what's the right way?)
			if (string.IsNullOrEmpty(mwvm.Query) == false && mwvm.TitleDataVirtualized[0] != null)
			{ 
				mwvm.Owner.listViewTitles.ScrollIntoView(mwvm.TitleDataVirtualized[0]);
			}
			// TODO: cancel all ongoing searches when a new search begins - is this even possible with WCF?
			await Task.Run( () => { mwvm.TitleDataVirtualized.ResetAsync();});
			int count = await mwvm.TitleProvider.GetCountAsync();
			mwvm.ResultCount = count.ToString();

		}
	}
}