namespace _01.LockBasic
{
    internal class Program
    {
        public const string FileLocation = @"C:\Homespace\TestFiles\20231001\Test.txt";
        private static readonly object _lock = new object();

        static void Main(string[] args)
        {
            for (int i = 0; i < 10; i++)
            {
                var count = i;
                Task.Factory.StartNew(() =>
                {
                    lock (_lock)
                    {
                        File.AppendAllText(FileLocation, $"Write from task {count} \n");
                        Thread.Sleep(1000);
                        File.AppendAllText(FileLocation, $"Write from task {count} second times \n");
                    }
                });
            }

            Console.ReadKey();
        }
    }
}