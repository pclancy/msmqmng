﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18047
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MSMQManagementConsole {
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
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("MSMQManagementConsole.Resource", typeof(Resource).Assembly);
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
        ///   Looks up a localized string similar to Failed to convert {0} to integer. Parameter name: {1}..
        /// </summary>
        internal static string ERR_FAILEDTOCONVERTTOINT {
            get {
                return ResourceManager.GetString("ERR_FAILEDTOCONVERTTOINT", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to File not found: {0}.
        /// </summary>
        internal static string ERR_FILENOTFOUND {
            get {
                return ResourceManager.GetString("ERR_FILENOTFOUND", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Unable to peek, queue is empty..
        /// </summary>
        internal static string ERR_QUEUEISEMPTY {
            get {
                return ResourceManager.GetString("ERR_QUEUEISEMPTY", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Unable to open file &quot;{0}&quot;. Internal error: {1}..
        /// </summary>
        internal static string ERR_UNABLETOOPENFILE {
            get {
                return ResourceManager.GetString("ERR_UNABLETOOPENFILE", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Unexpected error..
        /// </summary>
        internal static string ERR_UNEXPECTEDERROR {
            get {
                return ResourceManager.GetString("ERR_UNEXPECTEDERROR", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Availabilty matrix:.
        /// </summary>
        internal static string INFO_CMD_AVAILABILITY {
            get {
                return ResourceManager.GetString("INFO_CMD_AVAILABILITY", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to copy /s [source path] /d [destination path].
        /// </summary>
        internal static string INFO_CMD_COPY {
            get {
                return ResourceManager.GetString("INFO_CMD_COPY", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Copies all messages from source queue to destination queue using default formatter..
        /// </summary>
        internal static string INFO_CMD_COPYDESC {
            get {
                return ResourceManager.GetString("INFO_CMD_COPYDESC", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to copy /s .\private$\SourceQueue /d .\private$\DestinationQueue.
        /// </summary>
        internal static string INFO_CMD_COPYEXAMPLE0 {
            get {
                return ResourceManager.GetString("INFO_CMD_COPYEXAMPLE0", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to create /p [path] [optional:/t].
        /// </summary>
        internal static string INFO_CMD_CREATE {
            get {
                return ResourceManager.GetString("INFO_CMD_CREATE", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Creates a transactional or non-transactional queue at the specified path..
        /// </summary>
        internal static string INFO_CMD_CREATEDESC {
            get {
                return ResourceManager.GetString("INFO_CMD_CREATEDESC", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to create /p .\private$\MSMQStudioQueue.
        /// </summary>
        internal static string INFO_CMD_CREATEEXAMPLE0 {
            get {
                return ResourceManager.GetString("INFO_CMD_CREATEEXAMPLE0", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to create /p .\private$\MSMQStudioQueue /t.
        /// </summary>
        internal static string INFO_CMD_CREATEEXAMPLE1 {
            get {
                return ResourceManager.GetString("INFO_CMD_CREATEEXAMPLE1", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to delete /p [path].
        /// </summary>
        internal static string INFO_CMD_DELETE {
            get {
                return ResourceManager.GetString("INFO_CMD_DELETE", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Deletes queue referenced by path..
        /// </summary>
        internal static string INFO_CMD_DELETEDESC {
            get {
                return ResourceManager.GetString("INFO_CMD_DELETEDESC", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to delete /p .\private$\MSMQStudioQueue.
        /// </summary>
        internal static string INFO_CMD_DELETEEXAMPLE0 {
            get {
                return ResourceManager.GetString("INFO_CMD_DELETEEXAMPLE0", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Examples:.
        /// </summary>
        internal static string INFO_CMD_EXAMPLE {
            get {
                return ResourceManager.GetString("INFO_CMD_EXAMPLE", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to export /p [path] [optional:/f [filename]].
        /// </summary>
        internal static string INFO_CMD_EXPORT {
            get {
                return ResourceManager.GetString("INFO_CMD_EXPORT", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Exports all messages from source queue to destination file. If name of the file was not provided msmqmng will create new file with the name equal to the queue name adding &apos;.xml&apos; extension. Export command does NOT remove messages from the queue..
        /// </summary>
        internal static string INFO_CMD_EXPORTDESC {
            get {
                return ResourceManager.GetString("INFO_CMD_EXPORTDESC", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to export /p .\private$\MSMQStudioQueue.
        /// </summary>
        internal static string INFO_CMD_EXPORTEXAMPLE0 {
            get {
                return ResourceManager.GetString("INFO_CMD_EXPORTEXAMPLE0", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to export /p .\private$\MSMQStudioQueue /f C:\QueueData\msmqexport.xml.
        /// </summary>
        internal static string INFO_CMD_EXPORTEXAMPLE1 {
            get {
                return ResourceManager.GetString("INFO_CMD_EXPORTEXAMPLE1", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to extract /p [path] [optional:/f [filename]].
        /// </summary>
        internal static string INFO_CMD_EXTRACT {
            get {
                return ResourceManager.GetString("INFO_CMD_EXTRACT", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Exports all messages from source queue to destination file and removes the messages from the queue. If name of the file was not provided msmqmng will create new file with the name equal to the queue name adding &apos;.xml&apos; extension..
        /// </summary>
        internal static string INFO_CMD_EXTRACTDESC {
            get {
                return ResourceManager.GetString("INFO_CMD_EXTRACTDESC", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to extract /p .\private$\MSMQStudioQueue.
        /// </summary>
        internal static string INFO_CMD_EXTRACTEXAMPLE0 {
            get {
                return ResourceManager.GetString("INFO_CMD_EXTRACTEXAMPLE0", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to extract /p .\private$\MSMQStudioQueue /f C:\QueueData\msmqexport.xml.
        /// </summary>
        internal static string INFO_CMD_EXTRACTEXAMPLE1 {
            get {
                return ResourceManager.GetString("INFO_CMD_EXTRACTEXAMPLE1", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to import /p [path] [optional:/f [filename]].
        /// </summary>
        internal static string INFO_CMD_IMPORT {
            get {
                return ResourceManager.GetString("INFO_CMD_IMPORT", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Imports all messages from source file to destination queue. If name of the file was not provided msmqmng will search current folder for the file named equally to the queue name with &apos;.xml&apos; extension..
        /// </summary>
        internal static string INFO_CMD_IMPORTDESC {
            get {
                return ResourceManager.GetString("INFO_CMD_IMPORTDESC", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to import /p .\private$\MSMQStudioQueue.
        /// </summary>
        internal static string INFO_CMD_IMPORTEXAMPLE0 {
            get {
                return ResourceManager.GetString("INFO_CMD_IMPORTEXAMPLE0", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to import /p .\private$\MSMQStudioQueue /f C:\QueueData\msmqexport.xml.
        /// </summary>
        internal static string INFO_CMD_IMPORTEXAMPLE1 {
            get {
                return ResourceManager.GetString("INFO_CMD_IMPORTEXAMPLE1", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to list [optional:/h [host]] [optional:/u [domain\username]] [optional:/p [password]].
        /// </summary>
        internal static string INFO_CMD_LIST {
            get {
                return ResourceManager.GetString("INFO_CMD_LIST", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Displays list of public queues on the specified host. If host is not provided displays queues for the local machine. If remote host requires different set of credential they can be provided with /u and /p..
        /// </summary>
        internal static string INFO_CMD_LISTDESC {
            get {
                return ResourceManager.GetString("INFO_CMD_LISTDESC", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to list.
        /// </summary>
        internal static string INFO_CMD_LISTEXAMPLE0 {
            get {
                return ResourceManager.GetString("INFO_CMD_LISTEXAMPLE0", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to list /h remotehost.
        /// </summary>
        internal static string INFO_CMD_LISTEXAMPLE1 {
            get {
                return ResourceManager.GetString("INFO_CMD_LISTEXAMPLE1", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to list /h remotehost /u workgroup\jdoe /p SuCCeSS$1M!.
        /// </summary>
        internal static string INFO_CMD_LISTEXAMPLE2 {
            get {
                return ResourceManager.GetString("INFO_CMD_LISTEXAMPLE2", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Notes:
        ///* If working with private local queues, short version of fully qualified name can be used, for example:
        ///	instead of: 
        ///		copy /s .\private$\sourceQueue /d .\private$\destinationQueue, or
        ///		send /p .\private$\dQueue /m text
        ///	commands can be run as following:
        ///		copy /s sourceQueue /d destinationQueue
        ///		send /p dQueue /m text
        ///
        ///
        ///* Local and remote queue names can be specified as following:  
        ///	.\MSMQStudioQueue
        ///		References a public queue MSMQStudioQueue on the local machine.
        ///	serverXYZ\MSMQSt [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string INFO_CMD_NOTES {
            get {
                return ResourceManager.GetString("INFO_CMD_NOTES", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to peek /p [path] [optional: /c [count]].
        /// </summary>
        internal static string INFO_CMD_PEEK {
            get {
                return ResourceManager.GetString("INFO_CMD_PEEK", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Displays body of the [count] messages referenced by [path], does not remove messages from the queue. Operation stops when either end of queue or [count] were reached. If count was not specified displays ALL messages in the queue..
        /// </summary>
        internal static string INFO_CMD_PEEKDESC {
            get {
                return ResourceManager.GetString("INFO_CMD_PEEKDESC", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to peek /p .\private$\MSMQStudioQueue /c 5.
        /// </summary>
        internal static string INFO_CMD_PEEKEXAMPLE0 {
            get {
                return ResourceManager.GetString("INFO_CMD_PEEKEXAMPLE0", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to peek /p FormatName:Direct=TCP:127.0.0.1\private$\MSMQStudioQueue.
        /// </summary>
        internal static string INFO_CMD_PEEKEXAMPLE1 {
            get {
                return ResourceManager.GetString("INFO_CMD_PEEKEXAMPLE1", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to purge /p [path].
        /// </summary>
        internal static string INFO_CMD_PURGE {
            get {
                return ResourceManager.GetString("INFO_CMD_PURGE", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Removes ALL messages from the queue referenced by path. Does not ask for confirmation..
        /// </summary>
        internal static string INFO_CMD_PURGEDESC {
            get {
                return ResourceManager.GetString("INFO_CMD_PURGEDESC", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to purge /p .\private$\MSMQStudioQueue.
        /// </summary>
        internal static string INFO_CMD_PURGEEXAMPLE0 {
            get {
                return ResourceManager.GetString("INFO_CMD_PURGEEXAMPLE0", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to send /p [path] [opitonal: /c [count]] [/m [message] |  /f [filepath]].
        /// </summary>
        internal static string INFO_CMD_SEND {
            get {
                return ResourceManager.GetString("INFO_CMD_SEND", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Sends message in the queue referenced by path. With either text entered after &quot;/m&quot; or read from file referenced by filepath. Double quote escaping is not supported at this time. For file &quot;/f&quot; version of command entire file will be sent. If /c parameter was provided message duplicated count times..
        /// </summary>
        internal static string INFO_CMD_SENDDESC {
            get {
                return ResourceManager.GetString("INFO_CMD_SENDDESC", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to send /p .\private$\MSMQStudioQueue /m &quot;the text to be sent&quot;.
        /// </summary>
        internal static string INFO_CMD_SENDEXAMPLE0 {
            get {
                return ResourceManager.GetString("INFO_CMD_SENDEXAMPLE0", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to send /p .\private$\MSMQStudioQueue /f \\folder01\file01.ext.
        /// </summary>
        internal static string INFO_CMD_SENDEXAMPLE1 {
            get {
                return ResourceManager.GetString("INFO_CMD_SENDEXAMPLE1", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to send /p .\public$\MSMQStudioQueue /c 5 /f X:\folder01\file01.ext.
        /// </summary>
        internal static string INFO_CMD_SENDEXAMPLE2 {
            get {
                return ResourceManager.GetString("INFO_CMD_SENDEXAMPLE2", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Command cache is empty..
        /// </summary>
        internal static string INFO_COMMANDCACHEISEMPTY {
            get {
                return ResourceManager.GetString("INFO_COMMANDCACHEISEMPTY", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to End of batch file..
        /// </summary>
        internal static string INFO_ENDOFBATCHFILE {
            get {
                return ResourceManager.GetString("INFO_ENDOFBATCHFILE", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Command &apos;{0}&apos; is invalid or no help available for the command..
        /// </summary>
        internal static string INFO_INVALID_COMMNAD {
            get {
                return ResourceManager.GetString("INFO_INVALID_COMMNAD", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to MSMQ Management Console {0}.
        /// </summary>
        internal static string INFO_LAUNCHINFO {
            get {
                return ResourceManager.GetString("INFO_LAUNCHINFO", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Failed to parse command {0}, from command file: {1}. Ingnoring file instruction, none will be executed..
        /// </summary>
        internal static string WARN_FAILEDTOPARSE {
            get {
                return ResourceManager.GetString("WARN_FAILEDTOPARSE", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Required parameter &apos;{0}&apos; is missing..
        /// </summary>
        internal static string WARN_PARAM_ISMISSING {
            get {
                return ResourceManager.GetString("WARN_PARAM_ISMISSING", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Value for the parameter {0} is missing..
        /// </summary>
        internal static string WARN_PARAM_VALUEISMISSING {
            get {
                return ResourceManager.GetString("WARN_PARAM_VALUEISMISSING", resourceCulture);
            }
        }
    }
}
