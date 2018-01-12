////////////////////////////////////////////////////////////////////////////////
//
// Light Wings GameProject
//
// (C) 2009 Light Wings GameProject.
//
// https://github.com/LightWings-GameProject
//
////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Squirrel.ClassificationDefinitions
{
	public interface IOptionsService
	{
		void SaveString(string name, string category, string value);
		string LoadString(string name, string category);
		void DeleteCategory(string category);
	}
}
