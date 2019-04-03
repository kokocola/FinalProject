using FinalProject.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace FinalProject.WpfClient
{
	/// <summary>
	/// Interaction logic for TitleStoreWindow.xaml
	/// </summary>
	public partial class TitleStoreWindow : Window, INotifyPropertyChanged
	{
		public TitleStoreWindow()
		{
			InitializeComponent();
			DataContext = this;
			IsSaved = false;
		}

		public bool IsSaved { get; set; }

		private Title _selectedTitle;
		public Title SelectedTitle
		{
			get { return _selectedTitle; }
			set
			{
				_selectedTitle = value;
				OnPropertyChanged(nameof(SelectedTitle));
			}
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

		private void ButtonSave_Click(object sender, RoutedEventArgs e)
		{
			IsSaved = true;
			this.Close();
		}
	}
}
