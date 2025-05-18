using System.Collections;

namespace BloomFilter
{
    public class Bloom_filter<T>
    {
        private readonly BitArray array;
        private readonly int size;
        private readonly Func<T, int>[] funcs;

        public Bloom_filter(int size, Func<T, int>[] funcs)
        {
            if (size <= 0)
                throw new ArgumentException(nameof(size));
            if (funcs == null) 
                throw new ArgumentException(nameof(funcs));

            this.size = size;
            this.funcs = funcs;
            array = new BitArray(size);
        }

        public void Add(T key)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));

            foreach (var func in funcs)
            {
                int hash = Math.Abs(func(key) %  size);
                array[hash] = true;
            }
        }

        public bool Contain(T key)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));
            foreach (var func in funcs)
            {
                int hash = Math.Abs(func(key) % size);
                if (!array[hash])
                    return false;
            }
            return true;
        }
    }
}