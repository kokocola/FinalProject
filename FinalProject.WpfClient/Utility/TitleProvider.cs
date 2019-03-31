using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalProject.WpfClient.TitleServiceReference;

namespace FinalProject.WpfClient
{
	public class TitleProvider : IItemsProvider<Title>
	{
		private readonly string title;
		public TitleProvider(string title)
		{
			this.title = title;
		}

		public int FetchCount()
		{
			TitleServiceClient client = new TitleServiceClient();
			int count = client.GetTitleCountByTitle(title);
			return count;
			
		}

		public IList<Title> FetchRange(int startIndex, int count)
		{
			TitleServiceClient client = new TitleServiceClient();
			IList<Title> titles = client.GetTitleRangeByTitle(title, startIndex, count);
			return titles;
		}
	}
}
