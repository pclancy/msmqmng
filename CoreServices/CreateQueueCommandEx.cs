using System;
using System.Collections.Generic;
using System.Text;
using System.Messaging;

namespace CoreServices
{
    public class CreateQueueCommandEx : QueueCommandEx
    {
        public bool Transactional { get; set; }

        public CreateQueueCommandEx(string path, bool transactional) : base()
        {
            this.Path = path;
            this.Transactional = transactional;
        }

        protected internal override bool First()
        {
            try
            {
                _queue = MessageQueue.Create(Path, Transactional);

                return true;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, Resource.ERR_UNABLECREATEMSMQ, Path, ex.Message);

                return false;
            }
        }
    }
}
