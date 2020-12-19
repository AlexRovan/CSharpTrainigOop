using System;
using System.Text;

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
            CheckIndex(index);

            ListItem<T> item = GetItemByIndex(index);
            return item.Data;
        }

        public T SetByIndex(int index, T data)
        {
            CheckIndex(index);

            ListItem<T> item = GetItemByIndex(index);
            T oldData = item.Data;
            item.Data = data;

            return oldData;
        }

        private void CheckIndex(int index)
        {
            if (index < 0 || index >= length)
            {
                throw new ArgumentOutOfRangeException(nameof(index), $"Указанного индекса - {index} нет в списке. Доступны индексы от 0 до {length - 1}");
            }
        }

        public void AddFirst(T data)
        {
            head = new ListItem<T>(data, head);
            length++;
        }

        public void Add(int index, T data)
        {
            if (index < 0 || index > length)
            {
                throw new ArgumentOutOfRangeException(nameof(index), $"Указанного индекса - {index} нет в списке. Доступны индексы от 0 до {length}");
            }

            if (index == 0)
            {
                AddFirst(data);
                return;
            }

            ListItem<T> newItem = new ListItem<T>(data);
            ListItem<T> item = GetItemByIndex(index - 1);

            newItem.Next = item.Next;
            item.Next = newItem;
            length++;
        }

        public T DeleteFirst()
        {
            if (length == 0)
            {
                throw new InvalidOperationException("В списке нет данных.");
            }

            T deletedData = head.Data;

            head = head.Next;

            length--;

            return deletedData;
        }

        public T DeleteByIndex(int index)
        {
            CheckIndex(index);

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

        public bool DeleteByData(T data)
        {
            if (length == 0)
            {
                return false;
            }

            if (Equals(data, head.Data))
            {
                DeleteFirst();
                return true;
            }

            for (ListItem<T> item = head, previousItem = null; item != null; previousItem = item, item = item.Next)
            {
                if (Equals(data, item.Data))
                {
                    previousItem.Next = item.Next;
                    length--;
                    return true;
                }
            }

            return false;
        }

        public void Reverse()
        {
            ListItem<T> previousItem = null;

            for (ListItem<T> item = head, nextItem; item != null; previousItem = item, item = nextItem)
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
                return new SinglyLinkedList<T>();
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
            StringBuilder sb = new StringBuilder();
            sb.Append("[");

            for (ListItem<T> item = head; item != null; item = item.Next)
            {
                sb.Append(item.Data).Append(", ");
            }

            return sb.Remove(sb.Length - 2, 2).Append("]").ToString();
        }
    }
}
