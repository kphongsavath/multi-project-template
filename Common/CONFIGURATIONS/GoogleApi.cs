namespace $ext_safeprojectname$.Common.Configurations
{
    public class GoogleApi
    {
        public StorageApi StorageApi { get; set; } = new();
    }

    public class StorageApi
    {
        public string BucketName { get; set; }
        public string FileName { get; set; }
    }

    public class GoogleJsonKey
    {
        public string type { get; set; }
        public string project_id { get; set; }
        public string private_key_id { get; set; }
        public string private_key { get; set; }
        public string client_email { get; set; }
        public string client_id { get; set; }
        public string auth_uri { get; set; }
        public string token_uri { get; set; }
        public string auth_provider_x509_cert_url { get; set; }
        public string client_x509_cert_url { get; set; }
        public string universe_domain { get; set; }
    }

}
