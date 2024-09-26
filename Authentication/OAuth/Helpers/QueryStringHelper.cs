using Microsoft.AspNetCore.Authentication;

namespace Zolab.AspNetCore.Authentication.OAuth.Helpers
{
    /// <summary>
    /// Provides helper methods for working with query strings in OAuth authentication.
    /// </summary>
    public static class QueryStringHelper
    {
        /// <summary>
        /// Adds a query string parameter to the provided dictionary based on the specified name and properties.
        /// </summary>
        /// <param name="queryStrings">The dictionary of query string parameters to which the new parameter will be added.</param>
        /// <param name="properties">The <see cref="AuthenticationProperties"/> containing any existing values for the parameter.</param>
        /// <param name="name">The name of the query string parameter to add.</param>
        /// <param name="defaultValue">An optional default value to use if the parameter is not found in the <paramref name="properties"/>.</param>
        /// <remarks>
        /// This method attempts to retrieve a parameter value from the provided <paramref name="properties"/>.
        /// If a value is found, it will be added to the <paramref name="queryStrings"/> dictionary.
        /// If the parameter is present in the <paramref name="properties.Items"/> collection, that value will be used instead.
        /// After the parameter is added to the query strings, it is removed from the <paramref name="properties.Items"/> to avoid 
        /// carrying unnecessary data forward.
        /// </remarks>
        public static void AddQueryString(
            IDictionary<string, string> queryStrings,
            AuthenticationProperties properties,
            string name,
            string? defaultValue = null)
        {
            // Attempt to retrieve the value from the properties dictionary
            var value = properties.GetParameter<string>(name) ?? defaultValue;

            // If the property exists in items, use that value instead
            if (!properties.Items.TryGetValue(name, out var itemValue))
            {
                itemValue = value;
            }

            // Clean up the properties to avoid unnecessary data being carried forward
            properties.Items.Remove(name);

            // Add the value to the query string if it exists
            if (itemValue != null)
            {
                queryStrings[name] = itemValue;
            }
        }
    }
}
