﻿using System.Drawing;
using SeraphSecure.FlaUI.Core.AutomationElements;
using SeraphSecure.FlaUI.Core.Definitions;
using SeraphSecure.FlaUI.Core.Identifiers;

namespace SeraphSecure.FlaUI.Core
{
    public interface ITextRange
    {
        void AddToSelection();
        ITextRange Clone();
        bool Compare(ITextRange range);
        int CompareEndpoints(TextPatternRangeEndpoint srcEndPoint, ITextRange targetRange, TextPatternRangeEndpoint targetEndPoint);
        void ExpandToEnclosingUnit(TextUnit textUnit);
        ITextRange FindAttribute(TextAttributeId attribute, object value, bool backward);
        ITextRange FindText(string text, bool backward, bool ignoreCase);
        object GetAttributeValue(TextAttributeId attribute);
        Rectangle[] GetBoundingRectangles();
        AutomationElement[] GetChildren();
        AutomationElement GetEnclosingElement();
        string GetText(int maxLength);
        int Move(TextUnit unit, int count);
        void MoveEndpointByRange(TextPatternRangeEndpoint srcEndPoint, ITextRange targetRange, TextPatternRangeEndpoint targetEndPoint);
        int MoveEndpointByUnit(TextPatternRangeEndpoint endpoint, TextUnit unit, int count);
        void RemoveFromSelection();
        void ScrollIntoView(bool alignToTop);
        void Select();
    }
}
