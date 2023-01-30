using System.Collections.Generic;

namespace StefansSuperShop.ViewModels
{
    public class MailData
    {
        // Receiver
        public List<string> To { get; set; }

        // Sender
        public string? From { get; }

        public string? DisplayName { get; }

        // Content
        public string Subject { get; set; }

        public string Body { get; set; }

        public MailData()
        { }

        public MailData(List<string> to, string subject, string body, string? from = null, string? displayName = null)
        {
            // Receiver
            To = to;


            // Sender - it's okay if these are null, will be fixed further down the line
            From = from;
            DisplayName = displayName;

            // Content
            Subject = subject;
            Body = body;
        }
    }
}

