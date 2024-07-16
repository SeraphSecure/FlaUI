using SeraphSecure.FlaUI.Core;
using SeraphSecure.FlaUI.Core.Identifiers;
using SeraphSecure.FlaUI.Core.Patterns;
using SeraphSecure.FlaUI.Core.Patterns.Infrastructure;
using SeraphSecure.FlaUI.Core.Tools;
using SeraphSecure.FlaUI.UIA3.Identifiers;
using UIA = Interop.UIAutomationClient;

namespace SeraphSecure.FlaUI.UIA3.Patterns
{
    public class ObjectModelPattern : PatternBase<UIA.IUIAutomationObjectModelPattern>, IObjectModelPattern
    {
        public static readonly PatternId Pattern = PatternId.Register(AutomationType.UIA3, UIA.UIA_PatternIds.UIA_ObjectModelPatternId, "ObjectModel", AutomationObjectIds.IsObjectModelPatternAvailableProperty);

        public ObjectModelPattern(FrameworkAutomationElementBase frameworkAutomationElement, UIA.IUIAutomationObjectModelPattern nativePattern) : base(frameworkAutomationElement, nativePattern)
        {
        }

        public object GetUnderlyingObjectModel()
        {
            return Com.Call(() => NativePattern.GetUnderlyingObjectModel());
        }
    }
}
