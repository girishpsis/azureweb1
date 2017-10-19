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
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Queue;

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
            Console.WriteLine("web job 1 started at " + DateTime.Now.ToString());
            var client = QueueClient.CreateFromConnectionString(connectionString, queueName);

            BrokeredMessage message = client.Receive();
            string messageBody = message.GetBody<string>();
            Console.WriteLine($"Message received: {messageBody}");
            SendEmail(messageBody);
            message.Complete();
            //var credentials = new StorageCredentials("servicebus-gps", "JntuuS514ao9BrDtaTsx/q0GL305KrjRcdI4/8fi7nI=");

            //var storageAccount = new CloudStorageAccount(credentials, true);

            //// Create a new client
            //CloudQueueClient queueClient = storageAccount.CreateCloudQueueClient();

            //// Retrieve a reference to a queue
            //CloudQueue queue = queueClient.GetQueueReference("GirishQueue");

            //foreach (CloudQueueMessage message in queue.GetMessages(20, TimeSpan.FromMinutes(5)))
            //{
            //    // Reading content from message
            //    Console.WriteLine(message.AsString);

            //    // Process all messages in less than 5 minutes, deleting each message after processing.
            //    queue.DeleteMessage(message);
            //}

            //client.OnMessage(message =>
            //{
            //    string msg = message.GetBody<String>();
            //   Console.WriteLine(String.Format("Message body 6: {0}", msg));
            //    //Console.WriteLine(String.Format("Message id: {0}", message.MessageId));
            //    Program pgm = new Program();
            //   pgm.SendEmail(msg);
            //});


        }

       

        public static void SendEmail(string text)
        {
            try
            {
                Console.WriteLine("Send email started");

                var apiKey = System.Environment.GetEnvironmentVariable("SENDGRID_APIKEY");
                Console.WriteLine(apiKey);
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
            finally
            {
                Console.WriteLine("Send email done!");
            }
        }
    }
}
