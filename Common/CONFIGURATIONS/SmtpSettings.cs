namespace $ext_safeprojectname$.Common.Configurations
{
    public class SmtpSettings
    {
        public string Host { get; set; }
        public int Port { get; set; }
        public bool EnableSsl { get; set; }
        public bool UseDefaultCredentials { get; set; }
        public string To { get; set; }
        public string From { get; set; }
        public string Cc { get; set; }
        public string Subject { get; set; }
        public string AttachmentName { get; set; }
    }
}
