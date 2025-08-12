using System;
using System.Linq;
using System.Text;
using SeraphSecure.FlaUI.Core.AutomationElements;
using SeraphSecure.FlaUI.Core.Conditions;
using SeraphSecure.FlaUI.Core.Definitions;

namespace SeraphSecure.FlaUI.Core
{
    /// <summary>
    /// Provides methods which can help in debugging.
    /// </summary>
    public static class Debug
    {
        /// <summary>
        /// Gets the XPath to the element until the desktop or the given root element.
        /// Warning: This is quite a heavy operation
        /// </summary>
        public static string GetXPathToElement(AutomationElement element, AutomationElement? rootElement = null)
        {
            var treeWalker = element.Automation.TreeWalkerFactory.GetControlViewWalker();
            return GetXPathToElement(element, treeWalker, rootElement);
        }

        private static string GetXPathToElement(AutomationElement element, ITreeWalker treeWalker, AutomationElement? rootElement = null)
        {
            var parent = treeWalker.GetParent(element);
            if (parent == null || (rootElement != null && parent.Equals(rootElement)))
            {
                return String.Empty;
            }
            // Get the index
            string controlType = "Custom";
            try
            {
                controlType = element.Properties.ControlType.Value.ToString();
            }
            catch
            { }
            AutomationElement[] allChildren;
            if (controlType == "Custom")
            {
                allChildren = parent.FindAllChildren(cf => cf.ByControlType(ControlType.Custom));
            }
            else
            {
                allChildren = parent.FindAllChildren(cf => cf.ByControlType(element.Properties.ControlType));
            }
            
            var currentItemText = $"{controlType}";
            if (allChildren.Length > 1)
            {
                // There is more than one matching child, find out the index
                var indexInParent = 1; // Index starts with 1
                foreach (var child in allChildren)
                {
                    if (child.Equals(element))
                    {
                        break;
                    }
                    indexInParent++;
                }
                currentItemText += $"[{indexInParent}]";
            }
            return $"{GetXPathToElement(parent, treeWalker, rootElement)}/{currentItemText}";
        }

        /// <summary>
        /// Prints out various details about the given element (including children).
        /// </summary>
        public static string Details(AutomationElement automationElement)
        {
            try
            {
                var stringBuilder = new StringBuilder();
                var cr = new CacheRequest
                {
                    AutomationElementMode = AutomationElementMode.None
                };
                // Add the element properties
                cr.Add(automationElement.Automation.PropertyLibrary.Element.AutomationId);
                cr.Add(automationElement.Automation.PropertyLibrary.Element.ControlType);
                cr.Add(automationElement.Automation.PropertyLibrary.Element.Name);
                cr.Add(automationElement.Automation.PropertyLibrary.Element.HelpText);
                cr.Add(automationElement.Automation.PropertyLibrary.Element.BoundingRectangle);
                cr.Add(automationElement.Automation.PropertyLibrary.Element.ClassName);
                cr.Add(automationElement.Automation.PropertyLibrary.Element.IsOffscreen);
                cr.Add(automationElement.Automation.PropertyLibrary.Element.FrameworkId);
                cr.Add(automationElement.Automation.PropertyLibrary.Element.ProcessId);
                // Add the pattern availability properties
                automationElement.Automation.PropertyLibrary.PatternAvailability.AllForCurrentFramework.ToList().ForEach(x => cr.Add(x));
                cr.TreeScope = TreeScope.Subtree;
                cr.TreeFilter = TrueCondition.Default;
                // Re-find the root element with caching
                automationElement = automationElement.FindFirst(TreeScope.Element, TrueCondition.Default, cr)!;
                Details(stringBuilder, automationElement, String.Empty, cr);
                return stringBuilder.ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to dump info: " + ex);
                return String.Empty;
            }
        }

        private static void Details(StringBuilder stringBuilder, AutomationElement automationElement, string displayPadding, CacheRequest cacheRequest)
        {
            const string indent = "    ";
            WriteDetail(automationElement, stringBuilder, displayPadding, cacheRequest);
            WritePattern(automationElement, stringBuilder, displayPadding);
            var children = automationElement.CachedChildren;
            foreach (var child in children)
            {
                Details(stringBuilder, child, displayPadding + indent, cacheRequest);
            }
        }

        private static void WriteDetail(AutomationElement automationElement, StringBuilder stringBuilder, string displayPadding, CacheRequest cacheRequest)
        {
            WriteWithPadding(stringBuilder, "AutomationId: " + automationElement.Properties.AutomationId.GetValueOrDefault(cacheRequest), displayPadding);
            WriteWithPadding(stringBuilder, "ControlType: " + automationElement.Properties.ControlType.GetValueOrDefault(cacheRequest), displayPadding);
            WriteWithPadding(stringBuilder, "Name: " + automationElement.Properties.Name.GetValueOrDefault(cacheRequest), displayPadding);
            WriteWithPadding(stringBuilder, "HelpText: " + automationElement.Properties.HelpText.GetValueOrDefault(cacheRequest), displayPadding);
            WriteWithPadding(stringBuilder, "Bounding rectangle: " + automationElement.Properties.BoundingRectangle.GetValueOrDefault(cacheRequest), displayPadding);
            WriteWithPadding(stringBuilder, "ClassName: " + automationElement.Properties.ClassName.GetValueOrDefault(cacheRequest), displayPadding);
            WriteWithPadding(stringBuilder, "IsOffScreen: " + automationElement.Properties.IsOffscreen.GetValueOrDefault(cacheRequest), displayPadding);
            WriteWithPadding(stringBuilder, "FrameworkId: " + automationElement.Properties.FrameworkId.GetValueOrDefault(cacheRequest), displayPadding);
            WriteWithPadding(stringBuilder, "ProcessId: " + automationElement.Properties.ProcessId.GetValueOrDefault(cacheRequest), displayPadding);
        }

        private static void WritePattern(AutomationElement automationElement, StringBuilder stringBuilder, string displayPadding)
        {
            var availablePatterns = automationElement.GetSupportedPatterns();
            foreach (var automationPattern in availablePatterns)
            {
                WriteWithPadding(stringBuilder, automationPattern.ToString(), displayPadding);
            }
            stringBuilder.AppendLine();
        }

        private static void WriteWithPadding(StringBuilder stringBuilder, string message, string padding)
        {
            stringBuilder.Append(padding).AppendLine(message);
        }
    }
}
