
namespace MSMQManagementConsole
{
    internal static class QueueCommands
    {
        public const string ExportCommand = "export";
        public const string ImportCommand = "import";
        public const string CreateCommand = "create";
        public const string DeleteCommand = "delete";
        public const string PurgeCommand = "purge";
        public const string ListCommand = "list";
        public const string SendCommand = "send";
        public const string PeekCommand = "peek";
        public const string ReadCommand = "read";
        public const string CopyCommand = "copy";
        public const string ExtractCommand = "extract";

        public static readonly string[] commands = new string[] {ListCommand, CreateCommand, DeleteCommand, PurgeCommand,
                SendCommand, ReadCommand, PeekCommand, CopyCommand, ExportCommand, ExtractCommand, ImportCommand};
    }
}
