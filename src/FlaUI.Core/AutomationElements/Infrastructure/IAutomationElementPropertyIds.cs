﻿using SeraphSecure.FlaUI.Core.Identifiers;

namespace SeraphSecure.FlaUI.Core.AutomationElements.Infrastructure
{
    /// <summary>
    /// Interface for a class that contains all automation element property ids.
    /// </summary>
    public interface IAutomationElementPropertyIds
    {
#pragma warning disable 1591
        PropertyId AcceleratorKey { get; }
        PropertyId AccessKey { get; }
        PropertyId AnnotationObjects { get; }
        PropertyId AnnotationTypes { get; }
        PropertyId AriaProperties { get; }
        PropertyId AriaRole { get; }
        PropertyId AutomationId { get; }
        PropertyId BoundingRectangle { get; }
        PropertyId CenterPoint { get; }
        PropertyId ClassName { get; }
        PropertyId ClickablePoint { get; }
        PropertyId ControllerFor { get; }
        PropertyId ControlType { get; }
        PropertyId Culture { get; }
        PropertyId DescribedBy { get; }
        PropertyId FillColor { get; }
        PropertyId FillType { get; }
        PropertyId FlowsFrom { get; }
        PropertyId FlowsTo { get; }
        PropertyId FrameworkId { get; }
        PropertyId FullDescription { get; }
        PropertyId HasKeyboardFocus { get; }
        PropertyId HeadingLevel { get; }
        PropertyId HelpText { get; }
        PropertyId IsContentElement { get; }
        PropertyId IsControlElement { get; }
        PropertyId IsDataValidForForm { get; }
        PropertyId IsDialog { get; }
        PropertyId IsEnabled { get; }
        PropertyId IsKeyboardFocusable { get; }
        PropertyId IsOffscreen { get; }
        PropertyId IsPassword { get; }
        PropertyId IsPeripheral { get; }
        PropertyId IsRequiredForForm { get; }
        PropertyId ItemStatus { get; }
        PropertyId ItemType { get; }
        PropertyId LabeledBy { get; }
        PropertyId LandmarkType { get; }
        PropertyId Level { get; }
        PropertyId LiveSetting { get; }
        PropertyId LocalizedControlType { get; }
        PropertyId LocalizedLandmarkType { get; }
        PropertyId Name { get; }
        PropertyId NativeWindowHandle { get; }
        PropertyId OptimizeForVisualContent { get; }
        PropertyId Orientation { get; }
        PropertyId OutlineColor { get; }
        PropertyId OutlineThickness { get; }
        PropertyId PositionInSet { get; }
        PropertyId ProcessId { get; }
        PropertyId ProviderDescription { get; }
        PropertyId Rotation { get; }
        PropertyId RuntimeId { get; }
        PropertyId Size { get; }
        PropertyId SizeOfSet { get; }
        PropertyId VisualEffects { get; }
#pragma warning restore 1591
    }
}
