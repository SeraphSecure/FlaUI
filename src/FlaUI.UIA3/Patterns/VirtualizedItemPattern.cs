using SeraphSecure.FlaUI.Core;
using SeraphSecure.FlaUI.Core.Identifiers;
using SeraphSecure.FlaUI.Core.Patterns;
using SeraphSecure.FlaUI.Core.Patterns.Infrastructure;
using SeraphSecure.FlaUI.Core.Tools;
using SeraphSecure.FlaUI.UIA3.Identifiers;
using UIA = Interop.UIAutomationClient;

namespace SeraphSecure.FlaUI.UIA3.Patterns
{
    public class VirtualizedItemPattern : PatternBase<UIA.IUIAutomationVirtualizedItemPattern>, IVirtualizedItemPattern
    {
        public static readonly PatternId Pattern = PatternId.Register(AutomationType.UIA3, UIA.UIA_PatternIds.UIA_VirtualizedItemPatternId, "VirtualizedItem", AutomationObjectIds.IsVirtualizedItemPatternAvailableProperty);

        public VirtualizedItemPattern(FrameworkAutomationElementBase frameworkAutomationElement, UIA.IUIAutomationVirtualizedItemPattern nativePattern) : base(frameworkAutomationElement, nativePattern)
        {
        }

        public void Realize()
        {
            Com.Call(() => NativePattern.Realize());
        }
    }
}
