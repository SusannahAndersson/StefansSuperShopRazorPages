namespace StefansSuperShop.Configuration
{
    public class MailSettings
    {
        public string DisplayName { get; }
        public string From { get; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }
        public bool UseSSL { get; set; }
        public bool UseStartTls { get; set; }
    }
}
