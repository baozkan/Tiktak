using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yekzen.Core
{
    public static class Requires
    {
        /// <summary>
        /// Throws an exception if the specified parameter's value is null.
        /// </summary>
        /// <typeparam name="TValue">The type of the parameter.</typeparam>
        /// <param name="value">The value of the argument.</param>
        /// <param name="name">The name of the parameter to include in any thrown exception.</param>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="value"/> is <c>null</c></exception>
        [DebuggerStepThrough]
        public static void NotNull<TValue>(TValue value, string name) where TValue : class
        {
            if (value == null)
                throw new ArgumentNullException(name);
        }


        /// <summary>
        /// Throws an exception if there is type mismatch.
        /// </summary>
        /// <typeparam name="TValue">The type of the parameter.</typeparam>
        /// <typeparam name="TType">It is supposed to be the parameter type.</typeparam>
        /// <param name="value">The value of the argument.</param>
        /// <param name="name">The name of the parameter to include in any thrown exception.</param>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="value"/> type is not <c>TType</c></exception>
        public static void IsType<TValue, TType>(TValue value, string name)
        { 
            if(!(value is TType))
                throw new ArgumentException(name);
        }
    }
}
