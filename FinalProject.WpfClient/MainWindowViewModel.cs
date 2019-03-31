using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using FinalProject.WpfClient.TitleServiceReference;


namespace FinalProject.WpfClient
{
	class MainWindowViewModel : INotifyPropertyChanged
	{
		private string resultCount;
		public string ResultCount
		{
			get { return resultCount; }
			set
			{
				resultCount = value;
				OnPropertyChanged(nameof(ResultCount));
			}
		}

		private string query;
		public string Query
		{
			get { return query; }
			set
			{
				if (query != value)
				{ 
					query = value;
					OnPropertyChanged(nameof(Query));

					Search.Execute(this);
				}
			}
		}

		private AsyncVirtualizingCollection<Title> titles;
		public AsyncVirtualizingCollection<Title> Titles
		{
			get { return titles; }
			set
			{
				titles = value;
				OnPropertyChanged(nameof(Titles));
			}
		}

		public SearchCommand Search { get; }

		public MainWindowViewModel()
		{
			query = "";
			Search = new SearchCommand();
			Search.Execute(this);
		}

		public event PropertyChangedEventHandler PropertyChanged;
		protected void OnPropertyChanged(string name)
		{
			PropertyChangedEventHandler handler = PropertyChanged;
			if (handler != null)
			{
				handler(this, new PropertyChangedEventArgs(name));
			}
		}
	}
}
