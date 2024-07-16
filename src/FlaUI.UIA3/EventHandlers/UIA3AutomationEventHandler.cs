using System;
using SeraphSecure.FlaUI.Core;
using SeraphSecure.FlaUI.Core.AutomationElements;
using SeraphSecure.FlaUI.Core.EventHandlers;
using SeraphSecure.FlaUI.Core.Identifiers;
using UIA = Interop.UIAutomationClient;

namespace SeraphSecure.FlaUI.UIA3.EventHandlers
{
    public class UIA3AutomationEventHandler : AutomationEventHandlerBase, UIA.IUIAutomationEventHandler
    {
        public UIA3AutomationEventHandler(FrameworkAutomationElementBase frameworkElement, EventId @event, Action<AutomationElement, EventId> callAction) : base(frameworkElement, @event, callAction)
        {
        }

        public void HandleAutomationEvent(UIA.IUIAutomationElement sender, int eventId)
        {
            var frameworkElement = new UIA3FrameworkAutomationElement((UIA3Automation)Automation, sender);
            var senderElement = new AutomationElement(frameworkElement);
            var @event = EventId.Find(AutomationType.UIA3, eventId);
            HandleAutomationEvent(senderElement, @event);
        }
    }
}
