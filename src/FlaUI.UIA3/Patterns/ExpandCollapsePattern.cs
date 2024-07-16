﻿using SeraphSecure.FlaUI.Core;
using SeraphSecure.FlaUI.Core.Identifiers;
using SeraphSecure.FlaUI.Core.Patterns;
using SeraphSecure.FlaUI.Core.Tools;
using SeraphSecure.FlaUI.UIA3.Identifiers;
using UIA = Interop.UIAutomationClient;

namespace SeraphSecure.FlaUI.UIA3.Patterns
{
    public class ExpandCollapsePattern : ExpandCollapsePatternBase<UIA.IUIAutomationExpandCollapsePattern>
    {
        public static readonly PatternId Pattern = PatternId.Register(AutomationType.UIA3, UIA.UIA_PatternIds.UIA_ExpandCollapsePatternId, "ExpandCollapse", AutomationObjectIds.IsExpandCollapsePatternAvailableProperty);
        public static readonly PropertyId ExpandCollapseStateProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_ExpandCollapseExpandCollapseStatePropertyId, "ExpandCollapseState");

        public ExpandCollapsePattern(FrameworkAutomationElementBase frameworkAutomationElement, UIA.IUIAutomationExpandCollapsePattern nativePattern) : base(frameworkAutomationElement, nativePattern)
        {
        }

        public override void Collapse()
        {
            Com.Call(() => NativePattern.Collapse());
        }

        public override void Expand()
        {
            Com.Call(() => NativePattern.Expand());
        }
    }

    public class ExpandCollapsePatternPropertyIds : IExpandCollapsePatternPropertyIds
    {
        public PropertyId ExpandCollapseState => ExpandCollapsePattern.ExpandCollapseStateProperty;
    }
}
