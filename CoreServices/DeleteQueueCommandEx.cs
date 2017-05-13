using System;
using System.Messaging;

namespace CoreServices
{
    public class DeleteQueueCommandEx : QueueCommandEx
    {
        public DeleteQueueCommandEx(string path)
        {
            this.Path = path;
        }

        protected internal override bool First()
        {
            try
            {
                //If queue does not exists return true
                if (!MessageQueue.Exists(Path))
                {
                    Logger.LogInfo(Resource.INFO_DELETEQUEUEDOESNOTEXISTS, Path);

                    return true;
                }

                MessageQueue.Delete(Path);

                return true;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, Resource.ERR_UNABLETODELETE, Path, ex.Message);
            }

            return false;
        }
    }
}
