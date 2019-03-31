using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace FinalProject.Domain
{
	[DataContract]
	public class Title
    {
		[DataMember]
		public string TitleId { get; set; }

		[DataMember]
		public string TitleType { get; set; }

		[DataMember]
		public string PrimaryTitle { get; set; }

		[DataMember]
		public string OriginalTitle { get; set; }

		[DataMember]
		public bool? IsAdult { get; set; }

		[DataMember]
		public short? StartYear { get; set; }

		[DataMember]
		public short? EndYear { get; set; }

		[DataMember]
		public int? RuntimeMinutes { get; set; }

		[DataMember]
		public string Genres { get; set; }
    }
}
