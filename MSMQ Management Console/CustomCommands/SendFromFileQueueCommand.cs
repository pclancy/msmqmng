using System;
using System.Collections.Generic;
using System.Text;
using CoreServices;
using System.IO;
using System.Messaging;

namespace MSMQManagementConsole
{
    class SendFromFileQueueCommand : SendMessageCommandEx
    {
        public string FileName { get; set; }

        public SendFromFileQueueCommand(string path, string fileName, int count)
            : base(path, count)
        {
            FileName = fileName;
        }

        protected override bool First()
        {
            if (!File.Exists(FileName))
            {
                Logger.LogError(null, Resource.ERR_FILENOTFOUND, FileName);

                return false;
            }

            using (StreamReader reader = new StreamReader(FileName))
            {
                Message =new Message(reader.ReadToEnd());
            }

            return base.First();
        }
    }
}
