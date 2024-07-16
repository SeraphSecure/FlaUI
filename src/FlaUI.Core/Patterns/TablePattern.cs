using SeraphSecure.FlaUI.Core.AutomationElements;
using SeraphSecure.FlaUI.Core.Definitions;
using SeraphSecure.FlaUI.Core.Identifiers;
using SeraphSecure.FlaUI.Core.Patterns.Infrastructure;

namespace SeraphSecure.FlaUI.Core.Patterns
{
    public interface ITablePattern : IPattern
    {
        ITablePatternPropertyIds PropertyIds { get; }

        AutomationProperty<AutomationElement[]> ColumnHeaders { get; }
        AutomationProperty<AutomationElement[]> RowHeaders { get; }
        AutomationProperty<RowOrColumnMajor> RowOrColumnMajor { get; }
    }

    public interface ITablePatternPropertyIds
    {
        PropertyId ColumnHeaders { get; }
        PropertyId RowHeaders { get; }
        PropertyId RowOrColumnMajor { get; }
    }

    public abstract class TablePatternBase<TNativePattern> : PatternBase<TNativePattern>, ITablePattern
        where TNativePattern : class
    {
        private AutomationProperty<AutomationElement[]> _columnHeaders;
        private AutomationProperty<AutomationElement[]> _rowHeaders;
        private AutomationProperty<RowOrColumnMajor> _rowOrColumnMajor;

        protected TablePatternBase(FrameworkAutomationElementBase frameworkAutomationElement, TNativePattern nativePattern) : base(frameworkAutomationElement, nativePattern)
        {
        }

        public ITablePatternPropertyIds PropertyIds => Automation.PropertyLibrary.Table;

        public AutomationProperty<AutomationElement[]> ColumnHeaders => GetOrCreate(ref _columnHeaders, PropertyIds.ColumnHeaders);
        public AutomationProperty<AutomationElement[]> RowHeaders => GetOrCreate(ref _rowHeaders, PropertyIds.RowHeaders);
        public AutomationProperty<RowOrColumnMajor> RowOrColumnMajor => GetOrCreate(ref _rowOrColumnMajor, PropertyIds.RowOrColumnMajor);
    }
}
