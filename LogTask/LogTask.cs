using System;
using NLog;

namespace LogTask
{
    class LogTask
    {
        static void Main()
        {
            var logger = LogManager.GetCurrentClassLogger();

            logger.Debug("debug message");
            logger.Info("info message");

            try
            {
                throw new Exception("Exception");
            }
            catch (Exception e)
            {
                logger.Error(e);
            }
        }
    }
}
