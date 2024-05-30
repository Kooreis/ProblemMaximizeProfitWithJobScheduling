class JobComparator implements Comparator<Job> {
    public int compare(Job a, Job b) {
        return b.profit - a.profit;
    }
}