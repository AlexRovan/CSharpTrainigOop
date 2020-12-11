using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ArrayListTask
{
    class ArrayList<T> : IList<T>
    {
        private T[] items;
        private int length;

        public ArrayList(int capacity)
        {
            items = new T[capacity];
        }

        public int Count
        {
            get { return length; }
        }

        public bool IsReadOnly => throw new NotImplementedException();

        public T this[int index]
        {
            get
            {
                CheckIndex(index);
                return items[index];
            }

            set
            {
                CheckIndex(index);
                items[index] = value;
            }
        }

        private void CheckIndex(int index)
        {
            if (index < 0 || index >= length - 1)
            {
                throw new ArgumentOutOfRangeException(nameof(index), $"Индекс выходит за пределы массива от 0 до {length - 1}");
            }
        }

        private void CheckIndexZero(int index)
        {
            if (index < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(index), "Индекс меньше 0");
            }
        }

        private void CheckIndexLength(int index)
        {
            if (index >= length - 1)
            {
                throw new ArgumentOutOfRangeException(nameof(index), $"Индекс больше длины массива {length - 1}");
            }
        }

        private void CheckNullArray(T[] obj)
        {
            if (object.Equals(obj, null))
            {
                throw new ArgumentNullException(nameof(obj), "Массив имеет значение null");
            }
        }


        public void Add(T obj)
        {
            if (length >= items.Length)
            {
                IncreaseCapacity();
            }

            items[length] = obj;
            length++;
        }

        public int IndexOf(T item)
        {
            for (int i = 0; i < length; i++)
            {
                if (item.Equals(items[i]))
                {
                    return i;
                }
            }

            return -1;
        }

        public int IndexOf(T item, int index)
        {
            CheckIndex(index);

            for (int i = index; i < length; i++)
            {
                if (item.Equals(items[i]))
                {
                    return i;
                }
            }

            return -1;
        }

        public int IndexOf(T item, int index, int count)
        {
            CheckIndex(index);

            for (int i = index; i < count; i++)
            {
                if (item.Equals(items[i]))
                {
                    return i;
                }
            }

            return -1;
        }

        public void RemoveAt(int index)
        {
            CheckIndex(index);

            if (index < length - 1)
            {
                Array.Copy(items, index + 1, items, index, length - index - 1);
            }

            length--;
        }

        private void IncreaseCapacity()
        {
            T[] old = items;
            items = new T[old.Length * 2];
            Array.Copy(old, 0, items, 0, old.Length);
        }

        public void Insert(int index, T item)
        {
            CheckIndex(index);

            if (length >= items.Length + 1)
            {
                IncreaseCapacity();
            }

            Array.Copy(items, index, items, index + 1, length - index);
            items[index] = item;
            length++;
        }

        public void Clear()
        {
            items = new T[items.Length];
        }

        public bool Contains(T item)
        {
            foreach (T e in items)
            {
                if (object.Equals(e, item))
                {
                    return true;
                }

            }

            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            CheckNullArray(array);
            CheckIndexZero(arrayIndex);

            if (items.Length - arrayIndex > (array.Length))
            {
                throw new ArgumentException(nameof(array), $"Число элементов в исходной коллекции для копирования {items.Length - arrayIndex} больше доступного места {array.Length}");
            }

            Array.Copy(items, arrayIndex, array, 0, array.Length);
        }

        public void CopyTo(int index, T[] array, int arrayIndex, int count)
        {
            CheckNullArray(array);
            CheckIndexZero(arrayIndex);
            CheckIndexZero(count);

            if (items.Length - arrayIndex > (array.Length))
            {
                throw new ArgumentException(nameof(array), $"Число элементов в исходной коллекции для копирования {items.Length - arrayIndex} больше доступного места {array.Length}");
            }

            Array.Copy(items, arrayIndex, array, 0, count);
        }

        public void CopyTo(T[] array)
        {
            CheckNullArray(array);

            if (items.Length > array.Length)
            {
                throw new ArgumentException(nameof(array), $"Число элементов в исходной коллекции для копирования {items.Length} больше доступного места {array.Length}");
            }

            Array.Copy(items, array, items.Length);
        }

        public bool Remove(T item)
        {
            for (int i = 0; i < items.Length; i++)
            {
                if (object.Equals(items[i], item))
                {
                    RemoveAt(i);
                    return true;
                }
            }

            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
