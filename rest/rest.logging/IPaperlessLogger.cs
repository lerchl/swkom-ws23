namespace Rest.Logging {
    public interface IPaperlessLogger {
        void Debug(string message);
        void Error(string message);
        void Info(string message);
        void Warn(string message);
        void Fatal(string message);
    }
}
