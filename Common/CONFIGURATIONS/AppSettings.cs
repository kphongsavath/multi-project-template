namespace $ext_safeprojectname$.Common.Configurations
{
    public class AppSettings
    {
        public SerilogConfig Serilog { get; set; }
        public ConnectionStrings ConnectionStrings { get; set; }
        public Kafka KafkaApi { get; set; }
        public Logging Logging { get; set; }
        public App App { get; set; }
        public FileArguments FileArguments { get; set; }
        public SmtpSettings SmtpSettings { get; set; }
        public GoogleApi GoogleApi { get; set; }
    }
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);





    
}
