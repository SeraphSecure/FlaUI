using System.Collections.Generic;
using SeraphSecure.FlaUI.Core.Conditions;
using SeraphSecure.FlaUI.Core.Definitions;
using SeraphSecure.FlaUI.Core.Identifiers;

namespace SeraphSecure.FlaUI.Core
{
    /// <summary>
    /// A class which handles the cache requests.
    /// </summary>
    public class CacheRequest
    {
        /// <summary>
        /// Defines the reference mode of automation elements in the cache.
        /// </summary>
        public AutomationElementMode AutomationElementMode { get; set; }

        /// <summary>
        /// Defines the tree filter that is used to filter the items to cache.
        /// </summary>
        public ConditionBase TreeFilter { get; set; } = TrueCondition.Default;

        /// <summary>
        /// The tree scope used for searching items for caching.
        /// </summary>
        public TreeScope TreeScope { get; set; }

        /// <summary>
        /// The list of patterns to cache.
        /// </summary>
        public HashSet<PatternId> Patterns { get; } = new HashSet<PatternId>();

        /// <summary>
        /// The list of properties to cache.
        /// </summary>
        public HashSet<PropertyId> Properties { get; } = new HashSet<PropertyId>();

        /// <summary>
        /// Adds a pattern to the list of patterns to cache.
        /// </summary>
        public void Add(PatternId pattern)
        {
            Patterns.Add(pattern);
        }

        /// <summary>
        /// Adds a property to the list of properties to cache.
        /// </summary>
        public void Add(PropertyId property)
        {
            Properties.Add(property);
        }
    }
}
