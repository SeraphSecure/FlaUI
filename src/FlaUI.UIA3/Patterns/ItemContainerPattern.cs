using SeraphSecure.FlaUI.Core;
using SeraphSecure.FlaUI.Core.AutomationElements;
using SeraphSecure.FlaUI.Core.Identifiers;
using SeraphSecure.FlaUI.Core.Patterns;
using SeraphSecure.FlaUI.Core.Patterns.Infrastructure;
using SeraphSecure.FlaUI.Core.Tools;
using SeraphSecure.FlaUI.UIA3.Converters;
using SeraphSecure.FlaUI.UIA3.Identifiers;
using UIA = Interop.UIAutomationClient;

namespace SeraphSecure.FlaUI.UIA3.Patterns
{
    public class ItemContainerPattern : PatternBase<UIA.IUIAutomationItemContainerPattern>, IItemContainerPattern
    {
        public static readonly PatternId Pattern = PatternId.Register(AutomationType.UIA3, UIA.UIA_PatternIds.UIA_ItemContainerPatternId, "ItemContainer", AutomationObjectIds.IsItemContainerPatternAvailableProperty);

        public ItemContainerPattern(FrameworkAutomationElementBase frameworkAutomationElement, UIA.IUIAutomationItemContainerPattern nativePattern) : base(frameworkAutomationElement, nativePattern)
        {
        }

        public AutomationElement FindItemByProperty(AutomationElement startAfter, PropertyId property, object value)
        {
            var foundNativeElement = Com.Call(() =>
                NativePattern.FindItemByProperty(
                    startAfter?.ToNative(),
                    property?.Id ?? 0, ValueConverter.ToNative(value)));
            return AutomationElementConverter.NativeToManaged((UIA3Automation)FrameworkAutomationElement.Automation, foundNativeElement);
        }
    }
}
