using System.Diagnostics;

namespace Rest.Logging {
    public class PaperlessLoggerFactory {
        public static IPaperlessLogger GetLogger() {
            StackTrace stackTrace = new StackTrace(1, false); //Captures 1 frame, false for not collecting information about the file
            var type = stackTrace.GetFrame(1).GetMethod().DeclaringType;
            return LoggerWrapper.CreateLogger("Log4Net.config", type.FullName);
        }
    }
}
