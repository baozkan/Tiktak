using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yekzen.QualityTools.UnitTest
{
    /// <summary>
    /// Contains assertion types that are not provided with the standard MSTest assertions.
    /// </summary>
    public static class ExceptionAssert
    {
        /// <summary>
        /// Checks to make sure that the input delegate throws a exception of type TException.
        /// </summary>
        /// <typeparam name="TException">The type of exception expected.</typeparam>
        /// <param name="action">The block of code to execute to generate the exception.</param>
        /// <param name="expectedMessage">Expected message when throw exception.</param>
        public static void Throws<TException>(Action action, string expectedMessage = null) where TException : System.Exception
        {
            try
            {
                action();
                Assert.Fail("Expected exception of type " + typeof(TException) + " but no exception was thrown.");
            }
            catch (TException ex)
            {
                if(!string.IsNullOrEmpty(expectedMessage))
                    Assert.AreEqual(expectedMessage, ex.Message, "Expected exception with a message of '" + expectedMessage + "' but exception with message of '" + ex.Message + "' was thrown instead.");
            }
        }

        /// <summary>
        /// Send message.
        /// </summary>
        /// <typeparam name="TException">The type of exception expected.</typeparam>
        /// <param name="action">The block of code to execute to generate the exception.</param>
        /// <param name="expectedMessage">Expected message when throw a exception.</param>
        public static void InconclusiveWhenThrows<TException>(Action action, string expectedMessage = null) where TException : System.Exception
        {
            try
            {
                action();
            }
            catch (TException ex)
            {
                if (!string.IsNullOrEmpty(expectedMessage))
                    Assert.AreEqual(expectedMessage, ex.Message, "Expected exception with a message of '" + expectedMessage + "' but exception with message of '" + ex.Message + "' was thrown instead.");
                
                Assert.Inconclusive(ex.Message);
            }
        }
    }
}
