using System.ComponentModel.Composition;
using System.Windows.Media;
using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Utilities;

namespace Squirrel
{
	/// <summary>
	/// Defines an editor format for the Squirrel type that has a purple background
	/// and is underlined.
	/// </summary>
	[Export(typeof(EditorFormatDefinition))]
	[ClassificationType(ClassificationTypeNames = "Squirrel")]
	[Name("Squirrel")]
	[DisplayName("Squirrel")]
	[UserVisible(true)] // This should be visible to the end user
	[Order(Before = Priority.Default)] // Set the priority to be after the default classifiers
	internal sealed class SquirrelFormat : ClassificationFormatDefinition
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="SquirrelFormat"/> class.
		/// </summary>
		public SquirrelFormat()
		{
			//this.DisplayName = "Squirrel"; // Human readable version of the name
			this.BackgroundColor = Colors.BlueViolet;
			this.TextDecorations = System.Windows.TextDecorations.Underline;
		}
	}



	[Export(typeof(EditorFormatDefinition))]
	[ClassificationType(ClassificationTypeNames = "Squirrel.added")]
	[Name("Squirrel.added")]
	internal sealed class DiffAddedFormat : ClassificationFormatDefinition
	{
		public DiffAddedFormat()
		{
			ForegroundColor = Colors.Blue;
		}
	}

	[Export(typeof(EditorFormatDefinition))]
	[ClassificationType(ClassificationTypeNames = "Squirrel.removed")]
	[Name("Squirrel.removed")]
	internal sealed class DiffRemovedFormat : ClassificationFormatDefinition
	{
		public DiffRemovedFormat()
		{
			ForegroundColor = Colors.Red;
		}
	}

	[Export(typeof(EditorFormatDefinition))]
	[ClassificationType(ClassificationTypeNames = "Squirrel.changed")]
	[Name("Squirrel.changed")]
	internal sealed class DiffChangedFormat : ClassificationFormatDefinition
	{
		public DiffChangedFormat()
		{
			ForegroundColor = Color.FromRgb(0xCC, 0x60, 0x10);
		}
	}

	[Export(typeof(EditorFormatDefinition))]
	[ClassificationType(ClassificationTypeNames = "Squirrel.infoline")]
	[Name("Squirrel.infoline")]
	internal sealed class DiffInfolineFormat : ClassificationFormatDefinition
	{
		public DiffInfolineFormat()
		{
			ForegroundColor = Color.FromRgb(0x44, 0xBB, 0xBB);
		}
	}

	[Export(typeof(EditorFormatDefinition))]
	[ClassificationType(ClassificationTypeNames = "Squirrel.patchline")]
	[Name("Squirrel.patchline")]
	internal sealed class DiffPatchLineFormat : ClassificationFormatDefinition
	{
		public DiffPatchLineFormat()
		{
			ForegroundColor = Colors.Goldenrod;
		}
	}

	[Export(typeof(EditorFormatDefinition))]
	[ClassificationType(ClassificationTypeNames = "Squirrel.header")]
	[Name("Squirrel.header")]
	internal sealed class DiffHeaderFormat : ClassificationFormatDefinition
	{
		public DiffHeaderFormat()
		{
			ForegroundColor = Color.FromRgb(0, 0xBB, 0);
		}
	}
}
