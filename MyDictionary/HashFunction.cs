using System.Text;
using System.Security.Cryptography;

namespace MyDictionary
{
    class HashFunction
    {
        public Func<TKey, int> HashFunc<TKey>()
        {
            Func<TKey, int> hashFunc = key =>
            {
                if (key == null) 
                    return 0;

                int baseHash = key.GetHashCode();

                using var sha256 = SHA256.Create();

                byte[] input = Encoding.UTF8.GetBytes(baseHash.ToString());
                byte[] hash = sha256.ComputeHash(input);
                return BitConverter.ToInt32(hash, 0);
            };
            return hashFunc;
        }
    }
}
