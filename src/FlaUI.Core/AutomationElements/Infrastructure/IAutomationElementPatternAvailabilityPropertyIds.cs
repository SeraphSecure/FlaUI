﻿using SeraphSecure.FlaUI.Core.Identifiers;

namespace SeraphSecure.FlaUI.Core.AutomationElements.Infrastructure
{
    /// <summary>
    /// Interface for a class that contains all automation element pattern availability property ids.
    /// </summary>
    public interface IAutomationElementPatternAvailabilityPropertyIds
    {
#pragma warning disable 1591
        PropertyId IsAnnotationPatternAvailable { get; }
        PropertyId IsDockPatternAvailable { get; }
        PropertyId IsDragPatternAvailable { get; }
        PropertyId IsDropTargetPatternAvailable { get; }
        PropertyId IsExpandCollapsePatternAvailable { get; }
        PropertyId IsGridItemPatternAvailable { get; }
        PropertyId IsGridPatternAvailable { get; }
        PropertyId IsInvokePatternAvailable { get; }
        PropertyId IsItemContainerPatternAvailable { get; }
        PropertyId IsLegacyIAccessiblePatternAvailable { get; }
        PropertyId IsMultipleViewPatternAvailable { get; }
        PropertyId IsObjectModelPatternAvailable { get; }
        PropertyId IsRangeValuePatternAvailable { get; }
        PropertyId IsScrollItemPatternAvailable { get; }
        PropertyId IsScrollPatternAvailable { get; }
        PropertyId IsSelectionItemPatternAvailable { get; }
        PropertyId IsSelection2PatternAvailable { get; }
        PropertyId IsSelectionPatternAvailable { get; }
        PropertyId IsSpreadsheetPatternAvailable { get; }
        PropertyId IsSpreadsheetItemPatternAvailable { get; }
        PropertyId IsStylesPatternAvailable { get; }
        PropertyId IsSynchronizedInputPatternAvailable { get; }
        PropertyId IsTableItemPatternAvailable { get; }
        PropertyId IsTablePatternAvailable { get; }
        PropertyId IsTextChildPatternAvailable { get; }
        PropertyId IsTextEditPatternAvailable { get; }
        PropertyId IsTextPatternAvailable { get; }
        PropertyId IsTextPattern2Available { get; }
        PropertyId IsTogglePatternAvailable { get; }
        PropertyId IsTransformPatternAvailable { get; }
        PropertyId IsTransformPattern2Available { get; }
        PropertyId IsValuePatternAvailable { get; }
        PropertyId IsVirtualizedItemPatternAvailable { get; }
        PropertyId IsWindowPatternAvailable { get; }

        PropertyId[] AllForCurrentFramework { get; }
#pragma warning restore 1591
    }
}
