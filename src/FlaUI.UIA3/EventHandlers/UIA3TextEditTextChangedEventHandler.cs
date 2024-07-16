using System;
using SeraphSecure.FlaUI.Core;
using SeraphSecure.FlaUI.Core.AutomationElements;
using SeraphSecure.FlaUI.Core.Definitions;
using SeraphSecure.FlaUI.Core.EventHandlers;
using UIA = Interop.UIAutomationClient;

namespace SeraphSecure.FlaUI.UIA3.EventHandlers
{
    /// <summary>
    /// UIA3 implementation of a text edit text changed event handler.
    /// </summary>
    public class UIA3TextEditTextChangedEventHandler : TextEditTextChangedEventHandlerBase, UIA.IUIAutomationTextEditTextChangedEventHandler
    {
        public UIA3TextEditTextChangedEventHandler(FrameworkAutomationElementBase frameworkElement, Action<AutomationElement, TextEditChangeType, string[]> callAction) : base(frameworkElement, callAction)
        {
        }

        public void HandleTextEditTextChangedEvent(UIA.IUIAutomationElement sender, UIA.TextEditChangeType textEditChangeType, string[] eventStrings)
        {
            var frameworkElement = new UIA3FrameworkAutomationElement((UIA3Automation)Automation, sender);
            var senderElement = new AutomationElement(frameworkElement);
            HandleTextEditTextChangedEvent(senderElement, (TextEditChangeType)textEditChangeType, eventStrings);
        }
    }
}
