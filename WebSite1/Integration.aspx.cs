using Microsoft.ServiceBus;
using Microsoft.ServiceBus.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Integration : System.Web.UI.Page
{
    

    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    protected void btnMessage_Click(object sender, EventArgs e)
    {

        var message = new BrokeredMessage(txtMessage.Text);
        QueueConnector.OrdersQueueClient.Send(message);
    }
}