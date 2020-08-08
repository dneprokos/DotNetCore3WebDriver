using System;
using System.Diagnostics;
using System.Threading;

namespace WebDriverWithCore3Tests.Common.Helpers
{
    public static class WaitManager
    {
        /// <summary>
        /// Wait for action returns true
        /// </summary>
        /// <param name="action"></param>
        /// <param name="operationName"></param>
        /// <param name="timeOutSeconds"></param>
        /// <param name="delayMilliseconds"></param>
        /// <returns></returns>
        public static bool WaitForTrueCondition
            (Func<bool> action, string operationName, int timeOutSeconds = 10, int delayMilliseconds = 500)
        {
            var timer = new Stopwatch();
            timer.Start();

            do
            {
                try
                {
                    var condition = action.Invoke();
                    if (condition)
                        return condition;
                    Thread.Sleep(delayMilliseconds);
                }
                catch (Exception)
                {
                    Thread.Sleep(delayMilliseconds);
                }
            } while (timer.Elapsed.Seconds < timeOutSeconds);

            throw new Exception($"{operationName} opearation has not been finished during {timeOutSeconds} seconds.");
        }
    }
}
