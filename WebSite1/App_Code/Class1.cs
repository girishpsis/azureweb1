using Microsoft.ServiceBus;
using Microsoft.ServiceBus.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public static class QueueConnector
{
    // Thread-safe. Recommended that you cache rather than recreating it
    // on every request.
    public static QueueClient OrdersQueueClient;

    // Obtain these values from the portal.
    public const string Namespace = "servicebus-gps";

    // The name of your queue.
    public const string QueueName = "GirishQueue";

    public static NamespaceManager CreateNamespaceManager()
    {
        // Create the namespace manager which gives you access to
        // management operations.
        var uri = ServiceBusEnvironment.CreateServiceUri(
            "sb", Namespace, String.Empty);
        var tP = TokenProvider.CreateSharedAccessSignatureTokenProvider(
            "RootManageSharedAccessKey", "JntuuS514ao9BrDtaTsx/q0GL305KrjRcdI4/8fi7nI=");
        return new NamespaceManager(uri, tP);
    }

    public static void Initialize()
    {
        // Using Http to be friendly with outbound firewalls.
        ServiceBusEnvironment.SystemConnectivity.Mode =
            ConnectivityMode.Http;

        // Create the namespace manager which gives you access to
        // management operations.
        var namespaceManager = CreateNamespaceManager();

        // Create the queue if it does not exist already.
        if (!namespaceManager.QueueExists(QueueName))
        {
            namespaceManager.CreateQueue(QueueName);
        }

        // Get a client to the queue.
        var messagingFactory = MessagingFactory.Create(
            namespaceManager.Address,
            namespaceManager.Settings.TokenProvider);
        OrdersQueueClient = messagingFactory.CreateQueueClient(
            "GirishQueue");
    }
}