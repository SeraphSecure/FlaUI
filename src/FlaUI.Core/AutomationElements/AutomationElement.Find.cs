using System;
using System.Collections.Generic;
using System.Linq;
using SeraphSecure.FlaUI.Core.AutomationElements.Infrastructure;
using SeraphSecure.FlaUI.Core.Conditions;
using SeraphSecure.FlaUI.Core.Definitions;

namespace SeraphSecure.FlaUI.Core.AutomationElements
{
    public partial class AutomationElement : IAutomationElementFinder
    {
        /// <inheritdoc />
        public AutomationElement[] FindAll(TreeScope treeScope, ConditionBase condition, CacheRequest? cacheRequest = null)
        {
            return FrameworkAutomationElement.FindAll(treeScope, condition, cacheRequest);
        }

        /// <inheritdoc />
        public AutomationElement? FindFirst(TreeScope treeScope, ConditionBase condition, CacheRequest? cacheRequest = null)
        {
            return FrameworkAutomationElement.FindFirst(treeScope, condition, cacheRequest);
        }

        /// <inheritdoc />
        public AutomationElement[] FindAllWithOptions(TreeScope treeScope, ConditionBase condition,
            TreeTraversalOptions traversalOptions, AutomationElement root, CacheRequest? cacheRequest = null)
        {
            return FrameworkAutomationElement.FindAllWithOptions(treeScope, condition, traversalOptions, root, cacheRequest);
        }

        /// <inheritdoc />
        public AutomationElement? FindFirstWithOptions(TreeScope treeScope, ConditionBase condition,
            TreeTraversalOptions traversalOptions, AutomationElement root, CacheRequest? cacheRequest = null)
        {
            return FrameworkAutomationElement.FindFirstWithOptions(treeScope, condition, traversalOptions, root, cacheRequest);
        }

        /// <inheritdoc />
        public AutomationElement? FindAt(TreeScope treeScope, int index, ConditionBase condition, CacheRequest? cacheRequest = null)
        {
            return FrameworkAutomationElement.FindAt(treeScope, index, condition, cacheRequest);
        }

        /// <summary>
        /// Finds the first element by iterating thru all conditions.
        /// </summary>
        public AutomationElement? FindFirstNested(params ConditionBase[] nestedConditions)
        {
            var currentElement = this;
            foreach (var condition in nestedConditions)
            {
                currentElement = currentElement.FindFirstChild(condition);
                if (currentElement == null)
                {
                    return null;
                }
            }
            return currentElement;
        }

        /// <summary>
        /// Finds all elements by iterating thru all conditions.
        /// </summary>
        public AutomationElement[]? FindAllNested(params ConditionBase[] nestedConditions)
        {
            var currentElement = this;
            for (var i = 0; i < nestedConditions.Length - 1; i++)
            {
                var condition = nestedConditions[i];
                currentElement = currentElement.FindFirstChild(condition);
                if (currentElement == null)
                {
                    return null;
                }
            }
            return currentElement.FindAllChildren(nestedConditions.Last());
        }

        /// <summary>
        /// Finds for the first item which matches the given xpath.
        /// </summary>
        public AutomationElement? FindFirstByXPath(string xPath)
        {
            var xPathNavigator = new AutomationElementXPathNavigator(this);
            var nodeItem = xPathNavigator.SelectSingleNode(xPath);
            return (AutomationElement?)nodeItem?.UnderlyingObject;
        }

        /// <summary>
        /// Finds all items which match the given xpath.
        /// </summary>
        public AutomationElement[] FindAllByXPath(string xPath)
        {
            var xPathNavigator = new AutomationElementXPathNavigator(this);
            var itemNodeIterator = xPathNavigator.Select(xPath);
            var itemList = new List<AutomationElement>();
            while (itemNodeIterator.MoveNext())
            {
                var automationItem = (AutomationElement)itemNodeIterator.Current.UnderlyingObject;
                itemList.Add(automationItem);
            }
            return itemList.ToArray();
        }

        /// <summary>
        /// Finds the first child.
        /// </summary>
        /// <returns>The found element or null if no element was found.</returns>
        public AutomationElement? FindFirstChild(CacheRequest? cacheRequest = null)
        {
            return FindFirst(TreeScope.Children, TrueCondition.Default, cacheRequest);
        }

        /// <summary>
        /// Finds the first child with the given automation id.
        /// </summary>
        /// <param name="automationId">The automation id.</param>
        /// <returns>The found element or null if no element was found.</returns>
        public AutomationElement? FindFirstChild(string automationId, CacheRequest? cacheRequest = null)
        {
            return FindFirst(TreeScope.Children, ConditionFactory.ByAutomationId(automationId), cacheRequest);
        }

        /// <summary>
        /// Finds the first child with the condition.
        /// </summary>
        /// <param name="condition">The condition.</param>
        /// <returns>The found element or null if no element was found.</returns>
        public AutomationElement? FindFirstChild(ConditionBase condition, CacheRequest? cacheRequest = null)
        {
            return FindFirst(TreeScope.Children, condition, cacheRequest);
        }

        /// <summary>
        /// Finds the first child with the condition.
        /// </summary>
        /// <param name="conditionFunc">The condition method.</param>
        /// <returns>The found element or null if no element was found.</returns>
        public AutomationElement? FindFirstChild(Func<ConditionFactory, ConditionBase> conditionFunc, CacheRequest? cacheRequest = null)
        {
            var condition = conditionFunc(ConditionFactory);
            return FindFirstChild(condition, cacheRequest);
        }

        /// <summary>
        /// Finds all children.
        /// </summary>
        /// <returns>The found elements or an empty list if no elements were found.</returns>
        public AutomationElement[] FindAllChildren(CacheRequest? cacheRequest = null)
        {
            return FindAll(TreeScope.Children, TrueCondition.Default, cacheRequest);
        }

        /// <summary>
        /// Finds all children with the condition.
        /// </summary>
        /// <param name="condition">The condition.</param>
        /// <returns>The found elements or an empty list if no elements were found.</returns>
        public AutomationElement[] FindAllChildren(ConditionBase condition, CacheRequest? cacheRequest = null)
        {
            return FindAll(TreeScope.Children, condition, cacheRequest);
        }

        /// <summary>
        /// Finds all children with the condition.
        /// </summary>
        /// <param name="conditionFunc">The condition method.</param>
        /// <returns>The found elements or an empty list if no elements were found.</returns>
        public AutomationElement[] FindAllChildren(Func<ConditionFactory, ConditionBase> conditionFunc, CacheRequest? cacheRequest = null)
        {
            var condition = conditionFunc(ConditionFactory);
            return FindAllChildren(condition, cacheRequest);
        }

        /// <summary>
        /// Finds the first descendant.
        /// </summary>
        /// <returns>The found element or null if no element was found.</returns>
        public AutomationElement? FindFirstDescendant(CacheRequest? cacheRequest = null)
        {
            return FindFirst(TreeScope.Descendants, TrueCondition.Default, cacheRequest);
        }

        /// <summary>
        /// Finds the first descendant with the given automation id.
        /// </summary>
        /// <param name="automationId">The automation id.</param>
        /// <returns>The found element or null if no element was found.</returns>
        public AutomationElement? FindFirstDescendant(string automationId, CacheRequest? cacheRequest = null)
        {
            return FindFirst(TreeScope.Descendants, ConditionFactory.ByAutomationId(automationId), cacheRequest);
        }

        /// <summary>
        /// Finds the first descendant with the condition.
        /// </summary>
        /// <param name="condition">The condition.</param>
        /// <returns>The found element or null if no element was found.</returns>
        public AutomationElement? FindFirstDescendant(ConditionBase condition, CacheRequest? cacheRequest = null)
        {
            return FindFirst(TreeScope.Descendants, condition, cacheRequest);
        }

        /// <summary>
        /// Finds the first descendant with the condition.
        /// </summary>
        /// <param name="conditionFunc">The condition method.</param>
        /// <returns>The found element or null if no element was found.</returns>
        public AutomationElement? FindFirstDescendant(Func<ConditionFactory, ConditionBase> conditionFunc, CacheRequest? cacheRequest = null)
        {
            var condition = conditionFunc(ConditionFactory);
            return FindFirstDescendant(condition, cacheRequest);
        }

        /// <summary>
        /// Finds all descendants.
        /// </summary>
        /// <returns>The found elements or an empty list if no elements were found.</returns>
        public AutomationElement[] FindAllDescendants(CacheRequest? cacheRequest = null)
        {
            return FindAll(TreeScope.Descendants, TrueCondition.Default, cacheRequest);
        }

        /// <summary>
        /// Finds all descendants with the condition.
        /// </summary>
        /// <param name="condition">The condition.</param>
        /// <returns>The found elements or an empty list if no elements were found.</returns>
        public AutomationElement[] FindAllDescendants(ConditionBase condition, CacheRequest? cacheRequest = null)
        {
            return FindAll(TreeScope.Descendants, condition, cacheRequest);
        }

        /// <summary>
        /// Finds all descendants with the condition.
        /// </summary>
        /// <param name="conditionFunc">The condition method.</param>
        /// <returns>The found elements or an empty list if no elements were found.</returns>
        public AutomationElement[] FindAllDescendants(Func<ConditionFactory, ConditionBase> conditionFunc, CacheRequest? cacheRequest = null)
        {
            var condition = conditionFunc(ConditionFactory);
            return FindAllDescendants(condition, cacheRequest);
        }

        /// <summary>
        /// Finds the first element by iterating thru all conditions.
        /// </summary>
        /// <param name="conditionFunc">The condition method.</param>
        /// <returns>The found element or null if no element was found.</returns>
        public AutomationElement? FindFirstNested(Func<ConditionFactory, IList<ConditionBase>> conditionFunc)
        {
            var conditions = conditionFunc(ConditionFactory);
            return FindFirstNested(conditions.ToArray());
        }

        /// <summary>
        /// Finds all elements by iterating thru all conditions.
        /// </summary>
        /// <param name="conditionFunc">The condition method.</param>
        /// <returns>The found elements or an empty list if no elements were found.</returns>
        public AutomationElement[]? FindAllNested(Func<ConditionFactory, IList<ConditionBase>> conditionFunc)
        {
            var conditions = conditionFunc(ConditionFactory);
            return FindAllNested(conditions.ToArray());
        }

        /// <summary>
        /// Finds the child at the given position with the condition.
        /// </summary>
        /// <param name="index">The index of the child to find.</param>
        /// <param name="condition">The condition.</param>
        /// <returns>The found element or null if no element was found.</returns>
        public AutomationElement? FindChildAt(int index, ConditionBase? condition = null, CacheRequest? cacheRequest = null)
        {
            return FindAt(TreeScope.Children, index, condition ?? TrueCondition.Default, cacheRequest);
        }

        /// <summary>
        /// Finds the child at the given position with the condition.
        /// </summary>
        /// <param name="index">The index of the child to find.</param>
        /// <param name="conditionFunc">The condition method.</param>
        /// <returns>The found element or null if no element was found.</returns>
        public AutomationElement? FindChildAt(int index, Func<ConditionFactory, ConditionBase> conditionFunc, CacheRequest? cacheRequest = null)
        {
            var condition = conditionFunc(ConditionFactory);
            return FindChildAt(index, condition, cacheRequest);
        }
    }
}
