using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.Arrays
{
    public class DynamicArray<T>
    {
        private T[] arr;            //泛型数组
        private int len = 0;        //数组当前长度
        private int capacity = 0;   //动态数组总容量
        public DynamicArray()
        {
            // 默认初始数组长度为 16
            Create(16);
        }
        // 创建动态数组，参数为数组容量
        public void Create(int capacity)
        {
            if (capacity < 0)
                throw new ArgumentOutOfRangeException("Illegal Capacity: " + capacity);
            this.capacity = capacity;
            arr = new T[capacity];
        }
        // 获取数组当前长度
        public int Size()
        {
            return len;
        }
        // 判断动态数组当前是否为空
        public bool IsEmpty()
        {
            return Size() == 0;
        }
        // 获取指定索引位置的元素
        public T Get(int index)
        {
            if (index >= len && index < 0)
            {
                throw new IndexOutOfRangeException();
            }
            return arr[index];
        }
        // 设置指定索引位置的元素值
        public void Set(int index, T elem)
        {
            if (index >= len && index < 0)
            {
                throw new IndexOutOfRangeException();
            }
            arr[index] = elem;
        }
        // 清空动态数组
        public void Clear()
        {
            for (int i = 0; i < capacity; i++)
            {
                arr[i] = default;
            }
            len = 0;
        }
        // 添加元素
        public void Add(T elem)
        {
            // 判断动态数组如果满了，则进行扩容
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
            // 在动态数组末尾添加元素
            arr[len++] = elem;
        }
        // 移除指定索引位置的元素，返回删除元素的值
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
        // 移除数组内指定元素，返回布尔值判断是否成功
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
        // 获取指定元素在动态数组中的索引
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
        // 判断动态数组中是否包含指定元素
        public bool Contains(T item)
        {
            return IndexOf(item) != -1;
        }
    }
}
