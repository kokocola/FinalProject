using FinalProject.Logic;
using FinalProject.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace FinalProject.WcfService
{
	public class TitleService : ITitleService
	{
		public Title GetTitleById(string id)
		{
			TitleLogic logic = new TitleLogic();
			Title title = logic.GetTitleById(id);
			return title;
		}

		public IList<Title> GetTitlesByTitle(string title)
		{
			TitleLogic logic = new TitleLogic();
			IList<Title> titles = logic.GetTitlesByTitle(title).ToList();
			return titles;
		}

		public IList<Title> GetTitleRangeByTitle(string title, int startIndex, int count)
		{
			TitleLogic logic = new TitleLogic();
			IList<Title> titles = logic.GetTitleRangeByTitle(title, startIndex, count).ToList();
			return titles;
		}

		public int GetTitleCountByTitle(string title)
		{
			TitleLogic logic = new TitleLogic();
			return logic.GetTitleCountByTitle(title);
		}
	}
}
