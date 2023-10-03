namespace _03._1.Semaphorex.CrossApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int ntasks = 0;
            int total_tasks = 5;
            int sem_count = 1;
            bool sem_created;

            Semaphore s = new Semaphore(1, 1, "sample_sem", out sem_created);
            
            if (sem_created)
            {
                Console.WriteLine("semaphore sample_sem was created");
            }

            Parallel.For(0, total_tasks, (i, state) => {
                Thread.CurrentThread.Name = "thread: " + i;
                while (true)
                {
                    try
                    {
                        if (s.WaitOne(100))
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine("Working" + Thread.CurrentThread.Name);
                            ntasks++;
                            Thread.Sleep(100);
                            s.Release();
                            break;
                        } else
                        {
                            Thread.Sleep(200);
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine("Sleeping" + Thread.CurrentThread.Name);
                        }
                    } catch (Exception) { }
                }
            });

            if (ntasks != total_tasks)
            {
                Console.WriteLine("Some taks haven't done the work");
            }
            Console.ReadKey();
        }
    }
}