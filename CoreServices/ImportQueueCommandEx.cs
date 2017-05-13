using System;
using System.Collections.Generic;
using System.Text;

namespace CoreServices
{
    public class ImportQueueCommandEx : StreamReaderCommandEx
    {
        public ImportQueueCommandEx(string filename, string queuename) : base(filename)
        {
            if (filename == null)
                _filename = string.Format("{0}.xml", queuename.Substring(queuename.LastIndexOf('\\') + 1));
            else
                _filename = filename;

            base.AddChild(new SendMessageCommandEx(queuename, (int?)null));
        }
    }
}
