using SeraphSecure.FlaUI.Core.Definitions;
using SeraphSecure.FlaUI.Core.Identifiers;
using SeraphSecure.FlaUI.Core.Patterns.Infrastructure;

namespace SeraphSecure.FlaUI.Core.Patterns
{
    public interface ITogglePattern : IPattern
    {
        ITogglePatternPropertyIds PropertyIds { get; }

        AutomationProperty<ToggleState> ToggleState { get; }

        void Toggle();
    }

    public interface ITogglePatternPropertyIds
    {
        PropertyId ToggleState { get; }
    }

    public abstract class TogglePatternBase<TNativePattern> : PatternBase<TNativePattern>, ITogglePattern
        where TNativePattern : class
    {
        private AutomationProperty<ToggleState> _toggleState;

        protected TogglePatternBase(FrameworkAutomationElementBase frameworkAutomationElement, TNativePattern nativePattern) : base(frameworkAutomationElement, nativePattern)
        {
        }

        public ITogglePatternPropertyIds PropertyIds => Automation.PropertyLibrary.Toggle;

        public AutomationProperty<ToggleState> ToggleState => GetOrCreate(ref _toggleState, PropertyIds.ToggleState);

        public abstract void Toggle();
    }
}
