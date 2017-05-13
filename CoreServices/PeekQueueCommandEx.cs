using System;
using System.Collections.Generic;
using System.Text;
using System.Messaging;

namespace CoreServices
{
    public class PeekQueueCommandEx : QueueCommandEx, IDisposable
    {
        private Cursor _cursor = null;
        private long _messagesRead = 0;

        protected string errorMessage;
        protected TimeSpan _timeout = TimeSpan.Zero;

        public int? Count { get; set; }

        public PeekQueueCommandEx(string path, int? count)
        {
            Path = path;

            _queue = new MessageQueue(path);

            // Ensure that we can read all properties of the message
            _queue.MessageReadPropertyFilter.SetAll();

            Count = count;

            errorMessage = Resource.ERR_UNABLETOPEEK;
        }

        protected internal override bool First()
        {
            try
            {
                _messagesRead = 0;
                _complete = false;

                _cursor = _queue.CreateCursor();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, errorMessage, _queue == null ? "n/a" : Path, ex.Message);

                return false;
            }

            return Run(PeekAction.Current);
        }

        protected internal override bool Next()
        {
            return Run(PeekAction.Next);
        }

        protected virtual Message Read(int param)
        {
            return _queue.Peek(_timeout, _cursor, (PeekAction)param);
        }

        private bool Run(PeekAction action)
        {
            try
            {
                Message = Read((int)action);

                if (Message != null)
                {
                    _messagesRead++;
                }

                return true;
            }
            catch (MessageQueueException ex)
            {
                //If there were no more messages to read this exception will be thrown at which point command execution can be considered complete
                if (ex.MessageQueueErrorCode == MessageQueueErrorCode.IOTimeout)
                {
                    _complete = true; //Update status to complete

                    _cursor.Close();

                    return true; //We are done at this point
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, errorMessage, Path, ex.Message);

                return false;
            }
        }

        protected internal override bool Complete()
        {
            //True if status is complete or requried number of messages was read
            if (_complete || Count != null && Count == _messagesRead) return true;

            return false;
        }
    }
}
