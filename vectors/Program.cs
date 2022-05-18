namespace vectors
{
    class Program
    {
        public static void tableSizeChanged(object sender, int newSize)
        {
            Console.WriteLine("New Size: " + newSize);
        }
        public static void tableMemoryChanged(object sender, int newSize)
        {
            Console.WriteLine("New allocated memory: " + newSize);
        }
        static void Main()
        {
            MyArray<int> tablica = new MyArray<int>(0);
            tablica.SizeChanged += tableSizeChanged;
            tablica.AllocatedMemoryChanged += tableMemoryChanged;
            tablica[0] = 1;
            tablica.Dump();
            Console.WriteLine("");

            tablica[3] = 2;
            tablica.Dump();
            Console.WriteLine("");

            tablica[2] = 3;
            tablica.Dump();
            Console.WriteLine("");

            tablica.Add(1);
            tablica.Dump();
            Console.WriteLine("");

            tablica[7] = 9;
            tablica.Dump();
            Console.WriteLine("");

            tablica.Add(2);
            tablica.Dump();
            Console.WriteLine("");

            try
            {
                //tablica[-1] = 3;
                Console.WriteLine(tablica[44]);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}