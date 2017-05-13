using System;
using System.Collections.Generic;
using System.Text;
using System.Messaging;

namespace CoreServices
{
    public class SendMessageCommandEx : QueueCommandEx
    {
        private int? count;

        public int? Count 
        {
            get { return count; }
        }
   
        /// <summary>
        /// 
        /// </summary>
        /// <param name="path">Queue name</param>
        /// <param name="count">Count of messages to be send, if null one message will be sent.</param>
        public SendMessageCommandEx(string path, int? count)
        {
            Path = path;

            _queue = new MessageQueue(path);

            this.count = count == (int?)null ? 1 : count;
        }

        protected internal override bool First()
        {
            try
            {
                //In order to preserve value of count will use another variable
                int interations = (int)Count;

                while (interations-- > 0)
                {
                    if (_queue.Transactional)
                        _queue.Send(this.Message, MessageQueueTransactionType.Single);
                    else
                        _queue.Send(this.Message);
                }

                return true;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, Resource.ERR_UNABLETOSENDMESSAGE, _queue == null ? "n/a" : Path, ex.Message);

                return false;
            }
        }
    }
}
