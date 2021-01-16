using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ArrayListTask
{
    public class ArrayList<T> : IList<T>
    {
        private T[] items;

        private int modCount;

        public int Count { get; private set; }

        public ArrayList(int capacity)
        {
            if (capacity < 0)
            {
                throw new ArgumentException($"Емкость списка {capacity} должна быть положительным числом.", nameof(capacity));
            }

            items = new T[capacity];
        }

        public ArrayList()
        {
            items = new T[0];
        }

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
                    throw new ArgumentOutOfRangeException("value", $"Емкость списка {items.Length} не может быть меньше кол-ва элементов {Count}");
                }

                Array.Resize(ref items, value);
            }
        }

        public bool IsReadOnly => false;

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
                modCount++;
            }
        }

        private void CheckIndex(int index)
        {
            if (index < 0 || index > Count)
            {
                throw new ArgumentOutOfRangeException(nameof(index), $"Индекс выходит за пределы списка от 0 до {Count}. Получено: {index}");
            }
        }

        static private void CheckArrayIndexLessZero(int arrayIndex)
        {
            if (arrayIndex < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(arrayIndex), $"Начальный индекс списка должен быть положительным числом. Получено: {arrayIndex}");
            }
        }

        static private void CheckCountLessZero(int count)
        {
            if (count < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(count), $"Диапозон списка должен быть положительным числом. Получено: {count}");
            }
        }

        static private void CheckArrayForNull(T[] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array), "Передан null список");
            }
        }

        public int IndexOf(T item, int index, int count)
        {
            CheckIndex(index);
            CheckCountLessZero(count);

            if ((index + count) > Count)
            {
                throw new ArgumentOutOfRangeException(nameof(count), $"Индекс: {index} и кол-во итераций: {count} должны попадать в размер списка {Count}.");
            }

            for (int i = index; i < count; i++)
            {
                if (Equals(item, items[i]))
                {
                    return i;
                }
            }

            return -1;
        }

        public int IndexOf(T item)
        {
            return IndexOf(item, 0, Count);
        }

        public int IndexOf(T item, int index)
        {
            return IndexOf(item, index, Count);
        }

        public void RemoveAt(int index)
        {
            CheckIndex(index);

            if (index < Count - 1)
            {
                Array.Copy(items, index + 1, items, index, Count - index - 1);
            }

            modCount++;
            Count--;
            items[Count] = default;
        }

        public void Add(T item)
        {
            Insert(Count, item);
        }

        private void IncreaseCapacity()
        {
            if (items.Length == 0)
            {
                Capacity = 1;
            }
            else
            {
                Capacity = items.Length * 2;
            }
        }

        public void Insert(int index, T item)
        {
            CheckIndex(index);

            if (Count >= items.Length)
            {
                IncreaseCapacity();
            }

            if (Count == index)
            {
                items[Count] = item;
            }
            else
            {
                Array.Copy(items, index, items, index + 1, Count - index);
                items[index] = item;
            }
            Count++;
            modCount++;
        }

        public void Clear()
        {
            Array.Clear(items, 0, Count);
            Count = 0;
            modCount++;
        }

        public bool Contains(T item)
        {
            return (IndexOf(item) != -1) ? true : false; ;
        }

        public void CopyTo(int index, T[] array, int arrayIndex, int count)
        {
            CheckArrayForNull(array);
            CheckArrayIndexLessZero(arrayIndex);
            CheckCountLessZero(count);
            CheckIndex(index);

            if (count > Count - index)
            {
                throw new ArgumentOutOfRangeException(nameof(array), $"Число элементов для копирования {count} больше возможного {Count - index}");
            }

            if (count > array.Length - arrayIndex)
            {
                throw new ArgumentOutOfRangeException(nameof(array), $"Число элементов в исходной коллекции для копирования {count} больше доступного места {array.Length - arrayIndex}");
            }

            Array.Copy(items, index, array, arrayIndex, count);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            CopyTo(0, array, arrayIndex, Count);
        }

        public void CopyTo(T[] array)
        {
            CopyTo(0, array, 0, Count);
        }

        public void TrimExcess()
        {
            if (Count != Capacity || Count < 0.9 * Capacity)
            {
                Capacity = Count;
            }
        }

        public bool Remove(T item)
        {
            int index = IndexOf(item);

            if (index != -1)
            {
                RemoveAt(index);
                return true;
            }

            return false;
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

        public IEnumerator<T> GetEnumerator()
        {
            int currentModifyCount = modCount;

            for (int i = 0; i < Count; i++)
            {
                if (currentModifyCount != modCount)
                {
                    throw new InvalidOperationException("Коллекция была изменена. Операция итерации не может быть выполнена.");
                }

                yield return items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
