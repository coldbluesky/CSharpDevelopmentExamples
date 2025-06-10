namespace test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            for (int i = 0; i < 4; i++)
            {
                var (mod, index) = GetUnitIndex(i);
                Console.WriteLine($"index:{index}  mod:{mod}");
            }
        }
        public static (int, int) GetUnitIndex(int deviceIndex)
        {
            var mod = deviceIndex % 2;
            var index = (deviceIndex - mod) / 2;
            return (mod, index);
        }
    }
}
