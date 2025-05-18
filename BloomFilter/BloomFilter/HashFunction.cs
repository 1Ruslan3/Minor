using System.Text;
using System.Security.Cryptography;

namespace BloomFilter
{
    class HashFunction
    {
        public static Func<T, int>[] HashFunc<T>(int count)
        {
            var hashFuncs = new Func<T, int>[count];
            for (int i = 0; i < count; i++)
            {
                int dif = i;
                hashFuncs[i] = key =>
                {
                    if (key == null) return 0;

                    int baseHash = key.GetHashCode();

                    using var sha256 = SHA256.Create();

                    byte[] input = Encoding.UTF8.GetBytes(baseHash.ToString() + dif);
                    byte[] hash = sha256.ComputeHash(input);
                    return BitConverter.ToInt32(hash, 0);
                };
            }
            return hashFuncs;
        }
    }
}
