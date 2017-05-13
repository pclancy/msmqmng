using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using CoreServices;
using System.Messaging;

namespace msmqmng_test
{
    [TestClass]
    public class PefTesting
    {
        public const string TESTQUEUENAME = ".\\private$\\perf_msmq_mng_untitest_queue";
        public const string TESTQUEUENAME2 = ".\\private$\\perf_msmq_mng_untitest_queue2";

        [TestMethod]
        public void SendPefTest()
        {
            if (!MessageQueue.Exists(TESTQUEUENAME))
                MessageQueue.Create(TESTQUEUENAME);

            //Clean up
            MessageQueue queue = new MessageQueue(TESTQUEUENAME);
            queue.Purge();

            SendMessageCommandEx command = new SendMessageCommandEx(TESTQUEUENAME, 100000);
            command.Message = new Message("testsendcommand_message#1"); //25 bytes

            Stopwatch stopwatch = Stopwatch.StartNew();

            QueueCommandEx.Run(command);

            stopwatch.Stop();
            //1M ~ 9 sec
            //100K < 1 sec
            Assert.AreEqual(true, stopwatch.ElapsedMilliseconds < 1100, string.Format("Perfomance for 100K messages size 25 bytes was less than expected 1 second, actual perfomance was {0} milliseconds", stopwatch.ElapsedMilliseconds));
        }

        [TestMethod]
        public void CopyPefTest()
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

            //Fill the queue
            QueueCommandEx command = new SendMessageCommandEx(TESTQUEUENAME, 10000);
            command.Message = new Message("testsendcommand_message#1"); //25 bytes
            QueueCommandEx.Run(command);

            //Test

            command = new CopyQueueCommandEx(TESTQUEUENAME, TESTQUEUENAME2, (int?)null);

            Stopwatch stopwatch = Stopwatch.StartNew();

            QueueCommandEx.Run(command);

            stopwatch.Stop();
            //10K ~ 11 sec (queue opened every time)
            //10K ~ 2 sec (opening queue when creating instance of the class - ~6 times faster)
            Assert.AreEqual(true, stopwatch.ElapsedMilliseconds < 2500, string.Format("Perfomance for 10K messages size 25 bytes was less than expected 1 second, actual perfomance was {0} milliseconds", stopwatch.ElapsedMilliseconds));
        }
    }
}
