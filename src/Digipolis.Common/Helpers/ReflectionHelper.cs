using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Digipolis.Common.Validation;
using Microsoft.Extensions.DependencyModel;
using Microsoft.DotNet.InternalAbstractions;
using System.Diagnostics;

namespace Digipolis.Common.Helpers
{
    public static class ReflectionHelper
    {
        /// <summary>
        /// Returns a list of TypeInfo about classes in the assembly that inherit from the given base class.
        /// </summary>
        /// <param name="assembly">The assembly to reflect on.</param>
        /// <param name="baseClass">The base class to get the descendants from.</param>
        /// <returns>List of TypeInfo.</returns>
        /// <exception cref="ArgumentNullException">When an input argument is null.</exception>
        public static IEnumerable<TypeInfo> GetClassesInheritingFrom(Assembly assembly, Type baseClass)
        {
            ArgumentValidator.AssertNotNull(assembly, nameof(assembly));
            ArgumentValidator.AssertNotNull(baseClass, nameof(baseClass));
            var classes = ( from t in assembly.DefinedTypes where t.IsClass && t.IsSubclassOf(baseClass) select t ).ToArray();
            return classes.ToList();
        }

        /// <summary>
        /// Returns the Attribute defined on the give type.
        /// </summary>
        /// <typeparam name="TAttribute">Type of the attribute.</typeparam>
        /// <param name="type">The Type of the object to get the attribute from.</param>
        /// <returns>The attribute if defined on the type, else null.</returns>
        public static TAttribute GetAttributeFrom<TAttribute>(Type type) where TAttribute : Attribute
        {
            ArgumentValidator.AssertNotNull(type, nameof(type));
            var attrib = type.GetTypeInfo().GetCustomAttribute<TAttribute>();
            return attrib;
        }

        /// <summary>
        /// Returns a list of types that bear a given attribute.
        /// </summary>
        /// <typeparam name="TAttribute">Type of the attribute.</typeparam>
        /// <param name="assembly">The assembly to reflect on.</param>
        /// <param name="inherit">Return inherited types or not.</param>
        /// <returns>List of Type.</returns>
        public static IEnumerable<Type> GetTypesWithAttribute<TAttribute>(Assembly assembly, bool inherit) where TAttribute : System.Attribute
        {
            ArgumentValidator.AssertNotNull(assembly, nameof(assembly));
            var types = from t in assembly.GetTypes() where t.GetTypeInfo().IsDefined(typeof(TAttribute), inherit) select t;
            return types.ToList();
        }
    }
}
