using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RavenWebPayroll.Common.Components.Interfaces.DataForms
{
    public delegate void NotifyExceptionOccurenceEventHandler(ExceptionNotification ex);

    public delegate void NotifySuccessfulOperationEventHandler(string message);

    public interface IResponder
    {
        event NotifyExceptionOccurenceEventHandler NotifyExceptionOccurence;

        event NotifySuccessfulOperationEventHandler NotifySuccessfulOperation;
    }

    public class ExceptionNotification : Exception  
    {
        private string _message = string.Empty;

        public ExceptionNotification(string message)
        { _message = message; }

        public override string Message
        { get { return _message; } }
    }
}
