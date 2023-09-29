using Google.Cloud.Storage.V1;

namespace $ext_safeprojectname$.Integration.Interfaces
{
    public interface IGoogleStorage
    {
        MemoryStream ConvertObjectToCsvStream<T>(IEnumerable<T> lst);
        void TestUpload(string bucket, string fileName, string contentType, Stream source);
        void BulkStorageUpload<T>(string bucket, string fileName, string contentType, int payloadCount, Func<int, int, IEnumerable<T>> payloadMethod);
    }
}
