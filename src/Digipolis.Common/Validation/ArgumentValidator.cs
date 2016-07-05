using System;
using System.Collections.Generic;
using System.Linq;

namespace Digipolis.Common.Validation
{
    public static class ArgumentValidator
    {
        /// <summary>
        /// Raises an exception if the given argument is an empty string.
        /// </summary>
        /// <param name="argument">Argument to check for empty string.</param>
        /// <param name="name">Name of the argument, to be used in the exception message.</param>
        /// <param name="member">Used in the exception message to state where the exception was raised.</param>
        /// <exception cref="ArgumentException">If the given argument is an empty string.</exception>
        public static void AssertNotEmpty(string argument, string name, string member = null)
        {
            if ( argument == null )
                return;
            if ( argument == string.Empty )
            {
                if ( string.IsNullOrEmpty(member) )
                {
                    throw new ArgumentException(string.Format(Messages.EmptyString, name), name);
                }
                else
                {
                    throw new ArgumentException(string.Format(Messages.EmptyString + " in {1}.", name, member), name);
                }
            }
        }

        /// <summary>
        /// Raises an exception if the given argument is null.
        /// </summary>
        /// <param name="argument">Argument to check for null.</param>
        /// <param name="name">Name of the argument, to be used in the exception message.</param>
        /// <param name="member">Used in the exception message to state where the exception was raised.</param>
        /// <exception cref="ArgumentNullException">If the given argument is null.</exception>
        public static void AssertNotNull(object argument, string name, string member = null)
        {
            if ( argument == null )
            {
                if ( string.IsNullOrEmpty(member) )
                {
                    throw new ArgumentNullException(name, string.Format(Messages.NullString, name));
                }
                else
                {
                    throw new ArgumentNullException(name, string.Format(Messages.NullString + " in {1}.", name, member));
                }
            }
        }

        /// <summary>
        /// Raises an exception if the given string argument is null or an empty string.
        /// </summary>
        /// <param name="argument">Argument to check for null or empty string.</param>
        /// <param name="name">Name of the argument, to be used in the exception message.</param>
        /// <param name="member">Used in the exception message to state where the exception was raised.</param>
        /// <exception cref="ArgumentException">If the argument is an empty string.</exception>
        /// <exception cref="ArgumentNullException">If the argument is null.</exception>
        public static void AssertNotNullOrEmpty(string argument, string name, string member = null)
        {
            if ( argument == null )
            {
                if ( string.IsNullOrEmpty(member) )
                {
                    throw new ArgumentNullException(name, string.Format(Messages.NullString, name));
                }
                else
                {
                    throw new ArgumentNullException(name, string.Format(Messages.NullString + " in {1}.", name, member));
                }
            }
            if ( argument == string.Empty )
            {
                if ( string.IsNullOrEmpty(member) )
                {
                    throw new ArgumentException(string.Format(Messages.EmptyString, name), name);
                }
                else
                {
                    throw new ArgumentException(string.Format(Messages.EmptyString + " in {1}.", name, member), name);
                }
            }
        }

        /// <summary>
        /// Raises an exception if the given argument is null, an empty string or only contains white space.
        /// </summary>
        /// <param name="argument">Argument to check for null, empty string or white space.</param>
        /// <param name="name">Name of the argument, to be used in the exception message.</param>
        /// <param name="member">Used in the exception message to state where the exception was raised.</param>
        /// <exception cref=ArgumentException">If the argument is empty or contains only white space.</exception>
        /// <exception cref="ArgumentNullException">If the argument is null.</exception>
        public static void AssertNotNullOrWhiteSpace(string argument, string name, string member = null)
        {
            if ( argument == null )
            {
                if ( string.IsNullOrEmpty(member) )
                {
                    throw new ArgumentNullException(name, string.Format(Messages.NullString, name));
                }
                else
                {
                    throw new ArgumentNullException(name, string.Format(Messages.NullString + " in {1}.", name, member));
                }
            }
            if ( argument == string.Empty )
            {
                if ( string.IsNullOrEmpty(member) )
                {
                    throw new ArgumentException(string.Format(Messages.EmptyString, name), name);
                }
                else
                {
                    throw new ArgumentException(string.Format(Messages.EmptyString + " in {1}.", name, member), name);
                }
            }
            if ( argument.Trim() == string.Empty )
            {
                if ( string.IsNullOrEmpty(member) )
                {
                    throw new ArgumentException(string.Format(Messages.WhiteSpaceString, name), name);
                }
                else
                {
                    throw new ArgumentException(string.Format(Messages.WhiteSpaceString + " in {1}.", name, member), name);
                }
            }
        }

        /// <summary>
        /// The messages used in the exceptions.
        /// </summary>
        public class Messages
        {
            public static string NullString = "{0} is null.";
            public static string EmptyString = "{0} is empty.";
            public static string WhiteSpaceString = "{0} contains only spaces.";

            /// <summary>
            /// Sets the messages to their default values.
            /// </summary>
            public static void SetDefaults()
            {
                NullString = "{0} is null.";
                EmptyString = "{0} is empty.";
                WhiteSpaceString = "{0} contains only space.";
            }
        }
    }
}
