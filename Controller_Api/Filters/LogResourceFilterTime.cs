using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace Controller_Api.Filters
{
    public class LogResourceFilterTime : IResourceFilter
    {
        Stopwatch timer = new();
        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            timer.Stop();
            Console.WriteLine($"A ação foi executada em {timer.ElapsedMilliseconds/1000} segundos.");
        }

        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            timer.Start();
        }
    }
}
