namespace $ext_safeprojectname$.Common.Configurations
{
    public class Kafka
    {
        public string Url { get; set; }
        public string ApiUsername { get; set; }
        public string ApiPassword { get; set; }
        public bool BatchEnabled { get; set; }
        public int Batchsize { get; set; }
        public string EntityName { get; set; }
    }
}
