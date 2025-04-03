// Thread t1 = new Thread(MyJob);
// t1.Start(1);
// Thread t2 = new Thread(MyJob);
// t2.Start(2);

using System.Collections.Concurrent;
using System.Diagnostics;
using MyFirstApp.Models;

public class Program
{
    internal static ConcurrentQueue<User> Users = new ConcurrentQueue<User>();
    public static SemaphoreSlim _pool = new SemaphoreSlim(initialCount: 0);

    public static async Task Main()
    { 
        var timer = Stopwatch.StartNew();
        using var timeoutCancellationTokenSource = new CancellationTokenSource();
        //timeoutCancellationTokenSource.CancelAfter(TimeSpan.FromSeconds(5));
        var cancellationToken = timeoutCancellationTokenSource.Token;

        Task task4 = Task.Run(() =>
        {
            while (true)
            {
                Thread.Sleep(1000);
                if (cancellationToken.IsCancellationRequested)
                {
                    break;
                }

                //cancellationToken.ThrowIfCancellationRequested();
                Console.WriteLine($"Working...{DateTime.Now} ");
                Task.Delay(1000, cancellationToken);
            }

        }, cancellationToken);

        var counter = 0;
        
        while (task4.IsCompleted == false)
        {
            counter++;
            await Task.Delay(500, cancellationToken);
            if(counter == 10)
                await timeoutCancellationTokenSource.CancelAsync();
        }
        
        //Parallel.For(1, 5, Square);

        // ParallelLoopResult result = Parallel.ForEach<int>(
        //        new List<int>() { 1, 3, 5, 8 },
        //        Square
        // );

        // await Task.Run(() => MyTask(1, 2));
        // await Task.Run(() => MyTask(2, 1));
        // await Task.Run(() => MyTask(3, 3));
        // var task1 = Task.Run(() => MyTask(1, 2));
        // var task2 = Task.Run(() => MyTask(2, 1));
        // var task3 = Task.Run(() => MyTask(3, 3));
        // await task1.ContinueWith(task => { Console.WriteLine($"Task1: {task1.IsCompleted}"); });
        //
        // var task = new Task(() => MyTask(4, 1));
        // task.Start();
        // //await task2.ConfigureAwait(false);
        //
        // var task5 = Task.Factory.StartNew(() => { }, TaskCreationOptions.LongRunning);
        //
        // var result = await Task.Run(() => MyTask(1, 2));
        // var resultValue1 = task1.GetAwaiter().GetResult();
        // Task.WaitAll(task1, task2, task3);
        // var resultValue3 = await task1;
        // var resultValue2 = task1.Result;
        //
        // await task1;
        // await task2;
        // // await Task.Run(() => MyJob(3));
        // // await Task.Run(() => MyJob(3));
        // //await MyFirstTask();
        // task1.GetAwaiter().GetResult();
        //
        // Task.WaitAll(task1, task2, task3);
        // timer.Stop();
        // Console.WriteLine($"Total time: {timer.Elapsed}");
        //
        // var task4 = Task.Run(() => MyJob(4));

        // for (int i = 1; i <= 10; i++)
        // {
        //     Users.Enqueue(new User(i, $"User {i}"));
        //     
        //     Thread t = new Thread(Worker);
        //     t.Start();
        // }

        Thread.Sleep(500);

        //Console.WriteLine("Main thread calls Release(3).");
        _pool.Release(releaseCount: 3);

        Console.WriteLine("Main thread exits.");
    }

    static void Square(int n)
    {
        Console.WriteLine($"Result of {n} is {n * n}");
        Thread.Sleep(TimeSpan.FromSeconds(0.5));
        Console.WriteLine($"Completed task: {Task.CurrentId}, {Thread.CurrentThread.ManagedThreadId}");
    }

    static Task<int> MyTask(int id, int seconds)
    {
        return Task.Run(() =>
        {
            Console.WriteLine("MyJob ({1}) is running on thread {0}", Thread.CurrentThread.ManagedThreadId, id);
            Thread.Sleep(seconds * 1000);
            Console.WriteLine("MyJob ({0}) completed", id);

            return seconds * 2;
        });
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

    static void MyJob(object id)
    {
        Console.WriteLine("MyJob ({1}) is running on thread {0}", Thread.CurrentThread.ManagedThreadId, id);
        Thread.Sleep(1000);
    }
}