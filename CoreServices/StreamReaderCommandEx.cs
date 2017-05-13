using System.IO;
using System.Messaging;
using System.Xml;

namespace CoreServices
{
    /// <summary>
    /// Reads previously generated export files. Base class for import command.
    /// </summary>
    public abstract class StreamReaderCommandEx : CommandBaseEx
    {
        private XmlTextReader _reader;

        protected string _filename;

        public StreamReaderCommandEx(string fileName)
        {
            _filename = fileName;
        }

        protected internal override bool First()
        {
            if (!File.Exists(_filename)) return false;

            _complete = false;

            _reader = new XmlTextReader(_filename);

            return Run(true);
        }

        protected internal override bool Next()
        {
            return Run(false);
        }

        private bool Run(bool first)
        {
            bool status;
            while ((status = _reader.Read()) && !(_reader.NodeType == XmlNodeType.Element && _reader.Name == "message")) { }

            if (status & _reader.Read())
            {
                Message = new Message(_reader.Value);

                return true;
            }

            _reader.Close();

            _complete = true;

            return true;
        }
    }
}
