using System.ComponentModel.Composition;
using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Utilities;

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
		[Name("Squirrel.removed")]
		[BaseDefinition("Squirrel")]
		internal static ClassificationTypeDefinition diffRemovedDefinition = null;

		[Export]
		[Name("Squirrel.changed")]
		[BaseDefinition("Squirrel")]
		internal static ClassificationTypeDefinition diffChangedDefinition = null;

		[Export]
		[Name("Squirrel.infoline")]
		[BaseDefinition("Squirrel")]
		internal static ClassificationTypeDefinition diffInfolineDefinition = null;

		[Export]
		[Name("Squirrel.patchline")]
		[BaseDefinition("Squirrel")]
		internal static ClassificationTypeDefinition diffPatchLineDefinition = null;

		[Export]
		[Name("Squirrel.header")]
		[BaseDefinition("Squirrel")]
		internal static ClassificationTypeDefinition diffHeaderDefinition = null;

#pragma warning restore 169
	}
}
