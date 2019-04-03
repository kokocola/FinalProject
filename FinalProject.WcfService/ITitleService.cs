using FinalProject.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.WcfService
{
	[ServiceContract]
	public interface ITitleService
	{
		// CREATE
		[OperationContract]
		bool InsertTitle(Title title);

		// READ
		[OperationContract]
		Title GetTitleById(string id);

		[OperationContract]
		IEnumerable<Title> GetTitlesByTitle(string title);

		[OperationContract]
		IEnumerable<Title> GetTitleRangeByTitle(string title, int startIndex, int count);

		[OperationContract]
		int GetTitleCountByTitle(string id);

		// UPDATE
		[OperationContract]
		bool UpdateTitle(Title title);

		// DELETE
		[OperationContract]
		bool DeleteTitle(string id);
	}
}