using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Threading.Tasks;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       

    }

    static void SendEMail(string text)
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

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        SendEMail(lblOne.Text);
    }
}