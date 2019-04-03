using AlphaChiTech.Virtualization;
using FinalProject.Domain;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Threading;

namespace FinalProject.WpfClient
{
	class MainWindowViewModel : INotifyPropertyChanged
	{
		public MainWindow Owner { get; set; }
		public ICollectionView TitlesView { get; set; }

		private Title _selectedTitle;
		public Title SelectedTitle {
			get { return _selectedTitle; }
			set
			{
				_selectedTitle = value;
				OnPropertyChanged(nameof(SelectedTitle));
			}
		}

		private string _resultCount;
		public string ResultCount
		{
			get { return _resultCount; }
			set
			{
				_resultCount = value;
				OnPropertyChanged(nameof(ResultCount));
			}
		}

		private string _query;
		public string Query
		{
			get { return _query; }
			set
			{
				if (_query != value)
				{
					_query = value;
					OnPropertyChanged(nameof(Query));
					Search.Execute(this);
				}
			}
		}

		public TitleProvider TitleProvider { get; set; }

		private VirtualizingObservableCollection<Title> _titleDataVirtualized = null;
		public VirtualizingObservableCollection<Title> TitleDataVirtualized
		{
			get // singleton pattern
			{
				if (_titleDataVirtualized == null)
				{
					_titleDataVirtualized =
						new VirtualizingObservableCollection<Title>(
							new PaginationManager<Title>(TitleProvider));
				}
				return _titleDataVirtualized;
			}
		}

		public CreateCommand Create { get; }
		public SearchCommand Search { get; }
		public UpdateCommand Update { get; }
		public DeleteCommand Delete { get; }

		public MainWindowViewModel()
		{
			_query = "";
			Create = new CreateCommand();
			Search = new SearchCommand();
			Update = new UpdateCommand();
			Delete = new DeleteCommand();
			TitleProvider = new TitleProvider();
			TitlesView = CollectionViewSource.GetDefaultView(TitleDataVirtualized);

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