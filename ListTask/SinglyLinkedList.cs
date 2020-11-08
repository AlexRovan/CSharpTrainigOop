using System;

namespace ListTask
{
    class SinglyLinkedList<T>
    {
        private ListItem<T> head;
        private int count = 0;

        public int GetLentgh()
        {
            return count;
        }

        public T GetFirstElement()
        {
            return head.Data;
        }

        public T GetElementByIndex(int index)
        {
            int count = 0;

            for (ListItem<T> p = head; p != null; p = p.Next)
            {
                if (count == index)
                {
                    return p.Data;
                }

                count++;
            }

            throw new IndexOutOfRangeException("Указаного индекса нету в списке");
        }

        public T SetElementByIndex(T value, int index)
        {
            int count = 0;

            for (ListItem<T> p = head; p != null; p = p.Next)
            {
                if (count == index)
                {
                    T oldData = p.Data;
                    p.Data = value;

                    return oldData;
                }
                count++;
            }

            throw new IndexOutOfRangeException("Указаного индекса нету в списке");
        }

        public void Add(T data)
        {
            ListItem<T> p = new ListItem<T>(data, head);

            if (head == null)
            {
                head = p;
                count++;

                return;
            }
            head = p;

            count++;
        }

        public void Add(T data, int index)
        {
            if (index == 0)
            {
                Add(data);
            }

            ListItem<T> item = new ListItem<T>(data);
            int count = 0;

            for (ListItem<T> p = head; p != null; p = p.Next)
            {
                if (count == index - 1)
                {
                    item.Next = p.Next;
                    p.Next = item;

                    this.count++;
                    return;
                }
                count++;
            }

            throw new IndexOutOfRangeException("Указаного индекса нету в списке");
        }

        public T Delete()
        {
            T deletedData = head.Data;

            ListItem<T> p = head.Next;
            head = p;

            count--;

            return deletedData;
        }

        public T Delete(int index)
        {
            if (index == 0)
            {
                return Delete();
            }

            int count = 0;

            for (ListItem<T> p = head, prev = null; p != null; prev = p, p = p.Next)
            {
                if (count == index)
                {
                    T deletedData = p.Data;
                    prev.Next = p.Next;

                    this.count--;
                    return deletedData;
                }
                count++;
            }

            throw new IndexOutOfRangeException("Указаного индекса нету в списке");
        }

        public bool DeleteByValue(T data)
        {
            for (ListItem<T> p = head, prev = null; p != null; prev = p, p = p.Next)
            {
                if (p.Data.Equals(data))
                {
                    if (prev == null)
                    {
                        Delete();
                        return true;
                    }

                    prev.Next = p.Next;
                    count--;
                    return true;
                }
            }

            return false;
        }

        public void Reversal()
        {
            SinglyLinkedList<T> reversalList = new SinglyLinkedList<T>();

            for (ListItem<T> p = head; p != null; p = p.Next)
            {
                reversalList.Add(p.Data);
            }

            head = reversalList.head;
        }

        public SinglyLinkedList<T> Copy()
        {
            SinglyLinkedList<T> reversalList = new SinglyLinkedList<T>();
            reversalList.count = count;

            ListItem<T> copyItem = new ListItem<T>(head.Data, head.Next);

            reversalList.head = copyItem;

            for (ListItem<T> p = head; p.Next != null; p = p.Next)
            {
                copyItem.Next = new ListItem<T>(p.Next.Data, p.Next.Next);
                copyItem = copyItem.Next;
            }

            return reversalList;
        }
    }
}
