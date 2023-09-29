namespace $ext_safeprojectname$.Integration.Interfaces
{
    public interface IKafkaService
    {
        void MakeApiCall<T>(HttpClient client, string kafkaTopic, IEnumerable<T> payload);
        void MakeApiCall<T>(HttpClient client, string kafkaTopic, int payloadCount, Func<int, int, IEnumerable<T>> payloadMethod);
    }
}
