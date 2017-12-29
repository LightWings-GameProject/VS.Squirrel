using System.ComponentModel.Composition;
using Microsoft.VisualStudio.Text.Classification;

using System.Windows;
using System.Windows.Shapes;
using System.Windows.Media;
using System.Windows.Controls;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Editor;
using Microsoft.VisualStudio.Text.Formatting;
using Microsoft.VisualStudio.Text.Tagging;
using Microsoft.VisualStudio.Utilities;

namespace Squirrel.ClassificationDefinitions
{
	internal static class FileAndContentTypeDefinitions
	{
		[Export]
		[Name(SquirrelConstants.LanguageName)]
		[BaseDefinition("code")]
		internal static ContentTypeDefinition squirrelContentTypeDefinition;

		[Export]
		[FileExtension(SquirrelConstants.FileExtension)]
		[ContentType(SquirrelConstants.LanguageName)]
		internal static FileExtensionToContentTypeDefinition squirrelFileExtensionDefinition;
	}
}
