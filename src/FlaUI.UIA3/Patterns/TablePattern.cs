﻿using SeraphSecure.FlaUI.Core;
using SeraphSecure.FlaUI.Core.Identifiers;
using SeraphSecure.FlaUI.Core.Patterns;
using SeraphSecure.FlaUI.UIA3.Converters;
using SeraphSecure.FlaUI.UIA3.Identifiers;
using UIA = Interop.UIAutomationClient;

namespace SeraphSecure.FlaUI.UIA3.Patterns
{
    public class TablePattern : TablePatternBase<UIA.IUIAutomationTablePattern>
    {
        public static readonly PatternId Pattern = PatternId.Register(AutomationType.UIA3, UIA.UIA_PatternIds.UIA_TablePatternId, "Table", AutomationObjectIds.IsTablePatternAvailableProperty);
        public static readonly PropertyId ColumnHeadersProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_TableColumnHeadersPropertyId, "ColumnHeaders").SetConverter(AutomationElementConverter.NativeArrayToManaged);
        public static readonly PropertyId RowHeadersProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_TableRowHeadersPropertyId, "RowHeaders").SetConverter(AutomationElementConverter.NativeArrayToManaged);
        public static readonly PropertyId RowOrColumnMajorProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_TableRowOrColumnMajorPropertyId, "RowOrColumnMajor");

        public TablePattern(FrameworkAutomationElementBase frameworkAutomationElement, UIA.IUIAutomationTablePattern nativePattern) : base(frameworkAutomationElement, nativePattern)
        {
        }
    }

    public class TablePatternPropertyIds : ITablePatternPropertyIds
    {
        public PropertyId ColumnHeaders => TablePattern.ColumnHeadersProperty;
        public PropertyId RowHeaders => TablePattern.RowHeadersProperty;
        public PropertyId RowOrColumnMajor => TablePattern.RowOrColumnMajorProperty;
    }
}
