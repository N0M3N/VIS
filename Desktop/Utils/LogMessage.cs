namespace Desktop.Utils
{
    internal class LogMessage
    {
        public string Message { get; private set; }
        public bool IsSuccess { get; private set; }

        private LogMessage()
        { }

        public static LogMessage Success(string message)
        {
            return new LogMessage { Message = message, IsSuccess = true };
        }

        public static LogMessage Error(string message)
        {
            return new LogMessage { Message = message, IsSuccess = false };
        }
    }
}
