using System;
using System.Collections.Generic;
using System.Text;

namespace CoreServices
{
    public class CopyQueueCommandEx : PeekQueueCommandEx
    {
        /// <param name="count">If value is (int?)null all messages from the source queue will be copied</param>
        public CopyQueueCommandEx(string sourceQueue, string destinationQueue, int? count)
            : base(sourceQueue, count)
        {
            this.AddChild(new SendMessageCommandEx(destinationQueue, (int?)null));
        }

        //Need to move to one of the base classes
        //public override void Dispose()
        //{
        //    base.Dispose();

        //    sendCommand.Dispose();
        //}
    }
}
