using SeraphSecure.FlaUI.Core;
using SeraphSecure.FlaUI.Core.Identifiers;
using SeraphSecure.FlaUI.Core.Patterns;
using SeraphSecure.FlaUI.Core.Patterns.Infrastructure;
using SeraphSecure.FlaUI.Core.Tools;
using SeraphSecure.FlaUI.UIA3.Identifiers;
using UIA = Interop.UIAutomationClient;

namespace SeraphSecure.FlaUI.UIA3.Patterns
{
    public class ScrollItemPattern : PatternBase<UIA.IUIAutomationScrollItemPattern>, IScrollItemPattern
    {
        public static readonly PatternId Pattern = PatternId.Register(AutomationType.UIA3, UIA.UIA_PatternIds.UIA_ScrollItemPatternId, "ScrollItem", AutomationObjectIds.IsScrollItemPatternAvailableProperty);

        public ScrollItemPattern(FrameworkAutomationElementBase frameworkAutomationElement, UIA.IUIAutomationScrollItemPattern nativePattern) : base(frameworkAutomationElement, nativePattern)
        {
        }

        public void ScrollIntoView()
        {
            Com.Call(() => NativePattern.ScrollIntoView());
        }
    }
}
