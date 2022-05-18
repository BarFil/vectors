namespace vectors
{
    class MyArray<Type>
    {
        private Type[] myArray;
        public event EventHandler<int> SizeChanged;
        public event EventHandler<int> AllocatedMemoryChanged;

        protected virtual void OnSizeChanged(int newSize)
        {
            SizeChanged?.Invoke(this, newSize);
        }
        protected virtual void OnAllocatedMemoryChanged(int newSize)
        {
            AllocatedMemoryChanged?.Invoke(this, newSize);
        }
        public int Size
        {
            get;
            private set;
        }
        public Type this[int index]
        {
            get
            {
                if (index >= Size || index < 0)
                {
                    throw new ArgumentOutOfRangeException("", message: "Wartość o danym indeksie jest nieosiągalna: " + index);
                }
                return myArray[index];
            }
            set
            {
                if (index < 0)
                {
                    throw new ArgumentOutOfRangeException("", message: "Wartość o danym indeksie jest nieosiągalna: " + index);
                }
                if (index >= myArray.Length)
                {
                    Array.Resize<Type>(ref myArray, (index + 1) * 2);
                    OnAllocatedMemoryChanged(myArray.Length);
                }
                if (index >= Size)
                {
                    Size = index + 1;
                    OnSizeChanged(Size);
                }
                myArray[index] = value;
            }

        }

        public MyArray(int capacity = 0)
        {
            myArray = new Type[capacity];
            Size = 0;
        }

        public void Add(Type value)
        {
            this[Size] = value;
        }

        public void Dump()
        {
            Console.WriteLine("Allocated memory: " + myArray.Length);
            Console.WriteLine("Current size: " + Size);
            for (int i = 0; i < Size; i++)
            {
                Console.Write(myArray[i] + " ");
            }
            Console.WriteLine();
        }
    }
}
