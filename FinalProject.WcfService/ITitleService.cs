using FinalProject.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace FinalProject.WcfService
{
	[ServiceContract]
	public interface ITitleService
	{
		[OperationContract]
		Title GetTitleById(string id);

		[OperationContract]
		IList<Title> GetTitlesByTitle(string title);

		[OperationContract]
		IList<Title> GetTitleRangeByTitle(string title, int startIndex, int count);

		[OperationContract]
		int GetTitleCountByTitle(string id);
	}
}
