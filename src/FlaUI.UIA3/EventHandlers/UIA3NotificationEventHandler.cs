using System;
using SeraphSecure.FlaUI.Core;
using SeraphSecure.FlaUI.Core.AutomationElements;
using SeraphSecure.FlaUI.Core.Definitions;
using SeraphSecure.FlaUI.Core.EventHandlers;
using UIA = Interop.UIAutomationClient;

namespace SeraphSecure.FlaUI.UIA3.EventHandlers
{
    public class UIA3NotificationEventHandler : NotificationEventHandlerBase, UIA.IUIAutomationNotificationEventHandler
    {
        public UIA3NotificationEventHandler(FrameworkAutomationElementBase frameworkElement, Action<AutomationElement, NotificationKind, NotificationProcessing, string, string> callAction) : base(frameworkElement, callAction)
        {
        }

        public void HandleNotificationEvent(UIA.IUIAutomationElement sender, UIA.NotificationKind notificationKind,
            UIA.NotificationProcessing notificationProcessing, string displayString, string activityId)
        {
            var frameworkElement = new UIA3FrameworkAutomationElement((UIA3Automation)Automation, sender);
            var senderElement = new AutomationElement(frameworkElement);
            HandleNotificationEvent(senderElement, (NotificationKind)notificationKind, (NotificationProcessing)notificationProcessing, displayString, activityId);
        }
    }
}
