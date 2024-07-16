using System;
using SeraphSecure.FlaUI.Core;
using SeraphSecure.FlaUI.Core.AutomationElements;
using SeraphSecure.FlaUI.Core.EventHandlers;
using UIA = Interop.UIAutomationClient;

namespace SeraphSecure.FlaUI.UIA3.EventHandlers
{
    /// <summary>
    /// UIA2 implementation of a focus changed event handler.
    /// </summary>
    public class UIA3FocusChangedEventHandler : FocusChangedEventHandlerBase, UIA.IUIAutomationFocusChangedEventHandler
    {
        public UIA3FocusChangedEventHandler(AutomationBase automation, Action<AutomationElement> callAction) : base(automation, callAction)
        {
        }

        public void HandleFocusChangedEvent(UIA.IUIAutomationElement sender)
        {
            var frameworkElement = new UIA3FrameworkAutomationElement((UIA3Automation)Automation, sender);
            var senderElement = new AutomationElement(frameworkElement);
            HandleFocusChangedEvent(senderElement);
        }
    }
}
