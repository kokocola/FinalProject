using AlphaChiTech.Virtualization;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace FinalProject.WpfClient
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			if (!VirtualizationManager.IsInitialized)
			{
				//set the VirtualizationManager’s UIThreadExcecuteAction. In this case
				//we’re using Dispatcher.Invoke to give the VirtualizationManager access
				//to the dispatcher thread, and using a DispatcherTimer to run the background
				//operations the VirtualizationManager needs to run to reclaim pages and manage memory.

				VirtualizationManager.Instance.UIThreadExcecuteAction = (a) => Dispatcher.Invoke(a);
				new DispatcherTimer(
					TimeSpan.FromSeconds(1),
					DispatcherPriority.Background,
					delegate (object s, EventArgs a)
					{
						VirtualizationManager.Instance.ProcessActions();
					},
					this.Dispatcher).Start();
			}
			InitializeComponent();
			MainWindowViewModel mwvm = new MainWindowViewModel();
			DataContext = mwvm;
			mwvm.Owner = this;

		}
	}
}
