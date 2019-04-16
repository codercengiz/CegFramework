using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net.Core;

namespace CegFramework.Core.CrossCuttingConcerns.Logging.Log4Net
{
    [Serializable]
    public class SerilizableLogEvent
    {
        private LoggingEvent _loggingEvent;

        public SerilizableLogEvent(LoggingEvent loggingEvent)
        {
            _loggingEvent = loggingEvent;
        }

        public string UserName => _loggingEvent.UserName;
        public object MessageObject => _loggingEvent.MessageObject;
    }
}
