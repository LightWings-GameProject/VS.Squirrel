﻿////////////////////////////////////////////////////////////////////////////////
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
using System.ComponentModel.Composition;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Tagging;
using Microsoft.VisualStudio.Text.Editor;
using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Utilities;

namespace Squirrel
{
	internal class TodoTag : IGlyphTag
	{
	}

	internal class TodoTagger : ITagger<TodoTag>
	{
		private IClassifier m_classifier;
		private const string m_searchText = "todo";

		public event EventHandler<SnapshotSpanEventArgs> TagsChanged;

		internal TodoTagger(IClassifier classifier)
		{
			m_classifier = classifier;
		}

		IEnumerable<ITagSpan<TodoTag>> ITagger<TodoTag>.GetTags(NormalizedSnapshotSpanCollection spans)
		{
			foreach (SnapshotSpan span in spans)
			{
				//look at each classification span \
				foreach (ClassificationSpan classification in m_classifier.GetClassificationSpans(span))
				{
					//if the classification is a comment
					if (classification.ClassificationType.Classification.ToLower().Contains("comment"))
					{
						//if the word "todo" is in the comment,
						//create a new TodoTag TagSpan
						int index = classification.Span.GetText().ToLower().IndexOf(m_searchText);
						if (index != -1)
						{
							yield return new TagSpan<TodoTag>(new SnapshotSpan(classification.Span.Start + index, m_searchText.Length), new TodoTag());
						}
					}
				}
			}
		}
	}

	[Export(typeof(ITaggerProvider))]
	[ContentType("code")]
	[TagType(typeof(TodoTag))]
	class TodoTaggerProvider : ITaggerProvider
	{
		[Import]
		internal IClassifierAggregatorService AggregatorService;

		public ITagger<T> CreateTagger<T>(ITextBuffer buffer) where T : ITag
		{
			if (buffer == null)
			{
				throw new ArgumentNullException("buffer");
			}

			return new TodoTagger(AggregatorService.GetClassifier(buffer)) as ITagger<T>;
		}
	}
}
