using System;
using System.Collections.Generic;
using System.Text;

namespace CoreServices
{
    /// <summary>
    /// Exports messages to file and deletes the messages from the queue.
    /// </summary>
    public class ExtractQueueCommandEx : StreamWriterCommandEx
    {
        public string SourcePath
        {
            get { return (_sourceCommand as QueueCommandEx).Path; }
        }

        public ExtractQueueCommandEx(string sourceQueue, string filename)
            : base(filename, new ReadQueueCommandEx(sourceQueue, (int?)null))
        {
            if (filename == null)
                _filename = string.Format("{0}.xml", sourceQueue.Substring(sourceQueue.LastIndexOf('\\') + 1));
            else
                _filename = filename;
        }
    }
}
