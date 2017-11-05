using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;

namespace RobotArm.CommonServices.ErrorHandling
{
    public class GlobalErrorHandlerBase : IErrorHandler
    {
        public void ProvideFault(Exception error, MessageVersion version, ref Message fault)
        {
            if (error is FaultException)
            {
                return;
            }
                
            FaultException faultException = new FaultException("A general service error occured: " + error.Message);
            MessageFault messageFault = faultException.CreateMessageFault();
            fault = Message.CreateMessage(version, messageFault, null);
        }

        public virtual bool HandleError(Exception error)
        {
            return true;
        }
    }
}