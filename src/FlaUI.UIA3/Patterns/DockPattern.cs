using SeraphSecure.FlaUI.Core;
using SeraphSecure.FlaUI.Core.Definitions;
using SeraphSecure.FlaUI.Core.Identifiers;
using SeraphSecure.FlaUI.Core.Patterns;
using SeraphSecure.FlaUI.Core.Tools;
using SeraphSecure.FlaUI.UIA3.Identifiers;
using UIA = Interop.UIAutomationClient;

namespace SeraphSecure.FlaUI.UIA3.Patterns
{
    public class DockPattern : DockPatternBase<UIA.IUIAutomationDockPattern>
    {
        public static readonly PatternId Pattern = PatternId.Register(AutomationType.UIA3, UIA.UIA_PatternIds.UIA_DockPatternId, "Dock", AutomationObjectIds.IsDockPatternAvailableProperty);
        public static readonly PropertyId DockPositionProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_DockDockPositionPropertyId, "DockPosition");

        public DockPattern(FrameworkAutomationElementBase frameworkAutomationElement, UIA.IUIAutomationDockPattern nativePattern) : base(frameworkAutomationElement, nativePattern)
        {
        }

        public override void SetDockPosition(DockPosition dockPos)
        {
            Com.Call(() => NativePattern.SetDockPosition((UIA.DockPosition)dockPos));
        }
    }

    public class DockPatternPropertyIds : IDockPatternPropertyIds
    {
        public PropertyId DockPosition => DockPattern.DockPositionProperty;
    }
}
