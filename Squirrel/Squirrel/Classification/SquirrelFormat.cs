using System.ComponentModel.Composition;
using System.Windows.Media;
using Microsoft.VisualStudio.Language.StandardClassification;
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
	[ClassificationType(ClassificationTypeNames = SquirrelPredefinedClassificationTypeNames.Class)]
	[Name(SquirrelPredefinedClassificationTypeNames.Class)]
	[DisplayName(SquirrelPredefinedClassificationTypeNames.Class)]
	[UserVisible(true)]
	[Order(After = LanguagePriority.NaturalLanguage, Before = LanguagePriority.FormalLanguage)]
	internal sealed class ClassFormat : ClassificationFormatDefinition
	{
		public ClassFormat()
		{
			// Matches "C++ User Types"
			ForegroundColor = Color.FromArgb(255, 43, 145, 175);
		}
	}

	[Export(typeof(EditorFormatDefinition))]
	[ClassificationType(ClassificationTypeNames = SquirrelPredefinedClassificationTypeNames.Module)]
	[Name(SquirrelPredefinedClassificationTypeNames.Module)]
	[DisplayName(SquirrelPredefinedClassificationTypeNames.Module)]
	[UserVisible(true)]
	[Order(After = LanguagePriority.NaturalLanguage, Before = LanguagePriority.FormalLanguage)]
	internal sealed class ModuleFormat : ClassificationFormatDefinition
	{
		public ModuleFormat()
		{
			// Matches "C++ Macros"
			ForegroundColor = Color.FromArgb(255, 111, 0, 138);
		}
	}

	[Export(typeof(EditorFormatDefinition))]
	[ClassificationType(ClassificationTypeNames = SquirrelPredefinedClassificationTypeNames.Parameter)]
	[Name(SquirrelPredefinedClassificationTypeNames.Parameter)]
	[DisplayName(SquirrelPredefinedClassificationTypeNames.Parameter)]
	[UserVisible(true)]
	[Order(After = LanguagePriority.NaturalLanguage, Before = LanguagePriority.FormalLanguage)]
	internal sealed class ParameterFormat : ClassificationFormatDefinition
	{
		public ParameterFormat()
		{
			// Matches "C++ Parameters"
			ForegroundColor = Color.FromArgb(255, 128, 128, 128);
		}
	}

	[Export(typeof(EditorFormatDefinition))]
	[ClassificationType(ClassificationTypeNames = SquirrelPredefinedClassificationTypeNames.Function)]
	[Name(SquirrelPredefinedClassificationTypeNames.Function)]
	[DisplayName(SquirrelPredefinedClassificationTypeNames.Function)]
	[UserVisible(true)]
	[Order(After = LanguagePriority.NaturalLanguage, Before = LanguagePriority.FormalLanguage)]
	internal sealed class FunctionFormat : ClassificationFormatDefinition
	{
		public FunctionFormat()
		{
			// Matches "C++ Functions"
			ForegroundColor = Colors.Black;
		}
	}

	[Export(typeof(EditorFormatDefinition))]
	[ClassificationType(ClassificationTypeNames = SquirrelPredefinedClassificationTypeNames.Documentation)]
	[Name(SquirrelPredefinedClassificationTypeNames.Documentation)]
	[DisplayName(SquirrelPredefinedClassificationTypeNames.Documentation)]
	[UserVisible(true)]
	[Order(After = Priority.High)]
	internal sealed class DocumentationFormat : ClassificationFormatDefinition
	{
		public DocumentationFormat()
		{
			// Matches comment color but slightly brighter
			ForegroundColor = Color.FromArgb(0xFF, 0x00, 0x90, 0x10);
		}
	}

	[Export(typeof(EditorFormatDefinition))]
	[ClassificationType(ClassificationTypeNames = SquirrelPredefinedClassificationTypeNames.RegularExpression)]
	[Name(SquirrelPredefinedClassificationTypeNames.RegularExpression)]
	[DisplayName(SquirrelPredefinedClassificationTypeNames.RegularExpression)]
	[UserVisible(true)]
	[Order(After = Priority.High)]
	internal sealed class RegexFormat : ClassificationFormatDefinition
	{
		public RegexFormat()
		{
			// Matches existing regular expression color
			ForegroundColor = Color.FromArgb(0x00, 0x80, 0x00, 0x00);
		}
	}

}
