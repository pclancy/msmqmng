using System;
using System.IO;
using CoreServices;

namespace MSMQManagementConsole
{
    class LoadFileCommand : CommandBaseEx
    {
        string _filename;

        public LoadFileCommand(string filename)
        {
            _filename = filename;
        }

        protected override bool First()
        {
            if (!File.Exists(_filename)) return false;

            using (StreamReader reader = new StreamReader(_filename))
            {
                string strCommand;

                while ((strCommand = reader.ReadLine()) != null)
                {
                    strCommand = strCommand.Trim();

                    //Cutoff comments
                    if (strCommand.IndexOf("//") != -1)
                        strCommand = strCommand.Substring(0, strCommand.IndexOf("//"));

                    //Skip if empty line or comment line
                    if (strCommand == "") continue;

                    //Display command
                    Console.WriteLine(strCommand);

                    string[] parameters = CommandLineParser.Parse(strCommand);

                    if (parameters == null)
                    {
                        Logger.LogWarn(Resource.WARN_FAILEDTOPARSE, strCommand, _filename);

                        return false;
                    }

                    CommandBaseEx command = CommandLineParser.ParseQueueCommandEx(parameters);
                    if (command != null) this.AddChild(command);
                }
            }

            return true;
        }
    }
}
