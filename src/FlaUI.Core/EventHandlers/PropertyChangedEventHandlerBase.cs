using System;
using SeraphSecure.FlaUI.Core.AutomationElements;
using SeraphSecure.FlaUI.Core.Identifiers;

namespace SeraphSecure.FlaUI.Core.EventHandlers
{
    /// <summary>
    /// Base event handler for property changed event handlers.
    /// </summary>
    public abstract class PropertyChangedEventHandlerBase : ElementEventHandlerBase
    {
        private readonly Action<AutomationElement, PropertyId, object> _callAction;

        protected PropertyChangedEventHandlerBase(FrameworkAutomationElementBase frameworkElement, Action<AutomationElement, PropertyId, object> callAction)
            : base(frameworkElement)
        {
            _callAction = callAction;
        }

        protected void HandlePropertyChangedEvent(AutomationElement sender, PropertyId propertyId, object newValue)
        {
            _callAction(sender, propertyId, newValue);
        }

        /// <inheritdoc />
        protected override void UnregisterEventHandler()
        {
            FrameworkElement.UnregisterPropertyChangedEventHandler(this);
        }
    }
}
