using System.Diagnostics;

class Program
{
    static void Main()
    {
        // Create a performance counter category if it doesn't exist
        if (!PerformanceCounterCategory.Exists("MyAppCategory"))
        {
            CounterCreationDataCollection counterDataCollection = new CounterCreationDataCollection();
            counterDataCollection.Add(new CounterCreationData
            {
                CounterName = "RequestsPerSecond",
                CounterType = PerformanceCounterType.RateOfCountsPerSecond32,
                CounterHelp = "Number of requests processed per second."
            });

            PerformanceCounterCategory.Create(
                "MyAppCategory",
                "Category for MyApp performance counters",
                PerformanceCounterCategoryType.SingleInstance,
                counterDataCollection
            );
        }

        // Create and use performance counters
        using (var requestsPerSecondCounter = new PerformanceCounter("MyAppCategory", "RequestsPerSecond", false))
        {
            // Simulate processing requests
            while (true)
            {
                requestsPerSecondCounter.Increment();
                System.Threading.Thread.Sleep(1000); // Sleep for a second
            }
        }
    }
}
