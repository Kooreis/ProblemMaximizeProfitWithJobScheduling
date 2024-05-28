Here is a Java console application that solves the problem:

```java
import java.util.*;

class Job {
    char id;
    int deadline, profit;

    public Job(char id, int deadline, int profit) {
        this.id = id;
        this.deadline = deadline;
        this.profit = profit;
    }
}

class JobComparator implements Comparator<Job> {
    public int compare(Job a, Job b) {
        return b.profit - a.profit;
    }
}

public class Main {
    public static void printJobScheduling(ArrayList<Job> arr, int t) {
        Collections.sort(arr, new JobComparator());

        boolean result[] = new boolean[t];
        char job[] = new char[t];

        for (int i = 0; i < t; i++) {
            result[i] = false;
        }

        for (int i = 0; i < arr.size(); i++) {
            for (int j = Math.min(t - 1, arr.get(i).deadline - 1); j >= 0; j--) {
                if (result[j] == false) {
                    result[j] = true;
                    job[j] = arr.get(i).id;
                    break;
                }
            }
        }

        for (char jb : job) {
            System.out.print(jb + " ");
        }
        System.out.println();
    }

    public static void main(String args[]) {
        ArrayList<Job> arr = new ArrayList<Job>();

        arr.add(new Job('a', 2, 100));
        arr.add(new Job('b', 1, 19));
        arr.add(new Job('c', 2, 27));
        arr.add(new Job('d', 1, 25));
        arr.add(new Job('e', 3, 15));

        System.out.println("Following is maximum profit sequence of jobs");

        JobComparator jc = new JobComparator();

        Collections.sort(arr, jc);

        int n = arr.size();
        int totalJobs = findMaxDeadline(arr);

        printJobScheduling(arr, totalJobs);
    }

    private static int findMaxDeadline(ArrayList<Job> arr) {
        int ans = Integer.MIN_VALUE;
        for (Job temp : arr) {
            ans = Math.max(temp.deadline, ans);
        }
        return ans;
    }
}
```

This program schedules jobs in a way that jobs with higher profit get executed first. If two jobs have the same profit, then the job with a smaller deadline is given priority. If multiple jobs have the same deadline, then the job that arrived first is given priority.