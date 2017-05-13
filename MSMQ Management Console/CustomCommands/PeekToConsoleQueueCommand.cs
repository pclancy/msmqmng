using System;
using System.Collections.Generic;
using System.Text;
using CoreServices;

namespace MSMQManagementConsole
{
    class PeekToConsoleQueueCommand : PeekQueueCommandEx
    {
        public PeekToConsoleQueueCommand(string path, int? count) : base(path, count) { }

        protected override bool First()
        {
            bool status = base.First();

            //If the queue was empty but Peek command was attempted this will throw an exception
            //Need to check if command was complete.
            if (status && !_complete)
                Console.WriteLine(Message.Body);

            return status;
        }

        protected override bool Next()
        {
            bool status = base.Next();

            if (status && !_complete)
                Console.WriteLine(Message.Body);

            return status;
        }
    }
}
