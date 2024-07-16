using System;
using SeraphSecure.FlaUI.Core.AutomationElements;
using SeraphSecure.FlaUI.Core.Identifiers;

namespace SeraphSecure.FlaUI.Core.EventHandlers
{
    public abstract class AutomationEventHandlerBase : ElementEventHandlerBase
    {
        private readonly Action<AutomationElement, EventId> _callAction;

        protected AutomationEventHandlerBase(FrameworkAutomationElementBase frameworkElement, EventId @event, Action<AutomationElement, EventId> callAction)
            : base(frameworkElement)
        {
            Event = @event;
            _callAction = callAction;
        }

        public EventId Event { get; }

        protected void HandleAutomationEvent(AutomationElement sender, EventId eventId)
        {
            _callAction(sender, eventId);
        }

        /// <inheritdoc />
        protected override void UnregisterEventHandler()
        {
            FrameworkElement.UnregisterAutomationEventHandler(this);
        }
    }
}
