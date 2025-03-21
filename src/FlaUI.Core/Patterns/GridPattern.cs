﻿using SeraphSecure.FlaUI.Core.AutomationElements;
using SeraphSecure.FlaUI.Core.Identifiers;
using SeraphSecure.FlaUI.Core.Patterns.Infrastructure;

namespace SeraphSecure.FlaUI.Core.Patterns
{
    public interface IGridPattern : IPattern
    {
        IGridPatternPropertyIds PropertyIds { get; }

        AutomationProperty<int> ColumnCount { get; }
        AutomationProperty<int> RowCount { get; }

        AutomationElement GetItem(int row, int column);
    }

    public interface IGridPatternPropertyIds
    {
        PropertyId ColumnCount { get; }
        PropertyId RowCount { get; }
    }

    public abstract class GridPatternBase<TNativePattern> : PatternBase<TNativePattern>, IGridPattern
        where TNativePattern : class
    {
        private AutomationProperty<int>? _columnCount;
        private AutomationProperty<int>? _rowCount;

        protected GridPatternBase(FrameworkAutomationElementBase frameworkAutomationElement, TNativePattern nativePattern) : base(frameworkAutomationElement, nativePattern)
        {
        }

        public IGridPatternPropertyIds PropertyIds => Automation.PropertyLibrary.Grid;

        public AutomationProperty<int> ColumnCount => GetOrCreate(ref _columnCount, PropertyIds.ColumnCount);
        public AutomationProperty<int> RowCount => GetOrCreate(ref _rowCount, PropertyIds.RowCount);

        public abstract AutomationElement GetItem(int row, int column);
    }
}
