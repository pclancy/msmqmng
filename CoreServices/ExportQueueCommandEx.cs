using System;
using System.Collections.Generic;
using System.Text;

namespace CoreServices
{
    /// <summary>
    /// Exports messages to file leaving original messages in the queue.
    /// </summary>
    public class ExportQueueCommandEx : StreamWriterCommandEx
    {
        public string SourcePath
        {
            get { return (_sourceCommand as QueueCommandEx).Path; }
        }

        public ExportQueueCommandEx(string sourceQueue, string filename)
            : base(filename, new PeekQueueCommandEx(sourceQueue, (int?)null))
        {
            if (filename == null)
                _filename = string.Format("{0}.xml", sourceQueue.Substring(sourceQueue.LastIndexOf('\\') + 1));
            else
                _filename = filename;
        }
    }
}
