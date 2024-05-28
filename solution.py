Here is a Python console application that solves the problem:

```python
class Job:
    def __init__(self, id, deadline, profit):
        self.id = id
        self.deadline = deadline
        self.profit = profit

def printJobScheduling(jobs, t):
    n = len(jobs)
    for i in range(n):
        for j in range(n - 1 - i):
            if jobs[j].profit < jobs[j + 1].profit:
                jobs[j], jobs[j + 1] = jobs[j + 1], jobs[j]

    result = [False] * t
    job = ['-1'] * t
    total_profit = 0

    for i in range(len(jobs)):
        for j in min(t - 1, jobs[i].deadline - 1), -1, -1:
            if result[j] is False:
                result[j] = True
                job[j] = jobs[i].id
                total_profit += jobs[i].profit
                break

    print("Following is maximum profit sequence of jobs")
    print(' '.join(job))
    print("Total profit is", total_profit)

if __name__ == "__main__":
    jobs = [Job('a', 2, 100), Job('b', 1, 19), Job('c', 2, 27), Job('d', 1, 25), Job('e', 3, 15)]
    printJobScheduling(jobs, 3)
```

This Python console application first sorts all jobs so that jobs with maximum profit are at the beginning. After sorting, it iterates through the jobs from start to end. For each job, it finds an empty time slot from its deadline to the start of the time slots, and if found, it adds the job to the result. If no such slot is found, it ignores the job.