using System;
using System.Collections.Generic;
using System.Text;
using System.Messaging;

namespace CoreServices
{
    public class ReadQueueCommandEx : PeekQueueCommandEx
    {
        public ReadQueueCommandEx(string path, int? count) : base(path, count) 
        {
            errorMessage = Resource.ERR_UNABLETOREAD;
        }

        protected override Message Read(int param)
        {
            return _queue.Receive(_timeout);
        }
    }
   
}
