using System;
using System.Collections.Generic;
using System.Text;
using System.Messaging;

namespace CoreServices
{
    public abstract class QueueCommandEx : CommandBaseEx, IDisposable
    {
        protected MessageQueue _queue;

        public string Path { get; set; }

        ~QueueCommandEx()
        {
            Dispose();
        }

        public virtual void Dispose()
        {
            if (_queue != null)
            {
                _queue.Dispose();
                _queue = null;
            }
        }
    }
}
