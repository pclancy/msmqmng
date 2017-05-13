using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace CoreServices
{
    /// <summary>
    /// Decorator for Peek | Read commands, adds capability of saving messages to file, thus opening possibility for two flavors of Export command.
    /// </summary>
    public class StreamWriterCommandEx : CommandBaseEx, IDisposable
    {
        private XmlTextWriter _writer;

        protected string _filename;
        protected QueueCommandEx _sourceCommand;

        public StreamWriterCommandEx(string fileName, QueueCommandEx source)
        {
            _filename = fileName;
            _sourceCommand = source;
        }

        ~StreamWriterCommandEx()
        {
            Dispose();
        }

        public void Dispose()
        {
            if (_sourceCommand != null)
            {
                IDisposable dispose = _sourceCommand as IDisposable;
                if (dispose != null) dispose.Dispose();
            }
        }

        protected internal override bool First()
        {
            _complete = false;

            bool status = Run(true);

            //If it got here _writer is already opened and needs to be closed, even if Next method on the sourceCommand has failed
            if (!status || _sourceCommand.Complete())
            {
                _writer.WriteEndElement();
                _writer.WriteEndDocument();
                _writer.Close();

                //Flag this command as complete
                _complete = true;
            }

            return status;
        }

        protected internal override bool Next()
        {
            bool status = Run(false);

            //If it got here _writer is already opened and needs to be closed, even if Next method on the sourceCommand has failed
            if (!status || _sourceCommand.Complete())
            {
                _writer.WriteEndElement();
                _writer.WriteEndDocument();
                _writer.Close();

                //Flag this command as complete
                _complete = true;
            }

            return status;
        }

        public bool Run(bool first)
        {
            if (first)
            {
                if (!_sourceCommand.First()) return false;

                _writer = new XmlTextWriter(_filename, Encoding.UTF8);
                _writer.Formatting = Formatting.Indented;       // Make the output nicely formatted
                _writer.WriteStartDocument();
                _writer.WriteStartElement("messages");
                _writer.WriteAttributeString("queue", _sourceCommand.Path);
            }
            else
            {
                if (!_sourceCommand.Next()) return false;

                if (_sourceCommand.Complete()) return true;
            }

            //While source returns output save to file
            Message = _sourceCommand.Message;

            // Don't attempt to work with the message if we didn't get one
            if (Message != null)
            {
                _writer.WriteStartElement("message");
                _writer.WriteAttributeString("label", Message.Label);
                _writer.WriteAttributeString("id", Message.Id);
                _writer.WriteAttributeString("sent", Message.SentTime.ToString("yyyy-MM-dd HH:mm:ss"));
                //_writer.WriteAttributeString("sourcemachine", Message.SourceMachine);
                _writer.WriteCData(Message.Body.ToString());
                _writer.WriteEndElement();
            }

            return true;
        }
    }
}
