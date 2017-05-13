using MSMQManagementConsole;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using CoreServices;
using System.Messaging;
using System.IO;
using System.Reflection;

namespace msmqmng_test
{
    
    /// <summary>
    ///This is a test class for ProgramTest and is intended
    ///to contain all ProgramTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ProgramTest
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

        private const string TESTQUEUENAME = ".\\private$\\msmq_mng_untitest_queue";
        private const string TESTQUEUENAME2 = ".\\private$\\msmq_mng_untitest_queue2";

        /// <summary>
        ///A test for Create
        ///</summary>
        [TestMethod()]
        [DeploymentItem("msmqmng.exe")]
        public void CreateTest()
        {
            if (MessageQueue.Exists(TESTQUEUENAME))
                MessageQueue.Delete(TESTQUEUENAME);

            QueueCommandEx.Run(new CreateQueueCommandEx(TESTQUEUENAME, false));

            //Check if queue exists
            Assert.AreEqual(true, MessageQueue.Exists(TESTQUEUENAME));
        }

        /// <summary>
        ///A test for Delete
        ///</summary>
        [TestMethod()]
        [DeploymentItem("msmqmng.exe")]
        public void DeleteTest()
        {
            if (!MessageQueue.Exists(TESTQUEUENAME))
                MessageQueue.Create(TESTQUEUENAME);

            QueueCommandEx.Run(new DeleteQueueCommandEx(TESTQUEUENAME));

            //Check if queue was deleted
            Assert.AreEqual(false, MessageQueue.Exists(TESTQUEUENAME));
        }

        /// <summary>
        ///A test for Send
        ///</summary>
        [TestMethod()]
        [DeploymentItem("msmqmng.exe")]
        public void SendTest()
        {
            if (!MessageQueue.Exists(TESTQUEUENAME))
                MessageQueue.Create(TESTQUEUENAME);

            //Clean up
            MessageQueue queue = new MessageQueue(TESTQUEUENAME);
            queue.Purge();

            SendMessageCommandEx CommandEx = new SendMessageCommandEx(TESTQUEUENAME, 10);
            CommandEx.Message = new Message("testsendCommandEx_message#1");
            QueueCommandEx.Run(CommandEx);

            //Check count and content
            Assert.AreEqual(10, queue.GetAllMessages().Length);

            Message msg = queue.GetAllMessages()[0];
            msg.Formatter = new PlainTextFormatter();

            Assert.AreEqual("testsendCommandEx_message#1", msg.Body);

            msg = queue.GetAllMessages()[9];
            msg.Formatter = new PlainTextFormatter();

            Assert.AreEqual("testsendCommandEx_message#1", msg.Body);
        }

        /// <summary>
        ///A test for Send
        ///</summary>
        [TestMethod()]
        [DeploymentItem("msmqmng.exe")]
        public void PurgeTest()
        {
            if (!MessageQueue.Exists(TESTQUEUENAME))
                MessageQueue.Create(TESTQUEUENAME);

            //Clean up
            MessageQueue queue = new MessageQueue(TESTQUEUENAME);
            queue.Purge();

            SendMessageCommandEx CommandEx = new SendMessageCommandEx(TESTQUEUENAME, 10);
            CommandEx.Message = new Message("testsendCommandEx_message#1");
            QueueCommandEx.Run(CommandEx);

            //Make sure there are messages before purging
            Assert.AreEqual(10, queue.GetAllMessages().Length);

            QueueCommandEx.Run(new PurgeQueueCommandEx(TESTQUEUENAME));

            //Make sure no messages
            Assert.AreEqual(0, queue.GetAllMessages().Length);
        }

        /// <summary>
        ///A test for Send
        ///</summary>
        [TestMethod()]
        [DeploymentItem("msmqmng.exe")]
        public void PeekTest()
        {
            if (!MessageQueue.Exists(TESTQUEUENAME))
                MessageQueue.Create(TESTQUEUENAME);

            //Clean up
            MessageQueue queue = new MessageQueue(TESTQUEUENAME);
            queue.Purge();

            SendMessageCommandEx CommandEx = new SendMessageCommandEx(TESTQUEUENAME, 10);
            CommandEx.Message = new Message("testpeekCommandEx_message#1");
            QueueCommandEx.Run(CommandEx);
            
            //Peek CommandEx saves last read message in internal message variable, therefore:
            //a) test first message
            PeekQueueCommandEx peekCommandEx = (new PeekQueueCommandEx(TESTQUEUENAME, 1));
            QueueCommandEx.Run(peekCommandEx);

            Assert.AreEqual("testpeekCommandEx_message#1", peekCommandEx.Message.Body);

            //b) test last message
            peekCommandEx = (new PeekQueueCommandEx(TESTQUEUENAME, (int?)null));
            QueueCommandEx.Run(peekCommandEx);

            Assert.AreEqual("testpeekCommandEx_message#1", peekCommandEx.Message.Body);

            Type type = typeof(PeekQueueCommandEx);
            FieldInfo finfo = type.GetField("_messagesRead", BindingFlags.NonPublic | BindingFlags.GetField | BindingFlags.Instance);

            Assert.AreEqual(10, (long)finfo.GetValue(peekCommandEx));
        }

        /// <summary>
        ///A test for Send
        ///</summary>
        [TestMethod()]
        [DeploymentItem("msmqmng.exe")]
        public void CopyTest()
        {
            if (!MessageQueue.Exists(TESTQUEUENAME))
                MessageQueue.Create(TESTQUEUENAME);

            if (!MessageQueue.Exists(TESTQUEUENAME2))
                MessageQueue.Create(TESTQUEUENAME2);

            //Clean up
            MessageQueue queue = new MessageQueue(TESTQUEUENAME);
            queue.Purge();

            queue = new MessageQueue(TESTQUEUENAME2);
            queue.Purge();

            //Send messages to first queue
            SendMessageCommandEx CommandEx = new SendMessageCommandEx(TESTQUEUENAME, 110);
            CommandEx.Message = new Message("testsendCommandEx_message#1");
            QueueCommandEx.Run(CommandEx);
            
            //end of preparations, testing

            //Copy all
            QueueCommandEx.Run(new CopyQueueCommandEx(TESTQUEUENAME, TESTQUEUENAME2, (int?)null));
            Assert.AreEqual(110, queue.GetAllMessages().Length);

            //copy 10 more
            QueueCommandEx.Run(new CopyQueueCommandEx(TESTQUEUENAME, TESTQUEUENAME2, 10));
            Assert.AreEqual(120, queue.GetAllMessages().Length);
        }

        /// <summary>
        ///A test for Export
        ///</summary>
        [TestMethod()]
        [DeploymentItem("msmqmng.exe")]
        public void ExportTest()
        {
            //Prepare
            if (!MessageQueue.Exists(TESTQUEUENAME))
                MessageQueue.Create(TESTQUEUENAME);

            if (File.Exists("testfile.xml")) File.Delete("testfile.xml");

            
            MessageQueue queue = new MessageQueue(TESTQUEUENAME);
            queue.Purge();

            SendMessageCommandEx CommandEx = new SendMessageCommandEx(TESTQUEUENAME, 3);
            CommandEx.Message = new Message("testsendCommandEx");
            QueueCommandEx.Run(CommandEx);

            //Make sure messages are there
            Assert.AreEqual(3, queue.GetAllMessages().Length);

            //preparations complete - export test
            QueueCommandEx.Run(new ExportQueueCommandEx(TESTQUEUENAME, "testfile.xml"));

            //Verify content
            string actual;

            using (StreamReader reader = new StreamReader("testfile.xml"))
            {
                actual = reader.ReadToEnd();
            }

            string expected = "<?xml version=\"1.0\" encoding=\"utf-8\"?><messages><message><![CDATA[testsendCommandEx]]></message><message><![CDATA[testsendCommandEx]]></message><message><![CDATA[testsendCommandEx]]></message></messages>";

            Assert.AreEqual(expected, actual);

            //Clean up
            if (File.Exists("testfile.xml")) File.Delete("testfile.xml");
        }

        /// <summary>
        ///A test for Import
        ///</summary>
        [TestMethod()]
        [DeploymentItem("msmqmng.exe")]
        public void ImportTest()
        {
            //Prepare
            if (!MessageQueue.Exists(TESTQUEUENAME))
                MessageQueue.Create(TESTQUEUENAME);

            if (File.Exists("testfile.xml")) File.Delete("testfile.xml");

            MessageQueue queue = new MessageQueue(TESTQUEUENAME);
            queue.Purge();

            string data = "<?xml version=\"1.0\" encoding=\"utf-8\"?><messages><message><![CDATA[testsendCommandEx]]></message><message><![CDATA[testsendCommandEx]]></message><message><![CDATA[testsendCommandEx]]></message></messages>";

            using (StreamWriter writer = new StreamWriter("testfile.xml"))
            {
                writer.Write(data);
            }

            //Preparations complete - testing
            QueueCommandEx.Run(new ImportQueueCommandEx("testfile.xml", TESTQUEUENAME));

            //Make sure messages are there
            Assert.AreEqual(3, queue.GetAllMessages().Length);

            Message msg = queue.GetAllMessages()[0];
            msg.Formatter = new PlainTextFormatter();

            Assert.AreEqual("testsendCommandEx", msg.Body);

            //Clean up
            if (File.Exists("testfile.xml")) File.Delete("testfile.xml");
        }
    }
}
