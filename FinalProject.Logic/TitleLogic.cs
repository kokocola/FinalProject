﻿using FinalProject.Data;
using FinalProject.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Logic
{
	public class TitleLogic
	{
		ConnectedData _data;

		public TitleLogic(string connectionString = "")
		{
			_data = new ConnectedData(new IMDbContext());
		}

		// CREATE
		// SYNCHRONOUS
		public void InsertTitle(Title title)
		{
			_data.InsertTitle(title);
		}

		// ASYNCHRONOUS
		public async Task InsertTitleAsync(Title title)
		{
			await _data.InsertTitleAsync(title);
		}

		// READ
		// SYNCHRONOUS
		public Title GetTitleById(string id)
		{
			return _data.GetTitleById(id);
		}

		public IList<Title> GetTitles()
		{
			return _data.GetTitles();
		}

		public IList<Title> GetTitlesByTitle(string title)
		{
			return _data.GetTitlesByTitle(title);
		}

		public IList<Title> GetTitleRangeByTitle(string title, int startIndex, int count)
		{
			return _data.GetTitleRangeByTitle(title, startIndex, count);
		}

		public int GetTitleCountByTitle(string title)
		{
			return _data.GetTitleCountByTitle(title);
		}

		public bool TitleExists(string id)
		{
			return _data.TitleExists(id);
		}

		// ASYNCHRONOUS
		public async Task<Title> GetTitleByIdAsync(string id)
		{
			return await _data.GetTitleByIdAsync(id);
		}

		public async Task<IList<Title>> GetTitlesAsync()
		{
			return await _data.GetTitlesAsync();
		}

		public async Task<IList<Title>> GetTitlesByTitleAsync(string title)
		{
			return await _data.GetTitlesByTitleAsync(title);
		}

		public async Task<IList<Title>> GetTitleRangeByTitleAsync(string title, int startIndex, int count)
		{
			return await _data.GetTitleRangeByTitleAsync(title, startIndex, count);
		}

		public async Task<int> GetTitleCountByTitleAsync(string title)
		{
			return await _data.GetTitleCountByTitleAsync(title);
		}

		// UPDATE
		public bool UpdateTitle(Title title)
		{
			return _data.UpdateTitle(title);
		}

		public async Task<bool> UpdateTitleAsync(Title title)
		{
			return await _data.UpdateTitleAsync(title);
		}

		// DELETE
		// SYNCHRONOUS
		public void DeleteTitle(string id)
		{
			_data.DeleteTitle(id);
		}

		// ASYNCHRONOUS
		public async Task DeleteTitleAsync(string id)
		{
			await _data.DeleteTitleAsync(id);
		}
	}
}