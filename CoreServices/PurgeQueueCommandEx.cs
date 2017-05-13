using System;
using System.Collections.Generic;
using System.Text;
using System.Messaging;

namespace CoreServices
{
    /// <summary>
    /// Purges a queue referenced by Path.
    /// </summary>
    public class PurgeQueueCommandEx : CommandBaseEx
    {
        public string Path { get; set; }

        public PurgeQueueCommandEx(string path)
        {
            this.Path = path;
        }

        protected internal override bool First()
        {
            try
            {
                MessageQueue queue = new MessageQueue(Path);

                queue.Purge();
                queue.Dispose();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, Resource.ERR_UNABLEPURGE, Path, ex.Message);

                //Failed
                return false;
            }

            //Complete successfully
            return true;
        }
    }
}
