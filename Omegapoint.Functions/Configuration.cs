namespace Omegapoint.Functions
{
    public class StorageConnection
    {
        public static string AzuriteStorage { get; set; }
    }

    public class StorageNames
    {
        public const string Queue = "__queuestorage__";
        public const string Container = "__blobstorage__";
    }
}