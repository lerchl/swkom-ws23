using System.Diagnostics;

namespace Rest.Logging {
    public class LoggerFactory {

        public static ILoggerWrapper GetLogger() {
            StackTrace stackTrace = new StackTrace(1, false); //Captures 1 frame, false for not collecting information about the file
            var type = stackTrace.GetFrame(1).GetMethod().DeclaringType;
            return (Rest.Logging.LoggerWrapper)LoggerWrapper.CreateLogger("./log4net.config", type.FullName);
        }
    }
}
