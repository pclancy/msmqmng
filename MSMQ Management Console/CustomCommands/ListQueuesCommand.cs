using System;
using System.Collections.Generic;
using System.Text;
using CoreServices;
using System.Messaging;

namespace MSMQManagementConsole
{
    class ListQueuesCommand : EnumerateQueuesCommandEx
    {
        public ListQueuesCommand(string machineName) : base(machineName) { }

        protected override bool First()
        {
            bool status = base.First();

            if (Queues != null && Queues.Count > 0)
            {
                string tableTitle = "Msg. count  | Name";
                string tableRowFormat = "{0}  | {1}";

                Console.WriteLine(tableTitle);

                foreach (QueueInfo queueinfo in Queues)
                {
                    Console.WriteLine(tableRowFormat, queueinfo.MessageCount.ToString().PadLeft(10), queueinfo.QueueName);
                }
            }

            return status;
        }
    }
}
