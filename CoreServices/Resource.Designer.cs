﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.17626
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CoreServices {
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
    internal class Resource {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resource() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("CoreServices.Resource", typeof(Resource).Assembly);
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
        ///   Looks up a localized string similar to Queue does not exists..
        /// </summary>
        internal static string ERR_QUEUEDOESNOTEXISTS {
            get {
                return ResourceManager.GetString("ERR_QUEUEDOESNOTEXISTS", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Unable to create new queue: {0}. Internal error: {1}.
        /// </summary>
        internal static string ERR_UNABLECREATEMSMQ {
            get {
                return ResourceManager.GetString("ERR_UNABLECREATEMSMQ", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Unable to enumerate {0} queues on &apos;{1}&apos;. Internal error: {2}.
        /// </summary>
        internal static string ERR_UNABLEENUMERATEQUEUES {
            get {
                return ResourceManager.GetString("ERR_UNABLEENUMERATEQUEUES", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Unable to purge queue: {0}. Internal error: {1}.
        /// </summary>
        internal static string ERR_UNABLEPURGE {
            get {
                return ResourceManager.GetString("ERR_UNABLEPURGE", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Unable to connect to {0}..
        /// </summary>
        internal static string ERR_UNABLETOCONNECT {
            get {
                return ResourceManager.GetString("ERR_UNABLETOCONNECT", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Unable to delete queue: {0}. Internal error: {1}.
        /// </summary>
        internal static string ERR_UNABLETODELETE {
            get {
                return ResourceManager.GetString("ERR_UNABLETODELETE", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Unable to peek in the queue: {0}. Internal error: {1}.
        /// </summary>
        internal static string ERR_UNABLETOPEEK {
            get {
                return ResourceManager.GetString("ERR_UNABLETOPEEK", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Unable to read the queue: {0}. Internal error: {1}.
        /// </summary>
        internal static string ERR_UNABLETOREAD {
            get {
                return ResourceManager.GetString("ERR_UNABLETOREAD", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Unable to receive message from the queue: {0}. Internal error: {1}.
        /// </summary>
        internal static string ERR_UNABLETORECEIVEMESSAGE {
            get {
                return ResourceManager.GetString("ERR_UNABLETORECEIVEMESSAGE", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Unable to send message to the queue: {0}. Internal error: {1}.
        /// </summary>
        internal static string ERR_UNABLETOSENDMESSAGE {
            get {
                return ResourceManager.GetString("ERR_UNABLETOSENDMESSAGE", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Connected to {0}..
        /// </summary>
        internal static string INFO_CONNECTSUCCESS {
            get {
                return ResourceManager.GetString("INFO_CONNECTSUCCESS", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Queue {0} does not exist considering delete command successful..
        /// </summary>
        internal static string INFO_DELETEQUEUEDOESNOTEXISTS {
            get {
                return ResourceManager.GetString("INFO_DELETEQUEUEDOESNOTEXISTS", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to private.
        /// </summary>
        internal static string WDR_PRIVATE {
            get {
                return ResourceManager.GetString("WDR_PRIVATE", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to public.
        /// </summary>
        internal static string WDR_PUBLIC {
            get {
                return ResourceManager.GetString("WDR_PUBLIC", resourceCulture);
            }
        }
    }
}