using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ArrayListTask
{
    public class ArrayList<T> : IList<T>
    {
        private T[] items;
        private int modifyCount;
        public int Count { get; private set; }

        public ArrayList(int capacity)
        {
            if (capacity <= 0)
            {
                throw new ArgumentException($"Емкость списка {capacity} должна быть больше 0.", nameof(capacity));
            }

            items = new T[capacity];
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
                    throw new ArgumentOutOfRangeException($"Емкость массива {items.Length} не может быть меньше кол-ва элементов {Count}");
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
            }
        }

        private void CheckIndex(int index)
        {
            if (index < 0 || index >= Count)
            {
                throw new ArgumentOutOfRangeException(nameof(index), $"Индекс выходит за пределы массива от 0 до {Count - 1}. Получено: {index}");
            }
        }

        private void CheckArrayIndexLessZero(int arrayIndex)
        {
            if (arrayIndex < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(arrayIndex), $"Начальный индекс массива должен быть положительным числом. Получено: {arrayIndex}");
            }
        }

        private void CheckCountLessZero(int count)
        {
            if (count < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(count), $"Диапозон массива должен быть положительным числом. Получено: {count}");
            }
        }

        private static void CheckArrayForNull(T[] array)
        {
            if (Equals(array, null))
            {
                throw new ArgumentNullException(nameof(array), "Передан null массив");
            }
        }

        public void Add(T item)
        {
            if (Count >= items.Length)
            {
                IncreaseCapacity();
            }

            items[Count] = item;
            Count++;
            modifyCount++;
        }

        public int IndexOf(T item, int index, int count)
        {
            CheckIndex(index);
            CheckCountLessZero(count);

            if ((index + count) > Count)
            {
                throw new ArgumentOutOfRangeException(nameof(count), $"Индекс: {index} и кол-во итераций: {count} должны попадать в размер списка {Count}.");
            }

            CheckCountLessZero(count);

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
            
            modifyCount++;
            Count--;
            items[Count] = default(T);
        }

        private void IncreaseCapacity()
        {
            Capacity = items.Length * 2;
        }

        public void Insert(int index, T item)
        {
            if (Count == index)
            {
                Add(item);
                return;
            }

            CheckIndex(index);

            if (Count >= items.Length)
            {
                IncreaseCapacity();
            }

            Array.Copy(items, index, items, index + 1, Count - index);
            items[index] = item;
            Count++;
            modifyCount++;
        }

        public void Clear()
        {
            Array.Clear(items, 0, items.Length);
            Count = 0;
            modifyCount++;
        }

        public bool Contains(T item)
        {
            if (IndexOf(item) != -1)
            {
                return true;
            }

            return false;
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
            if (Count != Capacity || Count < 0.1 * Capacity)
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
            int currentModifyCount = modifyCount;

            for (int i = 0; i < Count; i++)
            {
                if (currentModifyCount != modifyCount)
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
