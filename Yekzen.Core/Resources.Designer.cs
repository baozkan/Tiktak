﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Yekzen.Core {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Yekzen.Core.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Multiple constructors accepting all given argument types have been found in type &apos;{0}&apos;. There should only be one applicable constructor..
        /// </summary>
        internal static string AmbiguousConstructorMatch {
            get {
                return ResourceManager.GetString("AmbiguousConstructorMatch", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Unable to locate implementation &apos;{0}&apos; for service &apos;{1}&apos;..
        /// </summary>
        internal static string CannotLocateImplementation {
            get {
                return ResourceManager.GetString("CannotLocateImplementation", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Unable to resolve service for type &apos;{0}&apos; while attempting to activate &apos;{1}&apos;..
        /// </summary>
        internal static string CannotResolveService {
            get {
                return ResourceManager.GetString("CannotResolveService", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to A circular dependency was detected for the service of type &apos;{0}&apos;..
        /// </summary>
        internal static string CircularDependencyException {
            get {
                return ResourceManager.GetString("CircularDependencyException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Unable to locate suitable constructor for type &apos;{0}&apos;. Ensure the type is concrete and all parameters are accepted by a constructor..
        /// </summary>
        internal static string NoConstructorMatch {
            get {
                return ResourceManager.GetString("NoConstructorMatch", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to No service for type &apos;{0}&apos; has been registered..
        /// </summary>
        internal static string NoServiceRegistered {
            get {
                return ResourceManager.GetString("NoServiceRegistered", resourceCulture);
            }
        }
    }
}
