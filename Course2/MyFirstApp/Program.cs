// Thread t1 = new Thread(MyJob);
// t1.Start(1);
// Thread t2 = new Thread(MyJob);
// t2.Start(2);

using System.Collections.Concurrent;
using MyFirstApp.Models;

public class Program
{
    internal static ConcurrentQueue<User> Users = new ConcurrentQueue<User>();
    public static SemaphoreSlim _pool = new SemaphoreSlim(initialCount: 0);
    public static void Main()
    {
        for (int i = 1; i <= 10; i++)
        {
            Users.Enqueue(new User(i, $"User {i}"));
            
            Thread t = new Thread(Worker);
            t.Start();
        }

        Thread.Sleep(500);

        //Console.WriteLine("Main thread calls Release(3).");
        _pool.Release(releaseCount: 3);

        Console.WriteLine("Main thread exits.");
    }
    

    static void Worker()
    {
        _pool.Wait();

        Users.TryDequeue(out User user);
        Console.WriteLine("User {0} enters the semaphore.", user!.Id);

        Thread.Sleep(1000);

        Console.WriteLine("User {0} releases the semaphore.", user!.Id);
        _pool.Release();
    }
}

// static void MyJob(object id)
// {
//     Console.WriteLine("MyJob ({1}) is running on thread {0}", Thread.CurrentThread.ManagedThreadId, id);
//     Thread.Sleep(1000);
// }

