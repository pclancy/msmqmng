using System;
using System.Collections.Generic;
using System.Text;

namespace MSMQManagementConsole
{
    class HelpClass
    {
        public static void DisplayCommands()
        {
            foreach (string command in QueueCommands.commands)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(Resource.ResourceManager.GetString(string.Format("INFO_CMD_{0}", command.ToUpper())));

                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine(string.Format("\t{0}\n",
                    Resource.ResourceManager.GetString(string.Format("INFO_CMD_{0}DESC", command.ToUpper()))));
            }

            Console.WriteLine(string.Format("{0}\n\n", Resource.INFO_CMD_NOTES));
        }

        public static bool DisplayInvalidCommand(string command)
        {
            string help = Resource.ResourceManager.GetString(string.Format("INFO_CMD_{0}", command.ToUpper()));

            if (help == null)
            {
                Console.WriteLine(string.Format(Resource.INFO_INVALID_COMMNAD, command));

                return false;
            }

            return true;
        }

        public static void DisplayCommandHelp(string command)
        {
            if (!DisplayInvalidCommand(command)) return;

            command = command.ToUpper();

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(Resource.ResourceManager.GetString(string.Format("INFO_CMD_{0}", command)));

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(string.Format("\t{0}\n",
                Resource.ResourceManager.GetString(string.Format("INFO_CMD_{0}DESC", command))));

            Console.WriteLine(Resource.INFO_CMD_EXAMPLE);
            string example;
            for (int i = 0; i < 3; i++)
            {
                example = Resource.ResourceManager.GetString(string.Format("INFO_CMD_{0}EXAMPLE{1}", command, i));

                if (example != null)
                    Console.WriteLine(string.Format("\t{0}", example));
            }
        }
    }
}
