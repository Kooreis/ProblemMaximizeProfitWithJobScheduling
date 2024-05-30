public class Program
{
    public static void Main()
    {
        List<Job> jobs = new List<Job>()
        {
            new Job { Id = 'a', Deadline = 2, Profit = 100 },
            new Job { Id = 'b', Deadline = 1, Profit = 19 },
            new Job { Id = 'c', Deadline = 2, Profit = 27 },
            new Job { Id = 'd', Deadline = 1, Profit = 25 },
            new Job { Id = 'e', Deadline = 3, Profit = 15 },
        };

        Console.WriteLine("Maximum obtainable profit is " + ScheduleJobs(jobs, 3));
    }