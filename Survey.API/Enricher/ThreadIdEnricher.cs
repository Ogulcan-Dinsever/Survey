using Serilog.Core;
using Serilog.Events;

namespace Survey.API.Enricher
{
    public class ThreadIdEnricher : ILogEventEnricher
    {
        public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
        {
            logEvent.AddPropertyIfAbsent(propertyFactory.CreateProperty(
                 "ThreadId", Thread.CurrentThread.ManagedThreadId));
        }
    }
}
