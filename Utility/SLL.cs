using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3.Utility
{
    [Serializable, KnownType(typeof(SLL))]
    public class SLL : ILinkedListADT
    {
        public Node Head { get; set; }
        private int _count = 0;
        public void Add(User value, int index)
        {
           Node newNode = new Node();
           if (index == 0)
            {
              newNode.Next = Head;
              newNode = Head;
              newNode.value = value;
            }
            if (index < 0 || index > _count)
            {
                throw new NotImplementedException();
            }
            else
            {
                Node newNode2 = Head;
                for (int i = 0; i < index - 1; i++)
                {
                    newNode2 = newNode2.Next;
                }
               
                newNode.Next = newNode2.Next;
                newNode2.Next = newNode;
                newNode.value = value;
                _count++;
            }
           
        }
        public void AddFirst(User value)
        {
            Node newNode = new Node();
            newNode.value = value;
            var variable = Head;
            Head = newNode;
            newNode.Next = variable;

            _count++;

        }

        public void AddLast(User value)
        {
            Node newNode = new Node();
            newNode.value = value;
            if (Head == null)
            {
                Head = newNode;
            }
            else
            {
                Node newNode2 = Head;
                while (newNode2.Next != null)
                {
                    newNode2 = newNode2.Next;
                }
                newNode2.Next = newNode;
            }
            _count++;
        }

        public void Clear()
        {
            Head = null;
            _count = 0;
        }

        public bool Contains(User value)
        {
            Node newNode = Head;
            while (newNode != null)
            {
                if (newNode.value.Equals(value))
                {
                    return true;
                }
                newNode = newNode.Next;
            }
            return false;

        }
        public int Count()
        {
            return _count;
        }

        public User GetValue(int index)
        {
            Node newNode = Head;
            for (int i = 0; i < index; i++)
            {
                newNode = newNode.Next;
            }
            return newNode.value;
            
        }
        public int IndexOf(User value)
        {
            Node newNode= Head;
            int index = 0;
            if (index < 0 || index >= _count)
            {
                throw new NotImplementedException();
            }
            while (newNode != null)
            {
                if (newNode.value.Equals(value))
                {
                    return index;
                }
                newNode = newNode.Next;
                index++;
                return index;
            }
            return 0;
            
        }
        public bool IsEmpty()
        {
            if(Head == null)
            {
                return true;
            }
            return false;
        }

        public void Remove(int index)
        {
            Node newNode = Head;
                for (int i = 0; i < index - 1; i++)
                {
                    newNode = newNode.Next;
                }
                newNode.Next = newNode.Next.Next;
                _count--;
        }

        public void RemoveFirst()
        { 
            Head = Head.Next;
            _count--;
            
        }
        public void RemoveLast()
        {
            if (Head == null)
            {
                throw new NotImplementedException();
            }
            else if (Head.Next == null)
            {
                // Only one node in the linked list
                Head = null;
                _count--;
            }
            else
            {
                // Iterate to second-to-last node
                Node newNode = Head;
                while (newNode.Next.Next != null)
                {
                    newNode = newNode.Next;
                }
                newNode.Next = null;
            }
            _count--;

        }
        public void Replace(User value, int index)
        {
            if (index < 0 || index >= _count)
            {
                throw new NotImplementedException();
            }
            else
            {
                Node newNode = Head;
                for (int i = 0; i < index; i++)
                {
                    newNode = newNode.Next;
                }
                newNode.value = value;
            }

        }
        public void Reverse()
        {
            Node newNode = Head;
            Node newNode2 = null;

            while (newNode != null)
            {
                Node newNode3 = newNode.Next;
                newNode.Next = newNode2;
                newNode2 = newNode;
                newNode = newNode3;
            }

            Head = newNode2;
        }
    }
}
