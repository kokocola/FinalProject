using FinalProject.Data;
using FinalProject.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Logic
{
    public class MovieLogic
    {
		ConnectedData data;

		public MovieLogic(string connectionString)
		{
			data = new ConnectedData(new IMDbContext());
		}

		public Title GetTitleById(string id)
		{
			return data.GetTitleById(id);
		}

		public IList<Title> GetMoviesByTitle(string title)
		{
			return data.GetMoviesByTitle(title);
		}

		public IList<Title> GetMovieRangeByTitle(string title, int startIndex, int count)
		{
			return data.GetMovieRangeByTitle(title, startIndex, count);
		}

		public int GetMovieCountByTitle(string title)
		{
			return data.GetMovieCountByTitle(title);
		}

	}
}
