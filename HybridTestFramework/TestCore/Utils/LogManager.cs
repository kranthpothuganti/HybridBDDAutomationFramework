using NLog;

namespace TestCore.Utils
{
    public static class LogManagerHelper
    {
        private static readonly Logger _logger = NLog.LogManager.GetCurrentClassLogger();

        public static Logger Logger => _logger;
    }
}
