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
		public IMDbContext _context;

		public ConnectedData(IMDbContext currentContext)
		{
			_context = currentContext;
			_context.Database.Migrate(); // create database if it doesn't exist
		}

		// CREATE
		// SYNCHRONOUS
		public bool InsertTitle(Title title)
		{
            _context.Titles.Add(title);
			int changes = _context.SaveChanges();

			if (changes > 0)
			{
				return true;
			}
			return false;
		}

		// ASYNCHRONOUS
		public async Task<bool> InsertTitleAsync(Title title)
		{
			await _context.Titles.AddAsync(title);
			int changes = await _context.SaveChangesAsync();

			if (changes > 0)
			{
				return true;
			}
			return false;
		}

		// READ
		// SYNCHRONOUS
		public IEnumerable<Title> GetTitles()
		{
			//return _context.Titles.ToList();
			return _context.Titles;
		}

		public Title GetTitleById(string id)
		{
			return _context.Titles.Find(id);
		}

		public IEnumerable<Title> GetTitlesByTitle(string title)
		{
			//return _context.Titles.Where(s => s.PrimaryTitle.Contains(title)).ToList();
			return _context.Titles.Where(s => s.PrimaryTitle.Contains(title));
		}

		public IEnumerable<Title> GetTitleRangeByTitle(string title, int startIndex, int count)
		{
			//return _context.Titles.Where(s => s.PrimaryTitle.Contains(title)).Skip(startIndex).Take(count).ToList();
			return _context.Titles.Where(s => s.PrimaryTitle.Contains(title)).Skip(startIndex).Take(count);
		}

		public int GetTitleCountByTitle(string title)
		{
			return _context.Titles.Where(s => s.PrimaryTitle.Contains(title)).Count();
		}

		public bool TitleExists(string id)
		{
			return _context.Titles.Any(s => s.TitleId == id);
		}

		// ASYNCHRONOUS
		public async Task<Title> GetTitleByIdAsync(string id)
		{
			return await _context.Titles.FindAsync(id);
		}

		public async Task<IEnumerable<Title>> GetTitlesAsync()
		{
			return await _context.Titles.ToListAsync();
		}

		public async Task<IEnumerable<Title>> GetTitlesByTitleAsync(string title)
		{
			return await _context.Titles.Where(s => s.PrimaryTitle.Contains(title)).ToListAsync();
		}

		public async Task<IList<Title>> GetTitleRangeByTitleAsync(string title, int startIndex, int count)
		{
			return await _context.Titles.Where(s => s.PrimaryTitle.Contains(title)).Skip(startIndex).Take(count).ToListAsync();
		}

		public async Task<int> GetTitleCountByTitleAsync(string title)
		{
			return await _context.Titles.Where(s => s.PrimaryTitle.Contains(title)).CountAsync();
		}

		// UPDATE
		// SYNCHRONOUS
		public bool UpdateTitle(Title title)
		{
			Title titleEntity = _context.Titles.Find(title.TitleId);
			titleEntity.PrimaryTitle = title.PrimaryTitle;
			titleEntity.Genres = titleEntity.Genres;
			titleEntity.StartYear = title.StartYear;
			titleEntity.TitleType = title.TitleType;
            titleEntity.RuntimeMinutes = title.RuntimeMinutes;
            titleEntity.IsAdult = titleEntity.IsAdult;
            titleEntity.OriginalTitle = title.OriginalTitle;
            titleEntity.EndYear = title.EndYear;
            int changes = _context.SaveChanges();

			if (changes > 0)
			{
				return true;
			}
			return false;
		}

		// ASYNCHRONOUS
		public async Task<bool> UpdateTitleAsync(Title title)
		{
			Title titleEntity = _context.Titles.Find(title.TitleId);
			titleEntity.PrimaryTitle = title.PrimaryTitle;
			titleEntity.Genres = titleEntity.Genres;
			titleEntity.StartYear = title.StartYear;
			titleEntity.TitleType = title.TitleType;
            titleEntity.RuntimeMinutes = title.RuntimeMinutes;
            titleEntity.IsAdult = titleEntity.IsAdult;
            titleEntity.OriginalTitle = title.OriginalTitle;
            titleEntity.EndYear = title.EndYear;
            int changes = await _context.SaveChangesAsync();

			if (changes > 0)
			{
				return true;
			}
			return false;
		}

		// DELETE
		// SYNCHRONOUS
		public bool DeleteTitle(string id)
		{
			Title title = _context.Titles.Find(id);
			_context.Titles.Remove(title);
			int changes = _context.SaveChanges();

			if (changes > 0)
			{
				return true;
			}
			return false;
		}

		// ASYNCHRONOUS
		public async Task<bool> DeleteTitleAsync(string id)
		{
			Title title = await _context.Titles.FindAsync(id);
			_context.Titles.Remove(title);
			int changes = await _context.SaveChangesAsync();

			if (changes > 0)
			{
				return true;
			}
			return false;
		}	
	}
}
