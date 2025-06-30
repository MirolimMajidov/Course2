namespace YAGNI
{
    public class Task
    {
        public string Title { get; set; }
        public bool IsCompleted { get; set; }

        // Not needed now, but added "just in case"
        public int Priority { get; set; }
        public DateTime? NotificationTime { get; set; }
        public string SharedWith { get; set; }

        public void NotifyUser()
        {
            // Placeholder for future functionality
            Console.WriteLine("Notify user at " + NotificationTime);
        }

        public void ShareTask()
        {
            Console.WriteLine("Sharing with: " + SharedWith);
        }
    }
    
    public class Task2
    {
        public string Title { get; set; }
        public bool IsCompleted { get; set; }
    }
}
