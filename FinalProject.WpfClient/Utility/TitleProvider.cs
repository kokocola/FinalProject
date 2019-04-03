using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlphaChiTech.Virtualization;
using FinalProject.Domain;
using FinalProject.WpfClient.TitleServiceReference;

namespace FinalProject.WpfClient
{
	public class TitleProvider : IPagedSourceProviderAsync<Title>
	{
		public string TitleName { get; set; }
		public bool IsSynchronized { get; }
		public object SyncRoot { get; }

		public PagedSourceItemsPacket<Title> GetItemsAt(int pageoffset, int count, bool usePlaceholder)
		{
			TitleServiceClient client = new TitleServiceClient();
			return new PagedSourceItemsPacket<Title>()
			{
				LoadedAt = DateTime.Now,
				Items = client.GetTitleRangeByTitle(TitleName, pageoffset, count)
			};
		}

		public Task<PagedSourceItemsPacket<Title>> GetItemsAtAsync(int pageoffset, int count, bool usePlaceholder)
		{
			return Task.Run(() => {
				TitleServiceClient client = new TitleServiceClient();
				return new PagedSourceItemsPacket<Title>()
				{
					LoadedAt = DateTime.Now,
					Items = client.GetTitleRangeByTitle(TitleName, pageoffset, count)
				};

			});
		}

		public Title GetPlaceHolder(int index, int page, int offset)
		{
			return new Title { PrimaryTitle = "Waiting [" + page + "/" + offset + "]" };
		}

		public int Count
		{
			get
			{
				TitleServiceClient client = new TitleServiceClient();
				return client.GetTitleCountByTitle(TitleName);
				//return _titles.Count;
			}
		}

		public Task<int> GetCountAsync()
		{
			return Task.Run(() =>
			{
				TitleServiceClient client = new TitleServiceClient();
				return client.GetTitleCountByTitle(TitleName);
			});
		}

		public int IndexOf(Title item)
		{
			return -1;
			//return _titles.IndexOf(item);
		}

		public Task<int> IndexOfAsync(Title item)
		{
			return Task.Run(() => { return -1; });
		}

		public void OnReset(int count)
		{
		}
	}
}