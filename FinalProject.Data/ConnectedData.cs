using Microsoft.EntityFrameworkCore;
using FinalProject.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Data
{
	public class ConnectedData
	{
		public IMDbContext context;

		public ConnectedData(IMDbContext currentContext)
		{
			context = currentContext;
			context.Database.Migrate(); // create database if it doesn't exist
		}

		// CREATE

		// READ
		public Title GetTitleById(string id)
		{
			return context.Titles.Find(id);
		}

		public IList<Title> GetMoviesByTitle(string title)
		{
			return context.Titles.Where(s => s.TitleType == "Movie").Where(s => s.PrimaryTitle.Contains(title)).ToList();
		}


		public IList<Title> GetMovieRangeByTitle(string title, int startIndex, int count)
		{
			return context.Titles.Where(s => s.TitleType == "Movie").Where(s => s.PrimaryTitle.Contains(title)).Skip(startIndex).Take(count).ToList();
		}

		public int GetMovieCountByTitle(string title)
		{
			return context.Titles.Where(s => s.TitleType == "Movie").Where(s => s.PrimaryTitle.Contains(title)).Count();
		}



		// UPDATE

		// DELETE
	}
}
