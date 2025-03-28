﻿using SeraphSecure.FlaUI.Core;
using SeraphSecure.FlaUI.Core.Definitions;
using SeraphSecure.FlaUI.Core.Identifiers;
using SeraphSecure.FlaUI.Core.Patterns;
using SeraphSecure.FlaUI.Core.Tools;
using SeraphSecure.FlaUI.UIA3.Identifiers;
using UIA = Interop.UIAutomationClient;

namespace SeraphSecure.FlaUI.UIA3.Patterns
{
    public class SynchronizedInputPattern : SynchronizedInputPatternBase<UIA.IUIAutomationSynchronizedInputPattern>
    {
        public static readonly PatternId Pattern = PatternId.Register(AutomationType.UIA3, UIA.UIA_PatternIds.UIA_SynchronizedInputPatternId, "SynchronizedInput", AutomationObjectIds.IsSynchronizedInputPatternAvailableProperty);
        public static readonly EventId DiscardedEvent = EventId.Register(AutomationType.UIA3, UIA.UIA_EventIds.UIA_InputDiscardedEventId, "Discarded");
        public static readonly EventId ReachedOtherElementEvent = EventId.Register(AutomationType.UIA3, UIA.UIA_EventIds.UIA_InputReachedOtherElementEventId, "ReachedOtherElement");
        public static readonly EventId ReachedTargetEvent = EventId.Register(AutomationType.UIA3, UIA.UIA_EventIds.UIA_InputReachedTargetEventId, "ReachedTarget");

        public SynchronizedInputPattern(FrameworkAutomationElementBase frameworkAutomationElement, UIA.IUIAutomationSynchronizedInputPattern nativePattern) : base(frameworkAutomationElement, nativePattern)
        {
        }

        public override void Cancel()
        {
            Com.Call(() => NativePattern.Cancel());
        }

        public override void StartListening(SynchronizedInputType inputType)
        {
            Com.Call(() => NativePattern.StartListening((UIA.SynchronizedInputType)inputType));
        }
    }

    public class SynchronizedInputPatternEventIds : ISynchronizedInputPatternEventIds
    {
        public EventId DiscardedEvent => SynchronizedInputPattern.DiscardedEvent;
        public EventId ReachedOtherElementEvent => SynchronizedInputPattern.ReachedOtherElementEvent;
        public EventId ReachedTargetEvent => SynchronizedInputPattern.ReachedTargetEvent;
    }
}
