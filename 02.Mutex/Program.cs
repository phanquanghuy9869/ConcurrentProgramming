namespace _02.Mutexx
{
    internal class Program
    {
        public const string FileLocation = @"C:\Homespace\TestFiles\20231001\Mutex.txt";

        static void Main(string[] args)
        {
            Mutex mutex = new Mutex();

            for (int i = 0; i < 10; i++)
            {
                var count = i;
                Task.Factory.StartNew(() =>
                {
                    if (mutex.WaitOne(4000))
                    {
                        try
                        {
                            Console.WriteLine(File.ReadAllText(FileLocation));
                            File.AppendAllText(FileLocation, $"Write from task {count} \n");
                            Thread.Sleep(5000);
                        }
                        finally
                        {
                            mutex.ReleaseMutex();
                        }
                    } else
                    {
                        Console.WriteLine("Mutex has not been released in 4 sec");
                    }
                });
            }

            Console.ReadKey();
        }
    }
}