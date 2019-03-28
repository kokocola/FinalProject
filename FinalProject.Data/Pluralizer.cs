using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Data
{
	public class Pluralizer : IPluralizer
	{
		public string Pluralize(string name)
		{
			return Inflector.Inflector.Pluralize(name) ?? name;
		}

		public string Singularize(string name)
		{
			return Inflector.Inflector.Singularize(name) ?? name;
		}
	}
}
