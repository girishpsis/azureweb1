using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using System.Diagnostics;
using Microsoft.ServiceBus.Messaging;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace WebJob1
{
    // To learn more about Microsoft Azure WebJobs SDK, please see https://go.microsoft.com/fwlink/?LinkID=320976
    class Program
    {
        const string QueueName = "GirishQueue";

        static void Main()
        {
            var connectionString = "Endpoint=sb://servicebus-gps.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=JntuuS514ao9BrDtaTsx/q0GL305KrjRcdI4/8fi7nI=";
            var queueName = "GirishQueue";

            var client = QueueClient.CreateFromConnectionString(connectionString, queueName);

            client.OnMessage(message =>
            {
                string msg = message.GetBody<String>();
               Console.WriteLine(String.Format("Message body: {0}", msg));
                //Console.WriteLine(String.Format("Message id: {0}", message.MessageId));
                //SendEmail(msg);
            });

           
        }

        static void SendEmail(string text)
        {
            try
            {
                var apiKey = System.Environment.GetEnvironmentVariable("SENDGRID_APIKEY");
                var client = new SendGridClient(apiKey);
                var msg = new SendGridMessage()
                {
                    From = new EmailAddress("azure_5ba432e313a50299f93a5b151de6c895@azure.com", "Girish Nair"),
                    Subject = "Hello Deepthi",
                    PlainTextContent = text,
                    HtmlContent = "<strong>" + text + "</strong>"
                };
                msg.AddTo(new EmailAddress("deepthimj008acm@gmail.com", "Deepthi Girish"));
                msg.AddTo(new EmailAddress("girishpsis@gmail.com", "Girish Nair"));
                var response = client.SendEmailAsync(msg);
            }
            catch(Exception ex)
            {
                Console.WriteLine("Exception - " + ex.Message);
            }
        }
    }
}
