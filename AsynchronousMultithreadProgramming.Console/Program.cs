// See https://aka.ms/new-console-template for more information


using AsyncMethodsN;
using System.Diagnostics;
using TPL;

/*
#region ContinueWith
await AsyncMethods.ContinueWithMethodsUsingTypeOne();
await AsyncMethods.ContinueWithMethodsUsingTypeTwo();
#endregion
*/

/*
#region WhenAll
await AsyncMethods.WhenAllMethod();
#endregion
*/

/*
#region WhenAny
await AsyncMethods.WhenAnyMethod();
#endregion
*/

/*
#region WaitAll
await AsyncMethods.WaitAllMethod();
#endregion*/

/*
#region WaitAny
await AsyncMethods.WaitAnyMethod();
#endregion
*/

/*
#region WaitAny
await AsyncMethods.DelayMethod();
#endregion
*/


/*
#region Run
var taskA = AsyncMethods.RunA();
var taskB = AsyncMethods.RunA();
await Task.WhenAll(taskA, taskB);
#endregion
*/

/*
#region Run
await AsyncMethods.StartNewA();
#endregion
*/

/*
#region FromTask
await AsyncMethods.FromTaskA();
#endregion
*/

//TplClass.PForEach();

TplClass.InterferenceParallel();

namespace AsyncMethodsN
{
    using Classes;

    public class AsyncMethods
    {
        #region ContinueWith
        public static async Task ContinueWithMethodsUsingTypeOne()
        {
            var result = new HttpClient().GetStringAsync("https://www.google.com").ContinueWith(response =>
            {
                Console.WriteLine(response.Result.Length);
            });
            Console.WriteLine("Some other codes");

            await result;
        }
        public static async Task ContinueWithMethodsUsingTypeTwo()
        {
            await new HttpClient().GetStringAsync("https://www.google.com").ContinueWith(response =>
            {
                Console.WriteLine(response.Result.Length);
            });
            Console.WriteLine("Some other codes");
        }
        #endregion

        #region WhenAll
        
        public static async Task WhenAllMethod()
        {
            Console.WriteLine("Current thread: " + Thread.CurrentThread.ManagedThreadId);

            var URLs = new List<string>() { "https://www.google.com", "https://www.microsoft.com", "https://www.trendyol.com", "https://www.instagram.com", "https://www.haberturk.com" };

            var contetns = new List<Task<Content>>();

            URLs.ForEach(url =>
            {
                contetns.Add(GetContentAsync(url));
            });

            var result = Task.WhenAll(contetns.ToArray());

            Console.WriteLine("Some other operations");

            await result;

            result.Result.ToList().ForEach(c =>
            {
                Console.WriteLine("Url: " + c.Name + ", Lenght: " + c.Value);
            });
        }

        public static async Task<Content> GetContentAsync(string url)
        {
            var result = await new HttpClient().GetStringAsync(url);
            Console.WriteLine("Current thread: " + Thread.CurrentThread.ManagedThreadId);
            return new Content() { Name = url, Value = result.Length };
            
        }

        #endregion

        #region WhenAny

        public static async Task WhenAnyMethod()
        {
            Console.WriteLine("Current thread: " + Thread.CurrentThread.ManagedThreadId);

            var URLs = new List<string>() { "https://www.google.com", "https://www.microsoft.com", "https://www.trendyol.com", "https://www.instagram.com", "https://www.haberturk.com" };

            var contetns = new List<Task<Content>>();

            URLs.ForEach(url =>
            {
                contetns.Add(GetContentAsync(url));
            });

            var result = Task.WhenAny(contetns.ToArray());

            Console.WriteLine("Some other operations");

            var c = await result;

            Console.WriteLine("Url: " + c.Result.Name + ", Lenght: " + c.Result.Value);

        }

        #endregion

        #region WaitAll
        /* WaitAll blocks main thread during the Tasks ends while WhenAll does not block*/
        public static async Task WaitAllMethod()
        {
            Console.WriteLine("Current thread: " + Thread.CurrentThread.ManagedThreadId);

            var URLs = new List<string>() { "https://www.google.com", "https://www.microsoft.com", "https://www.trendyol.com", "https://www.instagram.com", "https://www.haberturk.com" };

            var contetns = new List<Task<Content>>();

            URLs.ForEach(url =>
            {
                contetns.Add(GetContentAsync(url));
            });

            var result = Task.WaitAll(contetns.ToArray(),5000); // we can put a thrashold value and then get bool result

            Console.WriteLine("Some other operations" + " " + result.ToString());


            contetns.ForEach(c =>
            {
                Console.WriteLine("Url: " + c.Result.Name + ", Lenght: " + c.Result.Value);
            });
        }
        #endregion

        #region WaitAny
        /* WaitAll blocks main thread during the Tasks ends while WhenAll does not block*/
        public static async Task WaitAnyMethod()
        {
            Console.WriteLine("Current thread: " + Thread.CurrentThread.ManagedThreadId);

            var URLs = new List<string>() { "https://www.google.com", "https://www.microsoft.com", "https://www.trendyol.com", "https://www.instagram.com", "https://www.haberturk.com" };

            var contetns = new List<Task<Content>>();

            URLs.ForEach(url =>
            {
                contetns.Add(GetContentAsync(url));
            });

            var firstCompletedTask = Task.WaitAny(contetns.ToArray());

            Console.WriteLine("Url: " + contetns[firstCompletedTask].Result.Name + ", Lenght: " + contetns[firstCompletedTask].Result.Value);

            contetns.ForEach(c =>
            {
                Console.WriteLine("Url: " + c.Result.Name + ", Lenght: " + c.Result.Value);
            });
        }
        #endregion

        #region WaitAny
        /* WaitAll blocks main thread during the Tasks ends while WhenAll does not block*/
        public static async Task DelayMethod()
        {
            Console.WriteLine("Current thread: " + Thread.CurrentThread.ManagedThreadId);

            var URLs = new List<string>() { "https://www.google.com", "https://www.microsoft.com", "https://www.trendyol.com", "https://www.instagram.com", "https://www.haberturk.com" };

            var contetns = new List<Task<Content>>();

            URLs.ForEach(url =>
            {
                contetns.Add(GetContentWithDelayAsync(url));
            });

            var begin = DateTime.Now;
            var tasks = Task.WhenAll(contetns.ToArray());
            await Task.Delay(2000);
            var end = DateTime.Now;

            Console.WriteLine("Some other operations" + " Saniye: " + (end-begin).Seconds);

            await tasks;

            var newEnd = DateTime.Now;

            Console.WriteLine("Some other operations" + " Saniye: " + (newEnd - begin).Seconds);

            contetns.ForEach(c =>
            {
                Console.WriteLine("Url: " + c.Result.Name + ", Lenght: " + c.Result.Value);
            });
        }

        public static async Task<Content> GetContentWithDelayAsync(string url)
        {
            var result = await new HttpClient().GetStringAsync(url);
            await Task.Delay(4000);
            Console.WriteLine("Current thread: " + Thread.CurrentThread.ManagedThreadId);
            return new Content() { Name = url, Value = result.Length };

        }
        #endregion

        #region Run
        public static async Task RunA()
        {

            await Task.Run(() =>
            {
                
                Enumerable.Range(0, 50).ToList().ForEach(x =>
                {
                    Thread.Sleep(100);
                    Console.Write(x + " ");
                });
                Console.WriteLine();
            });

        }
        #endregion

        #region StartNew
        public static async Task StartNewA()
        {
            var result = Task.Factory.StartNew((obj) =>
            {
                Console.WriteLine("From inside");
                var status = obj as Status;
                status!.ThreadId = Thread.CurrentThread.ManagedThreadId;

            }, new Status { Date = DateTime.Now });

            await result;

            var status = result.AsyncState as Status;

            Console.WriteLine("Date: " + status!.Date.ToString() + " Id: " +  status!.ThreadId);
        }
        #endregion

        #region FromTask

        public static Cached Cached { get; set; } = new Cached();

        public static async Task<string> FromTaskA()
        {
            if (string.IsNullOrEmpty(Cached.CachedData))
            {
                return await File.ReadAllTextAsync("File.txt");
            }

            return await Task.FromResult<string>(Cached.CachedData);
        }
        #endregion
    }

}

namespace TPL
{
    public class TplClass
    {

        public static void PForEach()
        {
            #region ParallelForEach
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            List<int> ints = Enumerable.Range(1, 1000).ToList();

            Parallel.ForEach(ints, arg =>
            {
                MathOperations(arg);
            });
            stopWatch.Stop();

            Console.WriteLine("Elapsed time multiThread: " + stopWatch.ElapsedMilliseconds); 
            #endregion

            #region WithoutParallel

            stopWatch.Restart();

            stopWatch.Start();
            List<int> intsNew = Enumerable.Range(1, 1000).ToList();
            intsNew.ForEach(arg =>
            {
                MathOperations(arg);
            });

            stopWatch.Stop();

            Console.WriteLine("Elapsed time oneThread: " + stopWatch.ElapsedMilliseconds); 
            #endregion
        }

        public static void InterferenceParallel()
        {
            int size = 0;

            List<int> ints = Enumerable.Range(1, 1000).ToList();

            Parallel.ForEach(ints, arg =>
            {
                Interlocked.Add(ref size, arg);
            });

            Console.WriteLine("Result: " + size);

        }

        public static void InterferenceParallelWithSeperately()
        {
            int total = 0;

            Parallel.ForEach(Enumerable.Range(1, 100).ToList(), () => 0, (arg, loop, subTotal) =>
            {
                subTotal += arg;
                return subTotal;
            }, (subTotal) =>
            {
                Interlocked.And(ref total, subTotal);
            });
        }

        public static void CancellationToken()
        {

            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
            ParallelOptions parallelOptions = new ParallelOptions();
            parallelOptions.CancellationToken = cancellationTokenSource.Token;

            int total = 0;

            Parallel.ForEach(Enumerable.Range(1, 100).ToList(),parallelOptions ,() => 0, (arg, loop, subTotal) =>
            {
                subTotal += arg;
                return subTotal;
            }, (subTotal) =>
            {
                parallelOptions.CancellationToken.ThrowIfCancellationRequested();
                Interlocked.And(ref total, subTotal);
            });
        }

        public static void MathOperations(int arg)
        {
            var argNew = Math.Exp(arg);
        }

    }
}

namespace Classes
{
    public class Content
    {
        public string Name { get; set; }
        public int Value { get; set; }
    }

    public class Status
    {
        public int ThreadId { get; set; }
        public DateTime Date { get; set; }
    }

    public class Cached
    {
        public string CachedData { get; set; }
    }
}

