﻿using System.Drawing;
using SeraphSecure.FlaUI.Core;
using SeraphSecure.FlaUI.Core.AutomationElements;
using SeraphSecure.FlaUI.Core.Definitions;
using SeraphSecure.FlaUI.Core.Identifiers;
using SeraphSecure.FlaUI.Core.Patterns;
using SeraphSecure.FlaUI.Core.Tools;
using SeraphSecure.FlaUI.UIA3.Converters;
using SeraphSecure.FlaUI.UIA3.Extensions;
using SeraphSecure.FlaUI.UIA3.Identifiers;
using UIA = Interop.UIAutomationClient;

namespace SeraphSecure.FlaUI.UIA3.Patterns
{
    public class TextPattern : TextPatternBase<UIA.IUIAutomationTextPattern>
    {
        public static readonly PatternId Pattern = PatternId.Register(AutomationType.UIA3, UIA.UIA_PatternIds.UIA_TextPatternId, "Text", AutomationObjectIds.IsTextPatternAvailableProperty);
        public static readonly EventId TextChangedEvent = EventId.Register(AutomationType.UIA3, UIA.UIA_EventIds.UIA_Text_TextChangedEventId, "TextChanged");
        public static readonly EventId TextSelectionChangedEvent = EventId.Register(AutomationType.UIA3, UIA.UIA_EventIds.UIA_Text_TextSelectionChangedEventId, "TextSelectionChanged");

        public TextPattern(FrameworkAutomationElementBase frameworkAutomationElement, UIA.IUIAutomationTextPattern nativePattern) : base(frameworkAutomationElement, nativePattern)
        {
        }

        public override ITextRange DocumentRange
        {
            get
            {
                var nativeRange = Com.Call(() => NativePattern.DocumentRange);
                return TextRangeConverter.NativeToManaged((UIA3Automation)FrameworkAutomationElement.Automation, nativeRange);
            }
        }

        public override SupportedTextSelection SupportedTextSelection
        {
            get
            {
                var nativeObject = Com.Call(() => NativePattern.SupportedTextSelection);
                return (SupportedTextSelection)nativeObject;
            }
        }

        public override ITextRange[] GetSelection()
        {
            var nativeRanges = Com.Call(() => NativePattern.GetSelection());
            return TextRangeConverter.NativeArrayToManaged((UIA3Automation)FrameworkAutomationElement.Automation, nativeRanges);
        }

        public override ITextRange[] GetVisibleRanges()
        {
            var nativeRanges = Com.Call(() => NativePattern.GetVisibleRanges());
            return TextRangeConverter.NativeArrayToManaged((UIA3Automation)FrameworkAutomationElement.Automation, nativeRanges);
        }

        public override ITextRange RangeFromChild(AutomationElement child)
        {
            var nativeChild = child.ToNative();
            var nativeRange = Com.Call(() => NativePattern.RangeFromChild(nativeChild));
            return TextRangeConverter.NativeToManaged((UIA3Automation)FrameworkAutomationElement.Automation, nativeRange);
        }

        public override ITextRange RangeFromPoint(Point point)
        {
            var nativeRange = Com.Call(() => NativePattern.RangeFromPoint(point.ToTagPoint()));
            return TextRangeConverter.NativeToManaged((UIA3Automation)FrameworkAutomationElement.Automation, nativeRange);
        }
    }

    public class TextPatternEventIds : ITextPatternEventIds
    {
        public EventId TextChangedEvent => TextPattern.TextChangedEvent;
        public EventId TextSelectionChangedEvent => TextPattern.TextSelectionChangedEvent;
    }
}
