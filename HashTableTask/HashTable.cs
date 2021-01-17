using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using ArrayListTask;

namespace HashTableTask
{
    public class HashTable<T> : ICollection<T>
    {
        private ArrayList<T>[] Lists;
        private int modCount;
        private const int ArrayListСapacity = 10;

        public int Count { get; private set; }

        public HashTable(int arrayLength)
        {
            if (arrayLength <= 0)
            {
                throw new ArgumentException($"Длинна массива хэш-таблицы {arrayLength} должна быть больше 0.", nameof(arrayLength));
            }

            Lists = new ArrayList<T>[arrayLength];
        }

        public bool IsReadOnly => true;

        private int GetIndexArrayLists(T obj)
        {
            return (obj == null) ? 0 : Math.Abs(obj.GetHashCode() % Lists.Length);
        }

        public void Add(T obj)
        {
            if (obj == null)
            {
                return;
            }

            int indexArrayLists = GetIndexArrayLists(obj);

            if (Lists[indexArrayLists] == null)
            {
                Lists[indexArrayLists] = new ArrayList<T>(ArrayListСapacity);
            }

            Lists[indexArrayLists].Add(obj);
            Count++;
            modCount++;
        }

        public void Clear()
        {
            Array.Clear(Lists, 0, Lists.Length);
            Count = 0;
            modCount++;
        }

        public bool Contains(T obj)
        {
            int indexArrayLists = GetIndexArrayLists(obj);

            return (Lists[indexArrayLists] == null) ? false : Lists[indexArrayLists].Contains(obj);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array), "Передан null массив");
            }

            if (arrayIndex < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(arrayIndex), $"Начальный индекс массива должен быть положительным числом. Получено: {arrayIndex}");
            }

            if (Count > array.Length - arrayIndex)
            {
                throw new ArgumentOutOfRangeException(nameof(array), $"Число элементов в исходной коллекции для копирования {Count} больше доступного места {array.Length - arrayIndex}");
            }

            Array.Copy(Lists, 0, array, arrayIndex, Count);
        }

        public IEnumerator<T> GetEnumerator()
        {
            int currentModifyCount = modCount;

            for (int i = 0; i < Count; i++)
            {
                if (Lists[i] == null)
                {
                    continue;
                }

                foreach (T e in Lists[i])
                {
                    if (currentModifyCount != modCount)
                    {
                        throw new InvalidOperationException("Коллекция была изменена. Операция итерации не может быть выполнена.");
                    }

                    yield return e;
                }
            }
        }

        public bool Remove(T obj)
        {
            int indexArrayLists = GetIndexArrayLists(obj);

            if (Lists[indexArrayLists] == null)
            {
                return false;
            }

            if (Lists[indexArrayLists].Remove(obj))
            {
                modCount++;
                Count--;
                return true;
            }

            return false;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public override string ToString()
        {
            if (Count == 0)
            {
                return "[]";
            }

            StringBuilder sb = new StringBuilder();
            sb.Append("[");

            for (int i = 0; i < Lists.Length; i++)
            {
                sb.Append(Lists[i]).Append(", ");
            }

            return sb.Remove(sb.Length - 2, 2).Append("]").ToString();
        }
    }
}
