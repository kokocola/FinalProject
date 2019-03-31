using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using FinalProject.WpfClient.TitleServiceReference;

namespace FinalProject.WpfClient
{
	class SearchCommand : ICommand
	{
		public event EventHandler CanExecuteChanged;

		public bool CanExecute(object parameter)
		{
			return true;
		}

		public void Execute(object context)
		{

			MainWindowViewModel mwvm = context as MainWindowViewModel;
			//MovieServiceClient client = new MovieServiceClient();

			mwvm.ResultCount = $"Searching for {mwvm.Query}";
			TitleProvider provider = new TitleProvider(mwvm.Query);
			mwvm.ResultCount = provider.FetchCount().ToString();
			//Task.Run(() => mwvm.Movies = new AsyncVirtualizingCollection<Movie>(provider)).ConfigureAwait(false);  // not a fan of blowing away the collection, but AFAIK you can't cancel WCF service calls
			mwvm.Titles= new AsyncVirtualizingCollection<Title>(provider);  // not a fan of blowing away the collection, but AFAIK you can't cancel WCF service calls
		}
	}
}
