namespace MyDictionary
{
    public class My_Dictionary<TKey, TValue>
    {
        private readonly int size;
        private readonly Func<TKey, int> func;
        private Node<TKey, TValue>[] node;

        public My_Dictionary(int size, Func<TKey, int> func)
        {
            this.size = size;
            this.func = func;

            node = new Node<TKey, TValue>[size];
        }

        public void InsertChain(TKey key, TValue value)
        {
            int index = GetHashIndex(key);
            var node = this.node[index];

            if (node == null)
            {
                this.node[index] = new Node<TKey, TValue>(key, value); 
            }
            else
            {
                while (node != null)
                {
                    if (EqualityComparer<TKey>.Default.Equals(node.Key, key))
                    {
                        node.Value = value;
                        return;
                    }
                    if (node.Next == null)
                        break;
                    node = node.Next;
                }
                node.Next = new Node<TKey, TValue>(key, value);
            }
        }

        public bool RemoveChain(TKey key)
        {
            int index = GetHashIndex(key);
            var node = this.node[index];
            Node<TKey, TValue> parrent = null;

            while (node != null)
            {
                if (EqualityComparer<TKey>.Default.Equals(node.Key, key))
                {
                    if (parrent == null)
                    {
                        this.node[index] = node.Next;
                    }
                    else
                    {
                        parrent.Next = node.Next;
                    }
                    return true;
                }
                parrent = node;
                node = node.Next;
            }
            return false;
        }

        public bool UpdateChain(TKey key, TValue value)
        {
            int index = GetHashIndex(key);
            var node = this.node[index];

            while (node != null)
            {
                if (EqualityComparer<TKey>.Default.Equals(node.Key, key))
                {
                    node.Value = value;
                    return true;
                }
                node = node.Next;
            }
            return false;
        }

        public TValue GetValueChain(TKey key)
        {
            int index = GetHashIndex(key);
            var node = this.node[index];

            while (node != null)
            {
                if (EqualityComparer<TKey>.Default.Equals(node.Key, key))
                {
                    return node.Value;
                }
                node = node.Next;
            }

            throw new KeyNotFoundException($"Key {key} not found in the hash table.");
        }

        private int GetHashIndex(TKey key)
        {
            int hash = func(key);
            return  Math.Abs(hash % size);
        }
    }
}