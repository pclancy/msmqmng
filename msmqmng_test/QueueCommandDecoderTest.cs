using MSMQManagementConsole;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using CoreServices;
using System.Messaging;

namespace msmqmng_test
{
    /// <summary>
    ///This is a test class for CommandLineParserTest and is intended
    ///to contain all CommandLineParserTest Unit Tests
    ///</summary>
    [TestClass()]
    public class CommandLineParserTest
    {

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion

        string[] Parse(string commandline)
        {
            return CommandLineParser_Accessor.Parse(commandline);
        }

        /// <summary>
        ///A test for DecodeCreateQueue
        ///</summary>
        [TestMethod()]
        [DeploymentItem("msmqmng.exe")]
        public void DecodeCreateQueueTest()
        {
            string args = "create";
            CommandBaseEx actual = CommandLineParser_Accessor.ParseQueueCommandEx(Parse(args));
            Assert.IsNull(actual);

            args = "create ";
            actual = CommandLineParser_Accessor.ParseQueueCommandEx(Parse(args));
            Assert.IsNull(actual);

            args = "create ?";
            actual = CommandLineParser_Accessor.ParseQueueCommandEx(Parse(args));
            Assert.IsNull(actual);

            args = "create /p notapath";
            actual = CommandLineParser_Accessor.ParseQueueCommandEx(Parse(args));
            Assert.IsNotNull(actual);
            Assert.AreEqual(((CreateQueueCommandEx)actual).Path, ".\\private$\\notapath");

            args = "create /p notapath ";
            actual = CommandLineParser_Accessor.ParseQueueCommandEx(Parse(args));
            Assert.IsNotNull(actual);
            Assert.AreEqual(((CreateQueueCommandEx)actual).Path, ".\\private$\\notapath");
            Assert.IsFalse(((CreateQueueCommandEx)actual).Transactional);

            args = "create /p notapath asdf";
            actual = CommandLineParser_Accessor.ParseQueueCommandEx(Parse(args));
            Assert.IsNotNull(actual);

            args = "create /p notapath  /t";
            actual = CommandLineParser_Accessor.ParseQueueCommandEx(Parse(args));
            Assert.IsNotNull(actual);
            Assert.AreEqual(((CreateQueueCommandEx)actual).Path, ".\\private$\\notapath");
            Assert.IsTrue(((CreateQueueCommandEx)actual).Transactional);
        }

        /// <summary>
        ///A test for Decode
        ///</summary>
        [TestMethod()]
        public void DecodeTest()
        {
            //string commandline = string.Empty;
            //IQueueCommand actual = CommandLineParser.ParseQueueCommandEx(Parse(commandline));
            //Assert.IsNull(actual);

            string commandline = "garbage";
            CommandBaseEx actual = CommandLineParser.ParseQueueCommandEx(Parse(commandline));
            Assert.IsNull(actual);

            //Valid command + garbage
            commandline = "create+garbage";
            actual = CommandLineParser.ParseQueueCommandEx(Parse(commandline));
            Assert.IsNull(actual);

            //Valid create command
            commandline = "create /p queue";
            actual = CommandLineParser.ParseQueueCommandEx(Parse(commandline));
            Assert.IsNotNull(actual);

            //Valid delete command
            commandline = "delete /p queue";
            actual = CommandLineParser.ParseQueueCommandEx(Parse(commandline));
            Assert.IsNotNull(actual);

            //Valid purge command
            commandline = "purge /p queue";
            actual = CommandLineParser.ParseQueueCommandEx(Parse(commandline));
            Assert.IsNotNull(actual);

            //Valid list command
            commandline = "list";
            actual = CommandLineParser.ParseQueueCommandEx(Parse(commandline));
            Assert.IsNotNull(actual);

            //Valid send command command
            commandline = "send /p queue /m text";
            actual = CommandLineParser.ParseQueueCommandEx(Parse(commandline));
            Assert.IsNotNull(actual);

            //Valid peek command command
            commandline = "peek /p queue";
            actual = CommandLineParser.ParseQueueCommandEx(Parse(commandline));
            Assert.IsNotNull(actual);

            //Valid copy command command
            commandline = "copy /s queue /d queue";
            actual = CommandLineParser.ParseQueueCommandEx(Parse(commandline));
            Assert.IsNotNull(actual);
        }

        /// <summary>
        ///A test for DecodeCopyCommand
        ///</summary>
        [TestMethod()]
        [DeploymentItem("msmqmng.exe")]
        public void DecodeCopyCommandTest()
        {
            string[] args = "copy".Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            QueueCommandEx actual = CommandLineParser_Accessor.DecodeCopyCommand(args);
            Assert.IsNull(actual);

            args = "copy notapath".Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            actual = CommandLineParser_Accessor.DecodeCopyCommand(args);
            Assert.IsNull(actual);

            args = "copy /s sourcequeue /d destqueue ".Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            actual = CommandLineParser_Accessor.DecodeCopyCommand(args);
            Assert.IsNotNull(actual);
            Assert.AreEqual(".\\private$\\sourcequeue", ((CopyQueueCommandEx)actual).Path);
            //Assert.AreEqual(((CopyQueueCommandEx)actual).DestinationPath, ".\\private$\\destqueue");

            args = "copy /s sourcequeue /d .\\private$\\destqueue garbage".Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            actual = CommandLineParser_Accessor.DecodeCopyCommand(args);
            Assert.IsNotNull(actual);

            args = "copy /s .\\private$\\sourcequeue /d destqueue".Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            actual = CommandLineParser_Accessor.DecodeCopyCommand(args);
            Assert.IsNotNull(actual);
            Assert.AreEqual(((CopyQueueCommandEx)actual).Path, ".\\private$\\sourcequeue");
            //Assert.AreEqual(((CopyQueueCommandEx)actual).DestinationPath, ".\\private$\\destqueue");
        }

        /// <summary>
        ///A test for DecodeDeleteQueue
        ///</summary>
        [TestMethod()]
        [DeploymentItem("msmqmng.exe")]
        public void DecodeDeleteQueueTest()
        {
            string args = "delete";
            CommandBaseEx actual = CommandLineParser_Accessor.ParseQueueCommandEx(Parse(args));
            Assert.IsNull(actual);

            args = "delete ";
            actual = CommandLineParser_Accessor.ParseQueueCommandEx(Parse(args));
            Assert.IsNull(actual);

            args = "delete ?";
            actual = CommandLineParser_Accessor.ParseQueueCommandEx(Parse(args));
            Assert.IsNull(actual);

            args = "delete /p notapath";
            actual = CommandLineParser_Accessor.ParseQueueCommandEx(Parse(args));
            Assert.IsNotNull(actual);
            Assert.AreEqual(((DeleteQueueCommandEx)actual).Path, ".\\private$\\notapath");

            args = "delete /p .\\private$\\notapath ";
            actual = CommandLineParser_Accessor.ParseQueueCommandEx(Parse(args));
            Assert.IsNotNull(actual);
            Assert.AreEqual(((DeleteQueueCommandEx)actual).Path, ".\\private$\\notapath");

            args = "delete /p FormatName:DIRECT=TCP:10.139.209.222\\private$\\notapath garbage";
            actual = CommandLineParser_Accessor.ParseQueueCommandEx(Parse(args));
            Assert.IsNotNull(actual);
            Assert.AreEqual(((DeleteQueueCommandEx)actual).Path, "FormatName:DIRECT=TCP:10.139.209.222\\private$\\notapath");
        }

        /// <summary>
        ///A test for DecodeListCommand
        ///</summary>
        [TestMethod()]
        [DeploymentItem("msmqmng.exe")]
        public void DecodeListCommandTest()
        {
            string args = "list";
            CommandBaseEx actual = CommandLineParser_Accessor.ParseQueueCommandEx(Parse(args));
            Assert.IsNotNull(actual);

            args = "list ";
            actual = CommandLineParser_Accessor.ParseQueueCommandEx(Parse(args));
            Assert.IsNotNull(actual);

            args = "list ?";
            actual = CommandLineParser_Accessor.ParseQueueCommandEx(Parse(args));
            Assert.IsNull(actual);

            args = "list /h 127.0.0.1";
            actual = CommandLineParser_Accessor.ParseQueueCommandEx(Parse(args));
            Assert.IsNotNull(actual);
            Assert.AreEqual(((ListQueuesCommand)actual).MachineName, "127.0.0.1");

            args = "list /h localhost /u domain\\user /p password";
            actual = CommandLineParser_Accessor.ParseQueueCommandEx(Parse(args));
            Assert.IsNotNull(actual);
            Assert.AreEqual("localhost", ((ListQueuesCommand)actual).MachineName);
            Assert.AreEqual("password", ((ListQueuesCommand)actual).Password);
            Assert.AreEqual("domain", ((ListQueuesCommand)actual).Domain);
            Assert.AreEqual("user", ((ListQueuesCommand)actual).UserName);
        }

        /// <summary>
        ///A test for DecodePeekCommand
        ///</summary>
        [TestMethod()]
        [DeploymentItem("msmqmng.exe")]
        public void DecodePeekCommandTest()
        {
            string args = "peek";
            CommandBaseEx actual = CommandLineParser_Accessor.ParseQueueCommandEx(Parse(args));
            Assert.IsNull(actual);

            args = "peek ";
            actual = CommandLineParser_Accessor.ParseQueueCommandEx(Parse(args));
            Assert.IsNull(actual);

            args = "peek ?";
            actual = CommandLineParser_Accessor.ParseQueueCommandEx(Parse(args));
            Assert.IsNull(actual);

            args = "peek /p notapath";
            actual = CommandLineParser_Accessor.ParseQueueCommandEx(Parse(args));
            Assert.IsNotNull(actual);
            Assert.AreEqual(".\\private$\\notapath", ((PeekQueueCommandEx)actual).Path);

            args = "peek /p notapath ";
            actual = CommandLineParser_Accessor.ParseQueueCommandEx(Parse(args));
            Assert.IsNotNull(actual);
            Assert.AreEqual(((PeekQueueCommandEx)actual).Path, ".\\private$\\notapath");

            args = "peek /p notapath /c garbage";
            actual = CommandLineParser_Accessor.ParseQueueCommandEx(Parse(args));
            Assert.IsNull(actual);

            args = "peek /p notapath /c 0";
            actual = CommandLineParser_Accessor.ParseQueueCommandEx(Parse(args));
            Assert.IsNotNull(actual);
            Assert.AreEqual((int?)null, ((PeekQueueCommandEx)actual).Count);

            args = "peek /p .\\private$\\notapath /c 10";
            actual = CommandLineParser_Accessor.ParseQueueCommandEx(Parse(args));
            Assert.IsNotNull(actual);
            Assert.AreEqual(".\\private$\\notapath", ((PeekQueueCommandEx)actual).Path);
            Assert.AreEqual(10, ((PeekQueueCommandEx)actual).Count);

            args = "peek /p FormatName:DIRECT=TCP:10.139.209.222\\private$\\notapath /c 0";
            actual = CommandLineParser_Accessor.ParseQueueCommandEx(Parse(args));
            Assert.IsNotNull(actual);
            Assert.AreEqual(((PeekQueueCommandEx)actual).Path, "FormatName:DIRECT=TCP:10.139.209.222\\private$\\notapath");
            Assert.AreEqual((int?)null, ((PeekQueueCommandEx)actual).Count);

            //Adding test to cover peek command failure on empty queue
            const string TEST_PEEK_QUEUE = ".\\private$\\test_peek_queue";
            if (MessageQueue.Exists(TEST_PEEK_QUEUE)) MessageQueue.Delete(TEST_PEEK_QUEUE);
   
             MessageQueue.Create(TEST_PEEK_QUEUE);

            args = "peek /p " + TEST_PEEK_QUEUE;
            actual = CommandLineParser_Accessor.ParseQueueCommandEx(Parse(args));
            CommandBaseEx.Run(actual);

            MessageQueue.Delete(TEST_PEEK_QUEUE);
        }

        /// <summary>
        ///A test for DecodePurgeQueue
        ///</summary>
        [TestMethod()]
        [DeploymentItem("msmqmng.exe")]
        public void DecodePurgeQueueTest()
        {
            string args = "purge";
            CommandBaseEx actual = CommandLineParser_Accessor.ParseQueueCommandEx(Parse(args));
            Assert.IsNull(actual);

            args = "purge ";
            actual = CommandLineParser_Accessor.ParseQueueCommandEx(Parse(args));
            Assert.IsNull(actual);

            args = "purge ?";
            actual = CommandLineParser_Accessor.ParseQueueCommandEx(Parse(args));
            Assert.IsNull(actual);

            args = "purge /p notapath";
            actual = CommandLineParser_Accessor.ParseQueueCommandEx(Parse(args));
            Assert.IsNotNull(actual);
            Assert.AreEqual(((PurgeQueueCommandEx)actual).Path, ".\\private$\\notapath");

            args = "purge /p FormatName:DIRECT=TCP:10.139.209.222\\private$\\notapath ";
            actual = CommandLineParser_Accessor.ParseQueueCommandEx(Parse(args));
            Assert.IsNotNull(actual);
            Assert.AreEqual("FormatName:DIRECT=TCP:10.139.209.222\\private$\\notapath", ((PurgeQueueCommandEx)actual).Path);

            args = "purge /p notapath garbage";
            actual = CommandLineParser_Accessor.ParseQueueCommandEx(Parse(args));
            Assert.IsNotNull(actual);
        }

        /// <summary>
        ///A test for CommandLineParser
        ///</summary>
        [TestMethod()]
        [DeploymentItem("msmqmng.exe")]
        public void ParseTest()
        {
            string commandLine = string.Empty;
            string[] expected = new string[] {};
            string[] actual;
            actual = CommandLineParser_Accessor.Parse(commandLine);
            CollectionAssert.AreEqual(expected, actual);

            commandLine = null;
            actual = CommandLineParser_Accessor.Parse(commandLine);
            CollectionAssert.AreEqual(expected, actual);

            commandLine = "send";
            expected = new string[] { "send" };
            actual = CommandLineParser_Accessor.Parse(commandLine);
            CollectionAssert.AreEqual(expected, actual);

            commandLine = "send ";
            actual = CommandLineParser_Accessor.Parse(commandLine);
            CollectionAssert.AreEqual(expected, actual);

            commandLine = "send  ?";
            expected = new string[] { "send", "?" };
            actual = CommandLineParser_Accessor.Parse(commandLine);
            CollectionAssert.AreEqual(expected, actual);

            commandLine = "send notapath ";
            expected = new string[] { "send", "notapath"};
            actual = CommandLineParser_Accessor.Parse(commandLine);
            CollectionAssert.AreEqual(expected, actual);

            commandLine = "send notapath text ";
            expected = new string[] { "send", "notapath", "text" };
            actual = CommandLineParser_Accessor.Parse(commandLine);
            CollectionAssert.AreEqual(expected, actual);

            commandLine = "send notapath text \"some text here\"";
            expected = new string[] { "send", "notapath", "text", "some text here" };
            actual = CommandLineParser_Accessor.Parse(commandLine);
            CollectionAssert.AreEqual(expected, actual);

            commandLine = "send notapath count 5 text \"some text here\"";
            expected = new string[] { "send", "notapath", "count", "5", "text", "some text here" };
            actual = CommandLineParser_Accessor.Parse(commandLine);
            CollectionAssert.AreEqual(expected, actual);

            commandLine = "send notapath count 5 text \"some text here\" path \"c:\\some test path\\and test\\folder\"";
            expected = new string[] { "send", "notapath", "count", "5", "text", "some text here", "path", "c:\\some test path\\and test\\folder" };
            actual = CommandLineParser_Accessor.Parse(commandLine);
            CollectionAssert.AreEqual(expected, actual);
            
        }

        /// <summary>
        ///A test for DecodeSendCommand
        ///</summary>
        [TestMethod()]
        [DeploymentItem("msmqmng.exe")]
        public void DecodeSendCommandTest()
        {
            string[] args = new string[] { "send", "/p", "notapath", "/c", "5", "/m", "some text here" };
            //IQueueCommand expected = null; // TODO: Initialize to an appropriate value
            CommandBaseEx actual;
            actual = CommandLineParser_Accessor.DecodeSendCommand(args);
            Assert.IsNotNull(actual);

            args = new string[] { "send", "/p"};
            actual = CommandLineParser_Accessor.DecodeSendCommand(args);
            Assert.IsNull(actual);

            args = new string[] { "send", "/p", "notapath" };
            actual = CommandLineParser_Accessor.DecodeSendCommand(args);
            Assert.IsNull(actual);

            args = new string[] { "send", "/p", "count" };
            actual = CommandLineParser_Accessor.DecodeSendCommand(args);
            Assert.IsNull(actual);

            args = new string[] { "send", "/p", "notapath", "/c", "string" };
            actual = CommandLineParser_Accessor.DecodeSendCommand(args);
            Assert.IsNull(actual);

            args = new string[] { "send", "/p", "notapath", "/c", "5", "/m"};
            actual = CommandLineParser_Accessor.DecodeSendCommand(args);
            Assert.IsNull(actual);

            args = new string[] { "send", "/p", "notapath", "/c", "5", "/m", "some text" };
            actual = CommandLineParser_Accessor.DecodeSendCommand(args);
            Assert.IsNotNull(actual);
            Assert.AreEqual(".\\private$\\notapath", ((SendMessageCommandEx)actual).Path);
            Assert.AreEqual(5, ((SendMessageCommandEx)actual).Count);
            Assert.AreEqual("some text", (string)((SendMessageCommandEx)actual).Message.Body);

            args = new string[] { "send", "/p", ".\\private$\\notapath", "/m", "some other text" };
            actual = CommandLineParser_Accessor.DecodeSendCommand(args);
            Assert.IsNotNull(actual);
            Assert.AreEqual(((SendMessageCommandEx)actual).Path, ".\\private$\\notapath");
            Assert.AreEqual(((SendMessageCommandEx)actual).Count, 1);
            Assert.AreEqual("some other text", (string)((SendMessageCommandEx)actual).Message.Body);


            string filename = "C:\\dir01\\dir02\\some other dir\\file name.txt";
            args = new string[] { "send", "/p", "notapath", "/f", filename };
            actual = CommandLineParser_Accessor.DecodeSendCommand(args);
            Assert.IsNotNull(actual);
            Assert.AreEqual(((SendMessageCommandEx)actual).Path, ".\\private$\\notapath");
            Assert.AreEqual(((SendMessageCommandEx)actual).Count, 1);
            Assert.AreEqual(((SendFromFileQueueCommand)actual).FileName, filename);

            args = new string[] { "send", "/p", "notapath", "/c", "5", "/f", filename };
            actual = CommandLineParser_Accessor.DecodeSendCommand(args);
            Assert.IsNotNull(actual);
            Assert.AreEqual(((SendMessageCommandEx)actual).Path, ".\\private$\\notapath");
            Assert.AreEqual(((SendMessageCommandEx)actual).Count, 5);
            Assert.AreEqual(((SendFromFileQueueCommand)actual).FileName, filename);
        }
    }
}
