using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace WebDriverWithCore3Tests.Common.Helpers
{
    public static class RetryManager
    {
        public static void Retry(int maxAttempts, Action action, int timeOutMilliseconds) 
        {
            var attempt = 0;
            do
            {
                try
                {
                    attempt++;
                    action();
                    break;
                }
                catch (Exception ex)
                {
                    if (attempt >= maxAttempts) 
                    {
                        throw new Exception(ex.Message);
                    }
                }

                if (timeOutMilliseconds > 0) 
                {
                    Thread.Sleep(timeOutMilliseconds);
                }
                
            } while (attempt < maxAttempts);
        }
    }
}
