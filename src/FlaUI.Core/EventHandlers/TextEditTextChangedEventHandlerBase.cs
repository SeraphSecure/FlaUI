using System;
using SeraphSecure.FlaUI.Core.AutomationElements;
using SeraphSecure.FlaUI.Core.Definitions;

namespace SeraphSecure.FlaUI.Core.EventHandlers
{
    /// <summary>
    /// ase event handler for text edit text changed event handlers.
    /// </summary>
    public abstract class TextEditTextChangedEventHandlerBase : ElementEventHandlerBase
    {
        private readonly Action<AutomationElement, TextEditChangeType, string[]> _callAction;

        protected TextEditTextChangedEventHandlerBase(FrameworkAutomationElementBase frameworkElement, Action<AutomationElement, TextEditChangeType, string[]> callAction) : base(frameworkElement)
        {
            _callAction = callAction;
        }

        protected void HandleTextEditTextChangedEvent(AutomationElement sender, TextEditChangeType textEditChangeType, string[] eventStrings)
        {
            _callAction(sender, textEditChangeType, eventStrings);
        }

        /// <inheritdoc />
        protected override void UnregisterEventHandler()
        {
            FrameworkElement.UnregisterTextEditTextChangedEventHandler(this);
        }
    }
}
