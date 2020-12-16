using System;
using System.Collections;
using System.Collections.Generic;

namespace ArrayListTask
{
    class ArrayList<T> : IList<T>
    {
        private T[] items;
        private int length;
        private int modCount;

        public ArrayList(int capacity)
        {
            items = new T[capacity];
        }

        public int Capacity
        {
            get
            {
                if (items.Length < length)
                {
                    throw new ArgumentOutOfRangeException($"Емкость массива {items.Length} не может быть меньше кол-ва элементов {length}");
                }
                return items.Length;
            }
        }

        public int Count
        {
            get { return length; }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

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
            if (index < 0 || index > length - 1)
            {
                throw new ArgumentOutOfRangeException(nameof(index), $"Индекс выходит за пределы массива от 0 до {length - 1}. Получено: {index}");
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

        private void CheckArrayNull(T[] obj)
        {
            if (object.Equals(obj, null))
            {
                throw new ArgumentNullException(nameof(obj), "Передан пустой массив");
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
            modCount++;
        }

        public int IndexOf(T item)
        {
            for (int i = 0; i < length; i++)
            {
                if (object.Equals(items[i], item))
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
                if (object.Equals(item, items[i]))
                {
                    return i;
                }
            }

            return -1;
        }

        public int IndexOf(T item, int index, int count)
        {
            CheckIndex(index);
            CheckCountLessZero(count);

            if ((index + count) >= length)
            {
                throw new ArgumentOutOfRangeException(nameof(count), $"Индекс: {index} и кол-во итераций: {count} должны попадать в размер списка {length}.");
            }

            CheckCountLessZero(count);

            for (int i = index; i <= count; i++)
            {
                if (object.Equals(item, items[i]))
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

            modCount++;
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
            modCount++;
        }

        public void Clear()
        {
            items = new T[items.Length];
            length = 0;
            modCount++;
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
            CheckArrayNull(array);
            CheckArrayIndexLessZero(arrayIndex);

            if (length > array.Length - arrayIndex)
            {
                throw new ArgumentException(nameof(array), $"Число элементов в исходной коллекции для копирования {length} больше доступного места {array.Length - arrayIndex}");
            }

            Array.Copy(items, 0, array, arrayIndex, length);
        }

        public void CopyTo(int index, T[] array, int arrayIndex, int count)
        {
            CheckArrayNull(array);
            CheckArrayIndexLessZero(arrayIndex);
            CheckCountLessZero(count);

            if (index < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(index), $"Параметр index должен быть положительным числом. Получено: {index}");
            }

            if (index >= length)
            {
                throw new ArgumentException($"Номер индекса {index} не может быть больше длинны списка {length}", nameof(index));
            }

            if (count > length - index)
            {
                throw new ArgumentException(nameof(array), $"Число элементов для копирования {count} больше возможного {length - index}");
            }

            if (count > array.Length - arrayIndex)
            {
                throw new ArgumentException(nameof(array), $"Число элементов в исходной коллекции для копирования {count} больше доступного места {array.Length - arrayIndex}");
            }

            Array.Copy(items, index, array, arrayIndex, count);
        }

        public void CopyTo(T[] array)
        {
            CheckArrayNull(array);

            if (length > array.Length)
            {
                throw new ArgumentException(nameof(array), $"Число элементов в исходной коллекции для копирования {items.Length} больше доступного места {array.Length}");
            }

            Array.Copy(items, array, length);
        }

        public void TrimExcess()
        {
            T[] old = items;
            items = new T[length];
            Array.Copy(old, 0, items, 0, length);
        }

        public bool Remove(T item)
        {
            for (int i = 0; i < items.Length; i++)
            {
                if (object.Equals(items[i], item))
                {
                    RemoveAt(i);
                    modCount++;
                    return true;
                }
            }

            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            int count = modCount;

            for (int i = 0; i < length; i++)
            {
                if (count != modCount)
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
