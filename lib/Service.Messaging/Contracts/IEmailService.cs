using System;
using Alamut.Service.Messaging.Configration;

namespace Alamut.Service.Messaging.Contracts
{
    public interface IEmailService
    {
        void SendEmail<TMailId>(EmailBody<TMailId> body,
            Action<TMailId> onSuccess = null) where TMailId : struct;
    }
}
