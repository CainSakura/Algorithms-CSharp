using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.Arrays
{
    public class DynamicArray<T>
    {
        private T[] arr;
        private int len = 0;
        private int capacity = 0;
        public DynamicArray()
        {
            Create(16);
        }
        public void Create(int capacity)
        {
            if (capacity < 0)
                throw new ArgumentOutOfRangeException("Illegal Capacity: " + capacity);
            this.capacity = capacity;
            arr = new T[capacity];
        }
        public int Size()
        {
            return len;
        }
        public bool IsEmpty()
        {
            return Size() == 0;
        }
        public T Get(int index)
        {
            return arr[index];
        }
        public void Set(int index, T elem)
        {
            arr[index] = elem;
        }
        public void Clear()
        {
            for (int i = 0; i < capacity; i++)
            {
                arr[i] = default;
            }
            len = 0;
        }
        public void Add(T elem)
        {
            if (len + 1 >= capacity)
            {
                if (capacity == 0)
                {
                    capacity = 1;
                }
                else
                {
                    capacity *= 2;
                }
                T[] newArr = new T[capacity];
                for (int i = 0; i < len; i++)
                {
                    newArr[i] = arr[i];
                }
                arr = newArr;
            }
            arr[len++] = elem;
        }
        public T RemoveAt(int rm_index)
        {
            if (rm_index >= len && rm_index < 0)
            {
                throw new IndexOutOfRangeException();
            }
            T data = arr[rm_index];
            T[] newArr = new T[len - 1];
            for (int i = 0, j = 0; i < len; i++, j++)
            {
                if (i == rm_index)
                {
                    j--;
                }
                else
                {
                    newArr[j] = arr[i];
                }
            }
            arr = newArr;
            capacity = --len;
            return data;
        }
        public bool Remove(T item)
        {
            for (int i = 0; i < len; i++)
            {
                if (arr[i].Equals(item))
                {
                    RemoveAt(i);
                    return true;
                }
            }
            return false;
        }
        public int IndexOf(T item)
        {
            for (int i = 0; i < len; i++)
            {
                if (arr[i].Equals(item))
                {
                    return i;
                }
            }
            return -1;
        }
        public bool Contains(T item)
        {
            return IndexOf(item) != -1;
        }
    }
}
