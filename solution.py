def printJobScheduling(jobs, t):
    n = len(jobs)
    for i in range(n):
        for j in range(n - 1 - i):
            if jobs[j].profit < jobs[j + 1].profit:
                jobs[j], jobs[j + 1] = jobs[j + 1], jobs[j]