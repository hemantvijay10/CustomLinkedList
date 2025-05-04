namespace CustomLinkedList
{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("Practice project");
        }
    }

    public interface ILinkedList<T> : ICollection<T>
    {
        void AddToFront(T item);

        void AddToEnd(T item);
    }

    public class CustomLL<T> : ILinkedList<T>
    {
        private class Node
        {
            public T Value;
            public Node? Next;
            public Node(T value)
            {
                Value = value;
                Next = null;
            }
        }

        private Node? _head;
        private Node? _tail;
        private int _count;

        public int Count => _count;
        public bool IsReadOnly => false;

        public void AddToFront(T item)
        {
            var node = new Node(item)
            {
                Next = _head
            };
            _head = node;
            if (_tail is null)
                _tail = node;
            _count++;
        }

        public void AddToEnd(T item)
        {
            var node = new Node(item);
            if (_tail is null)
            {
                _head = _tail = node;
            }
            else
            {
                _tail.Next = node;
                _tail = node;
            }
            _count++;
        }

        public void Add(T item) => AddToEnd(item);

        public bool Remove(T item)
        {
            Node? prev = null;
            for (var curr = _head; curr != null; prev = curr, curr = curr.Next)
            {
                if (EqualityComparer<T>.Default.Equals(curr.Value, item))
                {
                    if (prev is null)
                        _head = curr.Next;
                    else
                        prev.Next = curr.Next;

                    if (curr.Next is null)
                        _tail = prev;

                    _count--;
                    return true;
                }
            }
            return false;
        }

        public bool Contains(T item)
        {
            for (var node = _head; node != null; node = node.Next)
            {
                if (EqualityComparer<T>.Default.Equals(node.Value, item))
                    return true;
            }
            return false;
        }

        public void Clear()
        {
            _head = _tail = null;
            _count = 0;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array is null)
                throw new ArgumentNullException(nameof(array));
            if (arrayIndex < 0 || arrayIndex > array.Length)
                throw new ArgumentOutOfRangeException(nameof(arrayIndex));
            if (array.Length - arrayIndex < _count)
                throw new ArgumentException("Destination array is not large enough.");

            var node = _head;
            while (node != null)
            {
                array[arrayIndex++] = node.Value;
                node = node.Next;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            var node = _head;
            while (node != null)
            {
                yield return node.Value;
                node = node.Next;
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}