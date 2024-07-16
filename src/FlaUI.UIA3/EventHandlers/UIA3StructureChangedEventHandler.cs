using System;
using SeraphSecure.FlaUI.Core;
using SeraphSecure.FlaUI.Core.AutomationElements;
using SeraphSecure.FlaUI.Core.Definitions;
using SeraphSecure.FlaUI.Core.EventHandlers;
using UIA = Interop.UIAutomationClient;

namespace SeraphSecure.FlaUI.UIA3.EventHandlers
{
    /// <summary>
    /// UIA3 implementation of a structure changed event handler.
    /// </summary>
    public class UIA3StructureChangedEventHandler : StructureChangedEventHandlerBase, UIA.IUIAutomationStructureChangedEventHandler
    {
        public UIA3StructureChangedEventHandler(FrameworkAutomationElementBase frameworkElement, Action<AutomationElement, StructureChangeType, int[]> callAction) : base(frameworkElement, callAction)
        {
        }

        public void HandleStructureChangedEvent(UIA.IUIAutomationElement sender, UIA.StructureChangeType changeType, int[] runtimeId)
        {
            var frameworkElement = new UIA3FrameworkAutomationElement((UIA3Automation)Automation, sender);
            var senderElement = new AutomationElement(frameworkElement);
            HandleStructureChangedEvent(senderElement, (StructureChangeType)changeType, runtimeId);
        }
    }
}
