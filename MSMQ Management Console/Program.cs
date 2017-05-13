using System;
using System.Diagnostics;
using System.Reflection;
using CoreServices;

namespace MSMQManagementConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(string.Format(Resource.INFO_LAUNCHINFO, Assembly.GetExecutingAssembly().GetName().Version));

            //If no command line parameters were used will be working in user mode, otherwise will execute command and exit

            bool exit = args.Length > 0;
            var envcmd = string.Join(" ", args);

            //int origWidth = 0;
            //int origHeight = 0;

            //if not in interactive mode dont change Console window size
            //if (!exit)
            //{
            //    origWidth = Console.WindowWidth;
            //    origHeight = Console.WindowHeight;

            //    if (Console.WindowWidth < 100)
            //        Console.SetWindowSize(100, 30);
            //}

            Run(envcmd, exit);

            //if (origWidth != 0)
            //    Console.SetWindowSize(origWidth, origHeight);

        }

        static void Run(string commandline, bool exit)
        {
            do
            {
                Console.Write("MSMQ>");

                string strCommand;

                if (exit) //If command line was supplied read from there
                {
                    strCommand = commandline;
                    Console.WriteLine(commandline);
                    exit = true;
                }
                else
                {
                    strCommand = Console.ReadLine().Trim();

                    //Skip if empty line
                    if (strCommand == "") continue;
                }

                //When extracted into method allows for unit testig
                exit = exit | Parse(strCommand);
            } while (!exit);
        }

        private static bool Parse(string strCommand)
        {
            string[] args = CommandLineParser.Parse(strCommand);

            if (args.Length != 0)
            {
                switch (args[0].ToLower())
                {
                    case ControlCommands.ExitCommand: return true;
                    case ControlCommands.HelpCommand: HelpClass.DisplayCommands(); break;
                    default:

                        CommandBaseEx command = null;

                        try
                        {
                            command = CommandLineParser.ParseQueueCommandEx(args);
                        }
                        catch (Exception ex)
                        {
                            Logger.LogError(ex, Resource.ERR_UNEXPECTEDERROR);
                        }

                        if (command != null)
                        {
                            //Measure execution time for each command
                            Stopwatch stopwatch = Stopwatch.StartNew();

                            bool status = CommandBaseEx.Run(command);

                            stopwatch.Stop();

                            ConsoleColor originalColor = Console.ForegroundColor;

                            Console.ForegroundColor = status ? ConsoleColor.White : ConsoleColor.Red;
                            Console.WriteLine(status ? "Complete in {0}" : "Failed after {0}", stopwatch.Elapsed);

                            Console.ForegroundColor = originalColor;
                        }

                        //If command supports IDisposable, as most of them do, dispose it
                        IDisposable dispose = command as IDisposable;
                        if (dispose != null) dispose.Dispose();

                        break;
                }
            }

            return false;
        }
    }
}
