namespace ConsoleApp1
{
    internal class Program
    {
        public static int tomb = 2;
        static void Main(string[] args)
        {
            fuggveny(ref tomb);
            Console.WriteLine(tomb);
        }
        static int fuggveny( ref int tomb)
        {
            tomb = 10;
            return 1; 
        }
    }
}