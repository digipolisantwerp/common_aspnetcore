using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Toolbox.Common.Validation;

namespace Toolbox.Common.Helpers
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
            var attrib = type.GetCustomAttribute<TAttribute>();
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
            var types = from t in assembly.GetTypes() where t.IsDefined(typeof(TAttribute), inherit) select t;
            return types.ToList();
        }

        /// <summary>
        /// Returns a list of all types with the given name in the AppDomain.
        /// </summary>
        /// <param name="typeName">The name of the type to look for.</param>
        /// <returns>List of Type.</returns>
        public static IEnumerable<Type> GetTypesFromAppDomain(string typeName)
        {
            ArgumentValidator.AssertNotNullOrWhiteSpace(typeName, nameof(typeName));
            var types = from a in AppDomain.CurrentDomain.GetAssemblies() from o in a.GetTypes() where o.Name.ToLower().Equals(typeName.ToLower()) select o;
            return types.ToList();
        }

        /// <summary>
        /// Returns a list of all types starting with the given value in the AppDomain.
        /// </summary>
        /// <param name="value">The value to look for.</param>
        /// <returns>List of Type.</returns>
        public static IEnumerable<Type> GetTypesThatStartWith(string value)
        {
            ArgumentValidator.AssertNotNullOrWhiteSpace(value, nameof(value));
            var objects = from a in AppDomain.CurrentDomain.GetAssemblies() from o in a.GetTypes() where o.Name.StartsWith(value) select o;
            return objects.ToList();
        }

        /// <summary>
        /// Returns a list of all assemblies in the AppDomain that reference a given assembly.
        /// </summary>
        /// <param name="filename">Name of the assembly to look for.</param>
        /// <returns>List of Assembly.</returns>
        public static IEnumerable<Assembly> GetReferencingAssemblies(string filename)
        {
            ArgumentValidator.AssertNotNullOrWhiteSpace(filename, "filename");
            var assemblies = from a in AppDomain.CurrentDomain.GetAssemblies() from r in a.GetReferencedAssemblies() where r.Name.Equals(filename.Replace(".dll", string.Empty)) select a;
            return assemblies.ToList();
        }
    }
}
