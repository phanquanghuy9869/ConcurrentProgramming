namespace _03.Semaphorex
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool sem_created;
            Semaphore s = new Semaphore(1, 1, "sample_sem", out sem_created);
            if (sem_created)
            {
                Console.WriteLine("semaphore sample_sem was created");
            }

            s.WaitOne();
            Console.WriteLine("Press any key to release system semaphore");
            Console.ReadLine();
            s.Release();
            Console.ReadKey();
        }
    }
}