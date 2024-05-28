Here is a C# console application that solves the problem:

```Csharp
using System;
using System.Linq;
using System.Collections.Generic;

public class Job
{
    public char Id { get; set; }
    public int Deadline { get; set; }
    public int Profit { get; set; }
}

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

    public static int ScheduleJobs(List<Job> jobs, int t)
    {
        int n = jobs.Count;
        jobs = jobs.OrderByDescending(job => job.Profit).ToList();

        bool[] slot = new bool[t];
        int[] result = new int[t];
        for (int i = 0; i < n; i++)
        {
            for (int j = Math.Min(t - 1, jobs[i].Deadline - 1); j >= 0; j--)
            {
                if (slot[j] == false)
                {
                    result[j] = i;
                    slot[j] = true;
                    break;
                }
            }
        }

        int totalProfit = 0;
        for (int i = 0; i < t; i++)
            if (slot[i])
                totalProfit += jobs[result[i]].Profit;

        return totalProfit;
    }
}
```

This program first sorts all jobs so that the highest paying jobs come first. Then it iterates through the jobs from highest to lowest paying. For each job, it finds a free slot in the result array, where the slot's index is less than or equal to the job's deadline. If such a slot is found, the job is added to the slot and the slot is marked as filled. The total profit is then calculated by summing up the profits of all jobs in the result array.