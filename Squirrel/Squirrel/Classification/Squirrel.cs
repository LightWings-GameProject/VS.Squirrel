using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.Language.StandardClassification;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Classification;

namespace Squirrel
{
	/// <summary>
	/// Classifier that classifies all text as an instance of the "Squirrel" classification type.
	/// </summary>
	internal class Squirrel : IClassifier
	{
		/// <summary>
		/// Classification type.
		/// </summary>
		private readonly Dictionary<string, IClassificationType> categoryMap;
		private readonly string[] keywords =
		{
			"class",
			"extends",
			"constructor",
			"function",
			"if",
			"else",
			"local",
			"switch",
			"case",
			"default",
			"break",
		};

		/// <summary>
		/// Initializes a new instance of the <see cref="Squirrel"/> class.
		/// </summary>
		/// <param name="registry">Classification registry.</param>
		internal Squirrel(IClassificationTypeRegistryService registry)
		{
			categoryMap = new Dictionary<string, IClassificationType>();
			categoryMap[SquirrelPredefinedClassificationTypeNames.Class] = registry.GetClassificationType(SquirrelPredefinedClassificationTypeNames.Class);
			categoryMap[SquirrelPredefinedClassificationTypeNames.Parameter] = registry.GetClassificationType(SquirrelPredefinedClassificationTypeNames.Parameter);
			categoryMap[SquirrelPredefinedClassificationTypeNames.Module] = registry.GetClassificationType(SquirrelPredefinedClassificationTypeNames.Module);
			categoryMap[SquirrelPredefinedClassificationTypeNames.Function] = registry.GetClassificationType(SquirrelPredefinedClassificationTypeNames.Function);
			categoryMap[SquirrelPredefinedClassificationTypeNames.Documentation] = registry.GetClassificationType(SquirrelPredefinedClassificationTypeNames.Documentation);
			categoryMap[SquirrelPredefinedClassificationTypeNames.RegularExpression] = registry.GetClassificationType(SquirrelPredefinedClassificationTypeNames.RegularExpression);
			// Include keyword for context-sensitive keywords
			categoryMap[PredefinedClassificationTypeNames.Keyword] = registry.GetClassificationType(PredefinedClassificationTypeNames.Keyword);
		}

		#region IClassifier

#pragma warning disable 67

		/// <summary>
		/// An event that occurs when the classification of a span of text has changed.
		/// </summary>
		/// <remarks>
		/// This event gets raised if a non-text change would affect the classification in some way,
		/// for example typing /* would cause the classification to change in C# without directly
		/// affecting the span.
		/// </remarks>
		public event EventHandler<ClassificationChangedEventArgs> ClassificationChanged;
		
#pragma warning restore 67

		/// <summary>
		/// Gets all the <see cref="ClassificationSpan"/> objects that intersect with the given range of text.
		/// </summary>
		/// <remarks>
		/// This method scans the given SnapshotSpan for potential matches for this classification.
		/// In this instance, it classifies everything and returns each span as a new ClassificationSpan.
		/// </remarks>
		/// <param name="span">The span currently being classified.</param>
		/// <returns>A list of ClassificationSpans that represent spans identified to be of this classification.</returns>
		public IList<ClassificationSpan> GetClassificationSpans(SnapshotSpan span)
		{
			var result = new List<ClassificationSpan>();
			result.AddRange(GetKeywordList(span));
			result.AddRange(GetCommentList(span));

			return result;
		}

		private List<ClassificationSpan> GetKeywordList(SnapshotSpan span)
		{
			var result = new List<ClassificationSpan>();
			var text = span.GetText();
			foreach(var keyword in keywords)
			{
				var index = text.IndexOf(keyword);
				if (index >= 0)
				{
					var start = span.Start.Position + index;

					var snapshotSpan = new SnapshotSpan(span.Snapshot, new Span(start, keyword.Length));
					var classificationSpan = new ClassificationSpan(snapshotSpan, categoryMap[PredefinedClassificationTypeNames.Keyword]);
					result.Add(classificationSpan);
				}
			}
			return result;
		}

		private List<ClassificationSpan> GetCommentList(SnapshotSpan span)
		{
			var result = new List<ClassificationSpan>();

			var text = span.GetText();
			var index = text.IndexOf("//");
			if (index >= 0)
			{
				var commentStart = span.Start.Position + index;
				var commentLength = span.Length - index;

				var snapshotSpan = new SnapshotSpan(span.Snapshot, new Span(commentStart, commentLength));
				var classificationSpan = new ClassificationSpan(snapshotSpan, categoryMap[SquirrelPredefinedClassificationTypeNames.Documentation]);
				result.Add(classificationSpan);
			}

			return result;
		}

		#endregion
	}
}
