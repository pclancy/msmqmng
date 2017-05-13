using System;
using System.Collections.Generic;
using System.Text;
using System.Messaging;

namespace CoreServices
{
    public abstract class CommandBaseEx
    {
        //Collection of child commands
        private List<CommandBaseEx> _children = null;
        private Message _message;

        //Protected complete property, to be used to indicate completion of traversal
        protected bool _complete = true;
        //Because there is no requirement to support more that one creating PlainTextFormatter here
        protected IMessageFormatter _formatter = new PlainTextFormatter();

        //Each command will operate on a message if applicable, if not property will not be initialized
        public virtual Message Message
        {
            get
            {
                if (_message != null) _message.Formatter = _formatter;

                return _message;
            }

            set
            {
                _message = value;

                if (_message != null) _message.Formatter = _formatter;
            }
        }

        public CommandBaseEx()
        {
            _children = new List<CommandBaseEx>();
        }

        public void AddChild(CommandBaseEx command)
        {
            _children.Add(command);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public static bool Run(CommandBaseEx command)
        {
            //If First step of iteration failed return failure
            if (!command.Exec(true)) return false;

            //Iterate while complete (one steps commands wont even enter the loop)
            while (!command.Complete())
            {
                //Run Next, return false if failed
                if (!command.Exec(false)) return false;
            }

            //Return true if complete successfully
            return true;
        }

        /// <summary>
        /// When overriden, indicates if iterator must stop traversing. Applicable for iterative commands only.
        /// </summary>
        /// <returns>Must return True if traversal complete, otherwise False. No need to override for non-iterative commands.</returns>
        protected internal virtual bool Complete() { return _complete; }

        protected internal abstract bool First();
        protected internal virtual bool Next() { return false; }

        private bool Exec(bool first)
        {
            if (first)
            {
                //If First step of iteration failed, stop & return false
                if (!First()) return false;
            }
            else
            {
                //If one of the subsequent steps of iteration failed, stop & return false
                if (!Next()) return false;

                //Peek command has no way of knowing that it has reached end of queue until it tries to read next message
                //therefore even though Next method returns true indicating that command was complete successfully, 
                //but no message was actually read, for this case need to check if command has changed its status to Complete
                //and return true if it did, in order to avoid execution of child commands one extra time
                if (_complete) return true; //TDB Use _comlpete or Complete()?
            }

            //Iterate over children and execute all for each iteration of the parent
            foreach (CommandBaseEx command in _children)
            {
                //Pass Message object to each child, general case, some commands may not need that
                command.Message = this.Message;

                if (!CommandBaseEx.Run(command)) return false;
            }

            return true;
        }

    }
}
