using SeraphSecure.FlaUI.Core.Definitions;
using SeraphSecure.FlaUI.Core.Identifiers;
using SeraphSecure.FlaUI.Core.Patterns.Infrastructure;

namespace SeraphSecure.FlaUI.Core.Patterns
{
    public interface IDockPattern : IPattern
    {
        IDockPatternPropertyIds PropertyIds { get; }

        AutomationProperty<DockPosition> DockPosition { get; }

        void SetDockPosition(DockPosition dockPos);
    }

    public interface IDockPatternPropertyIds
    {
        PropertyId DockPosition { get; }
    }

    public abstract class DockPatternBase<TNativePattern> : PatternBase<TNativePattern>, IDockPattern
        where TNativePattern : class
    {
        private AutomationProperty<DockPosition> _dockPosition;

        protected DockPatternBase(FrameworkAutomationElementBase frameworkAutomationElement, TNativePattern nativePattern) : base(frameworkAutomationElement, nativePattern)
        {
        }

        public IDockPatternPropertyIds PropertyIds => Automation.PropertyLibrary.Dock;

        public AutomationProperty<DockPosition> DockPosition => GetOrCreate(ref _dockPosition, PropertyIds.DockPosition);

        public abstract void SetDockPosition(DockPosition dockPos);
    }
}
