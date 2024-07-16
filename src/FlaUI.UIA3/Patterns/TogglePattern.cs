using SeraphSecure.FlaUI.Core;
using SeraphSecure.FlaUI.Core.Identifiers;
using SeraphSecure.FlaUI.Core.Patterns;
using SeraphSecure.FlaUI.Core.Tools;
using SeraphSecure.FlaUI.UIA3.Identifiers;
using UIA = Interop.UIAutomationClient;

namespace SeraphSecure.FlaUI.UIA3.Patterns
{
    public class TogglePattern : TogglePatternBase<UIA.IUIAutomationTogglePattern>
    {
        public static readonly PatternId Pattern = PatternId.Register(AutomationType.UIA3, UIA.UIA_PatternIds.UIA_TogglePatternId, "Toggle", AutomationObjectIds.IsTogglePatternAvailableProperty);
        public static readonly PropertyId ToggleStateProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_ToggleToggleStatePropertyId, "ToggleState");

        public TogglePattern(FrameworkAutomationElementBase frameworkAutomationElement, UIA.IUIAutomationTogglePattern nativePattern) : base(frameworkAutomationElement, nativePattern)
        {
        }

        public override void Toggle()
        {
            Com.Call(() => NativePattern.Toggle());
        }
    }

    public class TogglePatternPropertyIds : ITogglePatternPropertyIds
    {
        public PropertyId ToggleState => TogglePattern.ToggleStateProperty;
    }
}
