using System.Drawing;
using SeraphSecure.FlaUI.Core.AutomationElements;
using SeraphSecure.FlaUI.Core.Definitions;
using SeraphSecure.FlaUI.Core.Identifiers;
using SeraphSecure.FlaUI.Core.Patterns.Infrastructure;

namespace SeraphSecure.FlaUI.Core.Patterns
{
    public interface ITextPattern : IPattern
    {
        ITextPatternEventIds EventIds { get; }

        ITextRange DocumentRange { get; }
        SupportedTextSelection SupportedTextSelection { get; }

        ITextRange[] GetSelection();
        ITextRange[] GetVisibleRanges();
        ITextRange RangeFromChild(AutomationElement child);
        ITextRange RangeFromPoint(Point point);
    }

    public interface ITextPatternEventIds
    {
        EventId TextChangedEvent { get; }
        EventId TextSelectionChangedEvent { get; }
    }

    public abstract class TextPatternBase<TNativePattern> : PatternBase<TNativePattern>, ITextPattern
        where TNativePattern : class
    {
        protected TextPatternBase(FrameworkAutomationElementBase frameworkAutomationElement, TNativePattern nativePattern) : base(frameworkAutomationElement, nativePattern)
        {
        }

        public ITextPatternEventIds EventIds => Automation.EventLibrary.Text;

        public abstract ITextRange DocumentRange { get; }
        public abstract SupportedTextSelection SupportedTextSelection { get; }

        public abstract ITextRange[] GetSelection();
        public abstract ITextRange[] GetVisibleRanges();
        public abstract ITextRange RangeFromChild(AutomationElement child);
        public abstract ITextRange RangeFromPoint(Point point);
    }
}
