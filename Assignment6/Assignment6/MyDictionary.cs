using System;
using System.Collections.Generic;
using System.Collections;

namespace Assignment6
{
    class MyDictionary<TKey, TValue> : IDictionary<TKey, TValue>
    {
        //Fields
        public List<TValue> values = new List<TValue>();
        public TKey key;
        public TValue value;
        int count;
        private IDictionary<TKey, TValue> dict = new Dictionary<TKey, TValue>();

        //Constuctor
        public MyDictionary()
        {
            count++;
        }

        //Methods
        public TValue this[TKey key] { get { return this.value; } set { this.value = value; } }

        public ICollection<TKey> Keys { get; }

        public ICollection<TValue> Values { get; }

        public int Count
        {
            get
            {
                return count;
            }
        }

        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        public void Add(TKey key, params TValue[] givenValue)
        {
            this.key = key;

            foreach (var x in givenValue)
            {
                values.Add(x);
            }
        }

        public void Add(TKey key, TValue value)
        {
            this.key = key;
            this.value = value;
        }

        public void Add(KeyValuePair<TKey, TValue> item)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            key = default(TKey);
            value = default(TValue);
            values = null;
        }

        public bool Contains(KeyValuePair<TKey, TValue> item)
        {
            throw new NotImplementedException();
        }

        public bool ContainsKey(TKey key)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            return dict.GetEnumerator();
        }

        public bool Remove(TKey key)
        {
            throw new NotImplementedException();
        }

        public bool Remove(KeyValuePair<TKey, TValue> item)
        {
            throw new NotImplementedException();
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return dict.GetEnumerator();
        }
    }
}
