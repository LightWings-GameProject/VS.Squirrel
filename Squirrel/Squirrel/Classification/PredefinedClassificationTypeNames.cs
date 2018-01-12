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

namespace Squirrel
{
	public static class SquirrelPredefinedClassificationTypeNames
	{
		/// <summary>
		/// Open grouping classification.  Used for (, [, {, ), ], and }...  A subtype of the Squirrel
		/// operator grouping.
		/// </summary>
		public const string Grouping = "Squirrel grouping";

		/// <summary>
		/// Classification used for comma characters when used outside of a literal, comment, etc...
		/// </summary>
		public const string Comma = "Squirrel comma";

		/// <summary>
		/// Classification used for . characters when used outside of a literal, comment, etc...
		/// </summary>
		public const string Dot = "Squirrel dot";

		/// <summary>
		/// Classification used for all other operators
		/// </summary>
		public const string Operator = "Squirrel operator";

		/// <summary>
		/// Classification used for classes/types.
		/// </summary>
		public const string Class = "Squirrel class";

		/// <summary>
		/// Classification used for imported modules.
		/// </summary>
		public const string Module = "Squirrel module";

		/// <summary>
		/// Classification used for functions.
		/// </summary>
		public const string Function = "Squirrel function";

		/// <summary>
		/// Classification used for parameters.
		/// </summary>
		public const string Parameter = "Squirrel parameter";

		/// <summary>
		/// Classification used for builtins.
		/// </summary>
		public const string Builtin = "Squirrel builtin";

		/// <summary>
		/// Classification used for docstrings
		/// </summary>
		public const string Documentation = "Squirrel documentation";

		/// <summary>
		/// Classification used for regular expressions
		/// </summary>
		public const string RegularExpression = "Squirrel regex";
	}
}
