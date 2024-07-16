using SeraphSecure.FlaUI.Core.Definitions;
using SeraphSecure.FlaUI.Core.Identifiers;
using SeraphSecure.FlaUI.Core.Patterns.Infrastructure;

namespace SeraphSecure.FlaUI.Core.Patterns
{
    public interface ISynchronizedInputPattern : IPattern
    {
        ISynchronizedInputPatternEventIds EventIds { get; }

        void Cancel();
        void StartListening(SynchronizedInputType inputType);
    }

    public interface ISynchronizedInputPatternEventIds
    {
        EventId DiscardedEvent { get; }
        EventId ReachedOtherElementEvent { get; }
        EventId ReachedTargetEvent { get; }
    }

    public abstract class SynchronizedInputPatternBase<TNativePattern> : PatternBase<TNativePattern>, ISynchronizedInputPattern
        where TNativePattern : class
    {
        protected SynchronizedInputPatternBase(FrameworkAutomationElementBase frameworkAutomationElement, TNativePattern nativePattern) : base(frameworkAutomationElement, nativePattern)
        {
        }

        public ISynchronizedInputPatternEventIds EventIds => Automation.EventLibrary.SynchronizedInput;

        public abstract void Cancel();
        public abstract void StartListening(SynchronizedInputType inputType);
    }
}
