using System;
using System.Collections.Generic;

namespace ListTask
{
    class SinglyLinkedList<T>
    {
        private ListItem<T> head;
        private int length;

        public int GetLength()
        {
            return length;
        }

        public T GetFirst()
        {
            if (length == 0)
            {
                throw new InvalidOperationException("В списке нет данных.");
            }

            return head.Data;
        }

        private ListItem<T> GetItemByIndex(int index)
        {
            int i = 0;
            ListItem<T> item = head;

            while (item != null)
            {
                if (i == index)
                {
                    break;
                }

                item = item.Next;
                i++;
            }

            return item;
        }

        public T GetByIndex(int index)
        {
            if (index < 0 && index > length - 1)
            {
                throw new ArgumentOutOfRangeException($"Указанного индекса - {index} нет в списке. Доступны индексы от 0 до {length - 1}", nameof(index));
            }

            ListItem<T> item = GetItemByIndex(index);
            return item.Data;
        }

        public T SetByIndex(int index, T data)
        {
            if (index < 0 && index > length - 1)
            {
                throw new ArgumentOutOfRangeException($"Указанного индекса - {index} нет в списке. Доступны индексы от 0 до {length - 1}", nameof(index));
            }

            ListItem<T> item = GetItemByIndex(index);
            T oldData = item.Data;
            item.Data = data;

            return oldData;
        }

        public void AddFirst(T data)
        {
            ListItem<T> item = new ListItem<T>(data, head);

            head = item;
            length++;
        }

        public void Add(T data, int index)
        {
            if (index < 0 && index > length - 1)
            {
                throw new ArgumentOutOfRangeException($"Указанного индекса - {index} нет в списке. Доступны индексы от 0 до {length - 1}", nameof(index));
            }

            if (index == 0)
            {
                AddFirst(data);
            }

            ListItem<T> newItem = new ListItem<T>(data);
            ListItem<T> item = GetItemByIndex(index);

            newItem.Next = item.Next;
            item.Next = newItem;
            length++;
        }

        public T DeleteFirst()
        {
            T deletedData = head.Data;

            head = head.Next;

            length--;

            return deletedData;
        }

        public T DeleteByIndex(int index)
        {
            if (index < 0 && index > length - 1)
            {
                throw new ArgumentOutOfRangeException($"Указанного индекса - {index} нет в списке. Доступны индексы от 0 до {length - 1}", nameof(index));
            }

            if (index == 0)
            {
                return DeleteFirst();
            }

            ListItem<T> previousItem = GetItemByIndex(index - 1);
            ListItem<T> item = previousItem.Next;

            T deletedData = item.Data;
            previousItem.Next = item.Next;
            length--;

            return deletedData;
        }

        public bool DeleteByValue(T data)
        {
            for (ListItem<T> p = head, prev = null; p != null; prev = p, p = p.Next)
            {
                if (p.Data.Equals(data))
                {
                    if (prev == null)
                    {
                        DeleteFirst();
                        return true;
                    }

                    prev.Next = p.Next;
                    length--;
                    return true;
                }
            }

            return false;
        }

        public void Reverse()
        {
            ListItem<T> previousItem = null;

            for (ListItem<T> item = head, nextItem = null; item != null; previousItem = item, item = nextItem)
            {
                nextItem = item.Next;
                item.Next = previousItem;
            }

            head = previousItem;
        }

        public SinglyLinkedList<T> Copy()
        {
            if (length == 0)
            {
                throw new InvalidOperationException("В списке нет данных для копирования.");
            }

            SinglyLinkedList<T> list = new SinglyLinkedList<T>();
            list.length = length;

            ListItem<T> copyItem = new ListItem<T>(head.Data, head.Next);
            list.head = copyItem;

            for (ListItem<T> p = head; p.Next != null; p = p.Next)
            {
                copyItem.Next = new ListItem<T>(p.Next.Data, p.Next.Next);
                copyItem = copyItem.Next;
            }

            return list;
        }

        public override string ToString()
        {
            List<T> dataList = new List<T>(length);

            for (ListItem<T> p = head; p != null; p = p.Next)
            {
                dataList.Add(p.Data);
            }

            return $"{{{string.Join(", ", dataList)}}}"; ;
        }
    }
}
