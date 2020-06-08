using System;


namespace De.HSFlensburg.Bookmanager008.Service.ServiceBus
{
    interface IMessenger
    {
        void Register<TNotification>(object recipient, Action action);
        void Send<TNotification>(TNotification notification);
        void Unregister<TNotification>(object recipient);
    }
}

