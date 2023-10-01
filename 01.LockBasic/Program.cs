namespace _01.LockBasic
{
    internal class Program
    {
        public const string FileLocation = "C:\\Homespace\\TestFiles\\20231001";
        static void Main(string[] args)
        {
            for (int i = 0; i < 10; i++)
            {
                Task.Factory.StartNew(() =>
                {
                    File.AppendAllText(FileLocation, $"Write from task {i}");
                    Thread.Sleep(1000);
                    File.AppendAllText(FileLocation, $"Write from task {i} second times");
                });
            }

            Console.ReadKey();
        }
    }
}