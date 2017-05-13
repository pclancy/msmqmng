using System;
using System.Collections.Generic;
using System.Text;
using CoreServices;
using System.Messaging;
using System.IO;

namespace MSMQManagementConsole
{
    static class CommandLineParser
    {
        private const string QUEUENAME_KEY = "/p";
        private const string COUNT_KEY = "/c";
        private const string TRANSACTIONAL_KEY = "/t";
        private const string COPYSOURCE_KEY = "/s";
        private const string COPYDESTINATION_KEY = "/d";
        private const string SENDMESSAGE_KEY = "/m";
        private const string FILENAME_KEY = "/f";
        private const string HOSTNAME_KEY = "/h";
        private const string USERNAME_KEY = "/u";
        private const string PASSWORD_KEY = "/p";

        public static CommandBaseEx ParseQueueCommandEx(string[] args)
        {
            if (args.Length > 1 && args[1].ToLower() == ControlCommands.HelpCommand) //Display help
            {
                HelpClass.DisplayCommandHelp(args[0]);

                return null;
            }

            //Check for common optional parameters
            // /c - count
            int? count = null;
            if (GetStringForKey(args, COUNT_KEY, false) != null && (count = GetIntForKey(args, COUNT_KEY)) == null) return null;

            // /f - file name
            string filename = GetStringForKey(args, FILENAME_KEY, false);

            CommandBaseEx command = null;
            string qname;

            switch (args[0].ToLower())
            {
                case QueueCommands.CreateCommand: command = (qname = GetQueueName(args, QUEUENAME_KEY)) == null ? null : new CreateQueueCommandEx(qname, GetKeyIndex(args, TRANSACTIONAL_KEY) != -1); break;
                case QueueCommands.DeleteCommand: command = (qname = GetQueueName(args, QUEUENAME_KEY)) == null ? null : new DeleteQueueCommandEx(qname); break;
                case QueueCommands.ExportCommand: command = (qname = GetQueueName(args, QUEUENAME_KEY)) == null ? null : new ExportQueueCommandEx(qname, filename); break;
                case QueueCommands.ExtractCommand: command = (qname = GetQueueName(args, QUEUENAME_KEY)) == null ? null : new ExtractQueueCommandEx(qname, filename); break;
                case QueueCommands.ImportCommand: command = (qname = GetQueueName(args, QUEUENAME_KEY)) == null ? null : new ImportQueueCommandEx(filename, qname); break;
                case QueueCommands.PurgeCommand: command = (qname = GetQueueName(args, QUEUENAME_KEY)) == null ? null : new PurgeQueueCommandEx(qname); break;
                case QueueCommands.PeekCommand: command = (qname = GetQueueName(args, QUEUENAME_KEY)) == null ? null : new PeekToConsoleQueueCommand(qname, count == 0 || count == null ? (int?)null : (int)count); break;
                case QueueCommands.ReadCommand: command = (qname = GetQueueName(args, QUEUENAME_KEY)) == null ? null : new ReadQueueCommandEx(qname, count == 0 || count == null ? (int?)null : count); break;
                case QueueCommands.ListCommand: command = DecodeListCommand(args); break;
                case QueueCommands.SendCommand: command = DecodeSendCommand(args); break;
                case QueueCommands.CopyCommand: command = DecodeCopyCommand(args); break;
                case ControlCommands.LoadCommand: command = DecodeLoadCommand(args); break;
                default: HelpClass.DisplayInvalidCommand(args[0]); break;
            }

            return command;
        }

        private static CommandBaseEx DecodeLoadCommand(string[] args)
        {
            string filename = GetStringForKey(args, FILENAME_KEY, true);

            if (filename != null && !File.Exists(filename))
            {
                Logger.LogWarn(Resource.ERR_FILENOTFOUND, filename);
                
                return null;
            }

            return new LoadFileCommand(filename);
        }

        public static string[] Parse(string commandLine)
        {
            //Rules: 
            //  1. parameters are separated with spaces
            //  2. if parameter is a string and has spaces in it, it must be enclosed in double quotes

            if (commandLine == null || string.IsNullOrEmpty(commandLine)) return new string[] { }; //return empty

            List<string> parameters = new List<string>();
            string parameter = null;
            bool enclosed = false;

            foreach (char c in commandLine)
            {
                //If we reached space and we are not currently enclosed in double quotes 
                // and this is not an extra space which should be ignored
                if (c == ' ' && !enclosed && !string.IsNullOrEmpty(parameter))
                {
                    parameters.Add(parameter);
                    parameter = null;
                }
                else if (c == '"')
                {
                    if (enclosed)
                    {
                        parameters.Add(parameter);
                        parameter = null;
                    }

                    enclosed = !enclosed;
                }
                else if (!enclosed & c != ' ' || enclosed)
                {
                    parameter += c;
                }
            }

            if (!string.IsNullOrEmpty(parameter)) parameters.Add(parameter);

            return parameters.ToArray();
        }

        private static int GetKeyIndex(string[] args, string key)
        {
            for (int i = 0; i < args.Length; i++)
            {
                if (args[i] == key) return i;
            }

            return -1;
        }

        private static string GetStringForKey(string[] args, string key, bool required)
        {
            int i = GetKeyIndex(args, key);

            if (required & i == -1)
            {
                Logger.LogWarn(Resource.WARN_PARAM_ISMISSING, key);

                return null;
            }

            if (i != -1 && i + 1 < args.Length) return args[i + 1];
            else
            {
                if (required)
                    Logger.LogWarn(Resource.WARN_PARAM_VALUEISMISSING, key);

                return null;
            }
        }

        private static int? GetIntForKey(string[] args, string key)
        {
            string str = GetStringForKey(args, key, false);
            int result = -1;

            if (!int.TryParse(str, out result))
            {
                //Failed to convert error
                Console.WriteLine(string.Format(Resource.ERR_FAILEDTOCONVERTTOINT, str, key));

                return null;
            }
            else
                return result;
        }

        //returns queue name if name provided was not fully qualified name makes it fully qualified by adding ".\private$\"
        private static string GetQueueName(string[] args, string key)
        {
            string path = GetStringForKey(args, key, true);

            if (path != null && path.IndexOf(".\\") != 0 && path.ToLower().IndexOf("formatname:direct") != 0) path = ".\\private$\\" + path;

            return path;
        }

        private static QueueCommandEx DecodeCopyCommand(string[] args)
        {
            /*
             * copy /s [source path] /d [destination path] 
             */
            string source = GetQueueName(args, COPYSOURCE_KEY);
            if (source == null) return null;

            string destination = GetQueueName(args, COPYDESTINATION_KEY);
            if (destination == null) return null;

            int? count = null;
            if (GetStringForKey(args, COUNT_KEY, false) != null && (count = GetIntForKey(args, COUNT_KEY)) == null) return null;

            return new CopyQueueCommandEx(source, destination, count);
        }

        private static QueueCommandEx DecodeSendCommand(string[] args)
        {
            /*
             * send /p [path] [opitonal: /c [count]] [/m [message] |  /f [filepath]]
             */

            string queuename = GetQueueName(args, QUEUENAME_KEY);
            if (queuename == null) return null;

            int? count = null;
            if (GetStringForKey(args, COUNT_KEY, false) != null && (count = GetIntForKey(args, COUNT_KEY)) == null) return null;
            //If count provided was 0, changing to one to execute at least once.
            if (count == 0) count = 1;

            string commandtype = null;
            string messagedata = GetStringForKey(args, SENDMESSAGE_KEY, false);
            if (messagedata == null)
            {
                messagedata = GetStringForKey(args, FILENAME_KEY, false);
                if (messagedata == null)
                {
                    Console.WriteLine(string.Format(Resource.WARN_PARAM_ISMISSING, string.Format("{0} | {1}", SENDMESSAGE_KEY, FILENAME_KEY)));
                    return null;
                }
                else commandtype = FILENAME_KEY;
            }
            else commandtype = SENDMESSAGE_KEY;

            switch (commandtype)
            {
                case FILENAME_KEY: return new SendFromFileQueueCommand(queuename, messagedata, count == null ? 1 : (int)count);
                default: //"text"
                    SendMessageCommandEx command = new SendMessageCommandEx(queuename, count == null ? 1 : (int)count);
                    command.Message = new Message(messagedata);

                    return command;
            }
        }

        private static CommandBaseEx DecodeListCommand(string[] args)
        {
            /*
             * list [optional:/h [host]] [optional:/u [domain\username]] [optional:/p [password]]
             */

            string host = GetStringForKey(args, HOSTNAME_KEY, false);

            ListQueuesCommand command = new ListQueuesCommand(host);

            string userName = GetStringForKey(args, USERNAME_KEY, false);

            if (!string.IsNullOrEmpty(userName))
            {
                string[] user = userName.Split('\\');

                //Add domain if was provided
                if (user.Length > 1)
                {
                    command.Domain = user[0];
                    command.UserName = user[1];
                }
                else
                    command.UserName = userName;

                command.Password = GetStringForKey(args, PASSWORD_KEY, false);
            }

            return command;
        }

    }
}
