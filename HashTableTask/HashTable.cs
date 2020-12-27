using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using ArrayListTask;

namespace HashTableTask
{
    public class HashTable<T> : ICollection<T>
    {
        private ArrayList<T>[] items;
        private int modifyCount;
        private const int capacityArrayList = 10;

        public int Count { get; private set; }

        public int Capacity
        {
            get
            {
                return items.Length;
            }
            set
            {
                if (value < Count)
                {
                    throw new ArgumentOutOfRangeException($"Емкость массива {items.Length} не может быть меньше кол-ва элементов {Count}");
                }

                Array.Resize(ref items, value);
            }
        }

        public HashTable(int capacity)
        {
            if (capacity <= 0)
            {
                throw new ArgumentException($"Емкость хэш-таблицы {capacity} должна быть больше 0.", nameof(capacity));
            }

            items = new ArrayList<T>[capacity];
        }

        public bool IsReadOnly => true;

        public void Add(T obj)
        {
            if (Count >= items.Length - 1)
            {
                IncreaseCapacity();
            }

            int hashCode = Math.Abs(obj.GetHashCode() % items.Length);

            if (Equals(items[hashCode], null))
            {
                items[hashCode] = new ArrayList<T>(capacityArrayList);
                Count++;
            }

            items[hashCode].Add(obj);
            modifyCount++;
        }

        private void IncreaseCapacity()
        {
            Capacity = items.Length * 2;
        }

        public void Clear()
        {
            Array.Clear(items, 0, items.Length);
            Count = 0;
        }

        public bool Contains(T obj)
        {
            int hashCode = Math.Abs(obj.GetHashCode() % items.Length);

            if (Equals(items[hashCode], null))
            {
                return false;
            }

            return items[hashCode].Contains(obj);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (Equals(array, null))
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

            Array.Copy(items, 0, array, arrayIndex, Count);
        }

        public IEnumerator<T> GetEnumerator()
        {
            int currentModifyCount = modifyCount;

            for (int i = 0; i < Count; i++)
            {
                if (currentModifyCount != modifyCount)
                {
                    throw new InvalidOperationException("Коллекция была изменена. Операция итерации не может быть выполнена.");
                }

                if(Equals(items[i],null))
                {
                    continue;
                }

                foreach (T e in items[i])
                {
                    yield return e;
                }
            }
        }

        public bool Remove(T obj)
        {
            int hashCode = Math.Abs(obj.GetHashCode() % items.Length);

            if (Equals(items[hashCode], null))
            {
                return false;
            }

            modifyCount++;
            return items[hashCode].Remove(obj);
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

            for (int i = 0; i < Count; i++)
            {
                sb.Append(items[i]).Append(", ");
            }

            return sb.Remove(sb.Length - 2, 2).Append("]").ToString();
        }
    }
}
