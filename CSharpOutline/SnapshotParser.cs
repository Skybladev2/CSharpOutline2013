using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Classification;

namespace CSharpOutline
{
    /// <summary>
    /// sequential parser for ITextSnapshot
    /// </summary>
    class SnapshotParser
    {
        private ITextSnapshot Snapshot;
        public SnapshotPoint CurrentPoint { get; private set; }
        ////public ITextSnapshotLine CurrentLine { get { return CurrentPoint.GetContainingLine(); } }
        ////classifier
        //private IClassifier Classifier;
        //private IList<ClassificationSpan> ClassificationSpans;
        ///// <summary>
        ///// A dictionary (span start => span)
        ///// </summary>
        //private Dictionary<int, ClassificationSpan> SpanIndex = new Dictionary<int, ClassificationSpan>();

        //public ClassificationSpan CurrentSpan { get; private set; }

        public SnapshotParser(ITextSnapshot snapshot, IClassifier classifier)
        {
            Snapshot = snapshot;
            //Classifier = classifier;
            //ClassificationSpans = Classifier.GetClassificationSpans(new SnapshotSpan(Snapshot, 0, snapshot.Length));
            //foreach (ClassificationSpan s in ClassificationSpans)
            //    SpanIndex.Add(s.Span.Start.Position, s);

            CurrentPoint = Snapshot.GetLineFromLineNumber(0).Start;
            //if (SpanIndex.ContainsKey(0))
            //    CurrentSpan = SpanIndex[0];
        }

        /// <summary>
        /// Moves forward by one char or one classification span
        /// </summary>
        /// <returns>true, if moved</returns>
        public bool MoveNext()
        {
            if (!AtEnd())
            {
                //CurrentPoint = CurrentSpan != null ? CurrentSpan.Span.End : CurrentPoint + 1;

                //if (SpanIndex.ContainsKey(CurrentPoint.Position))
                //    CurrentSpan = SpanIndex[CurrentPoint.Position];
                //else
                //    CurrentSpan = null;
                CurrentPoint+=1;
                return true;
            }
            return false;
        }

        public bool AtEnd()
        {
            return CurrentPoint.Position >= Snapshot.Length;
        }

        /*public string PeekString(int chars)
        {
            string currentText = CurrentLine.GetText();
            int startIndex = CurrentPoint - CurrentLine.Start;

            if (startIndex >= currentText.Length) return "";
            if (startIndex + chars < currentText.Length)
                return currentText.Substring(startIndex, chars);
            else
                return currentText.Substring(startIndex);
        }*/
    }
}
