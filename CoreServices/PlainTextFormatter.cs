using System;
using System.Collections.Generic;
using System.Text;
using System.Messaging;
using System.IO;

namespace CoreServices
{
    public class PlainTextFormatter : IMessageFormatter
    {
        public bool CanRead(Message message)
        {
            return true;
        }

        public object Read(Message message)
        {
            StreamReader reader = new StreamReader(message.BodyStream);

            try
            {
                return reader.ReadToEnd();
            }
            finally
            {
                reader.Close();
            }
        }

        public void Write(Message message, object obj)
        {
            MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes((string)obj));
            message.BodyStream = stream;
        }

        public object Clone()
        {
            throw new NotImplementedException();
        }
    }
}
