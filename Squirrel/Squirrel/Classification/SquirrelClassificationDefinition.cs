using System.ComponentModel.Composition;
using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Utilities;
using Microsoft.VisualStudio.Language.StandardClassification;

namespace Squirrel
{
	/// <summary>
	/// Classification type definition export for Squirrel
	/// </summary>
	internal static class SquirrelClassificationDefinition
	{
		// This disables "The field is never used" compiler's warning. Justification: the field is used by MEF.
#pragma warning disable 169

		/// <summary>
		/// Defines the "Squirrel" classification type.
		/// </summary>
		[Export(typeof(ClassificationTypeDefinition))]
		[Name("Squirrel")]
		private static ClassificationTypeDefinition typeDefinition;

		[Export]
		[Name(SquirrelPredefinedClassificationTypeNames.Class)]
		[BaseDefinition(PredefinedClassificationTypeNames.Identifier)]
		internal static ClassificationTypeDefinition ClassClassificationDefinition = null; // Set via MEF

		[Export]
		[Name(SquirrelPredefinedClassificationTypeNames.Function)]
		[BaseDefinition(PredefinedClassificationTypeNames.Identifier)]
		internal static ClassificationTypeDefinition FunctionClassificationDefinition = null; // Set via MEF

		[Export]
		[Name(SquirrelPredefinedClassificationTypeNames.Parameter)]
		[BaseDefinition(PredefinedClassificationTypeNames.Identifier)]
		internal static ClassificationTypeDefinition ParameterClassificationDefinition = null; // Set via MEF

		[Export]
		[Name(SquirrelPredefinedClassificationTypeNames.Module)]
		[BaseDefinition(PredefinedClassificationTypeNames.Identifier)]
		internal static ClassificationTypeDefinition ModuleClassificationDefinition = null; // Set via MEF

		[Export]
		[Name(SquirrelPredefinedClassificationTypeNames.Documentation)]
		[BaseDefinition(PredefinedClassificationTypeNames.String)]
		internal static ClassificationTypeDefinition DocumentationClassificationDefinition = null; // Set via MEF

		[Export]
		[Name(SquirrelPredefinedClassificationTypeNames.RegularExpression)]
		[BaseDefinition(PredefinedClassificationTypeNames.String)]
		internal static ClassificationTypeDefinition RegularExpressionClassificationDefinition = null; // Set via MEF

#pragma warning restore 169
	}
}
