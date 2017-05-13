using System;
using System.Collections.Generic;
using System.Text;
using System.Messaging;
using System.Management;

namespace CoreServices
{
    public struct QueueInfo
    {
        public string QueueName;
        public long MessageCount;

        public QueueInfo(string queueName, long messageCount)
        {
            QueueName = queueName;
            MessageCount = messageCount;
        }
    }

    public class EnumerateQueuesCommandEx : CommandBaseEx
    {
        private ManagementScope scope;

        public string Domain { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public string MachineName { get; set; }
        public List<QueueInfo> Queues { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="machineName">Machine name to run enum for, null if for local machine.</param>
        public EnumerateQueuesCommandEx(string machineName)
        {
            MachineName = machineName;
            Queues = new List<QueueInfo>();
        }

        private int GetMessageCount(MessageQueue queue)
        {
            try
            {
                // Connect only once, since the connection process is very expensive - especially against remote machines.
                if (this.scope == null)
                {
                    this.scope = new ManagementScope(string.Format("\\\\{0}\\root\\cimv2", MachineName));

                    if (!string.IsNullOrEmpty(UserName))
                    {
                        this.scope.Options = new ConnectionOptions();

                        if (!string.IsNullOrEmpty(Domain))
                            this.scope.Options.Authority = string.Format("NTLMDOMAIN:{0}", Domain);

                        this.scope.Options.Username = UserName;
                        this.scope.Options.Password = Password;
                    }

                    this.scope.Connect();
                }

                SelectQuery query = new SelectQuery(string.Format("SELECT * FROM Win32_PerfRawData_msmq_MSMQQueue WHERE Name = \"{0}\\\\{1}\"", MachineName, queue.QueueName.Replace("\\", "\\\\")));

                ManagementObjectSearcher searcher = new ManagementObjectSearcher(this.scope, query);

                foreach (ManagementObject envVar in searcher.Get())
                {
                    return int.Parse(envVar["MessagesinQueue"].ToString());
                }

                return 0;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, Resource.ERR_UNABLEENUMERATEQUEUES, Resource.WDR_PUBLIC, MachineName, ex.Message);

                return 0;
            }
        }

        protected internal override bool First()
        {
            Queues.Clear();

            try
            {
                if (string.IsNullOrEmpty(MachineName)) MachineName = Environment.MachineName;

                MessageQueue[] queues = MessageQueue.GetPrivateQueuesByMachine(MachineName);

                foreach (MessageQueue queue in queues)
                {
                    Queues.Add(new QueueInfo(queue.QueueName, GetMessageCount(queue)));
                }

                // queues = MessageQueue.GetPublicQueuesByMachine(MachineName);

                //foreach (MessageQueue queue in queues)
                //{
                //    Queues.Add(new QueueInfo(queue.QueueName, GetMessageCount(queue)));
                //}
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, Resource.ERR_UNABLEENUMERATEQUEUES, Resource.WDR_PUBLIC, MachineName, ex.Message);

                return false;
            }

            return true;
        }
    }
}
