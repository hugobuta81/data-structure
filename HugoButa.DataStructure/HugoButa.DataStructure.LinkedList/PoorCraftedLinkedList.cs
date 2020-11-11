using System;

namespace HugoButa.DataStructure.LinkedList
{
    public class PoorCraftedLinkedList<T> : ILinkedList<T>
    {
        private Node<T> head;
        private Node<T> tail;
        private int size;
        
        // Empty linked list, O(n)
        public void Clear()
        {
            if (size == 0)
                return;

            var pointer = head;
            while (pointer != null)
            {
                var next = pointer.next;
                pointer.data = default(T);
                pointer.next = null;
                pointer.prev = null;

                pointer = next;
            }

            size = 0;
        }
        
        // Return the size of linked list
        public int Size()
        {
            return size;
        }
        
        // Check if the list is empty
        public bool IsEmpty()
        {
            return size == 0;
        }
        
        // Add element to the tail of the linked list, O(1)
        public void Add(T element)
        {
            AddLast(element);
        }
        
        // Add element to the beginning of the linked list, O(1)
        public void AddFirst(T element)
        {
            if (IsEmpty())
            {
                AddFirstNode(element);
                return;
            }
            
            var newNode = new Node<T>(element, null, head);
            head.prev = newNode;
            head = newNode;

            size++;
        }
        
        // Add a note to the tail of the linked list
        public void AddLast(T element)
        {
            if (IsEmpty())
            {
                AddFirstNode(element);
                return;
            }
            
            var newNode = new Node<T>(element, tail, null);
            tail.next = newNode;
            tail = newNode;
            
            size++;
        }

        // Check the value of the first node, if it exists, O(1)
        public T PeekFirst()
        {
            return IsEmpty() ? default(T) : head.data;
        }
        
        // Check the value of the last node, if it exists, O(1)
        public T PeekLast()
        {
            return IsEmpty() ? default(T) : tail.data;
        }
        
        // Remove the first value of the list, O(1)
        public T RemoveFirst()
        {
            if (IsEmpty())
                return default;

            var node = head;
            var next = head.next;
            if (next != null)
            {
                next.prev = null;
                head = next;
            }
            else
            {
                head = null;
                tail = null;
            }
            
            size--;
            return node.data;
        }
        
        // Remove the last value of the list, O(1)
        public T RemoveLast()
        {
            if (IsEmpty())
                return default;

            var node = tail;
            var prev = tail.prev;
            if (prev != null)
            {
                prev.next = null;
                tail = prev;
            }
            else
            {
                head = null;
                tail = null;
            }

            size--;
            return node.data;
        }
        
        // Remove a node at a particular index, O(n)
        public T RemoveAt(int index)
        {
            if (index >= size)
                throw new ArgumentException($"Index {index} - Size {size}");
            
            int i = 0;
            var node = head;

            while (i < index)
            {
                if (node.next != null)
                {
                    node = node.next;
                    i++;
                }
            }

            return Remove(node);
        }
        
        // Remove a particular value in the linked list, O(n)
        public bool Remove(T element)
        {
            var index = IndexOf(element);
            if (index == -1)
                return false;
            var data = RemoveAt(index);
            
            return data != null;
        }
        
        // Find the index of a particular value in the linked list, O(n)
        public int IndexOf(T element)
        {
            var index = 0;
            var node = head;
            while (index < size)
            {
                if (node.data.Equals(element))
                {
                    return index;
                }

                index++;
            }

            return -1;
        }
        
        // Check is a value is contained within the linked list
        public bool Contains(T element)
        {
            return IndexOf(element) != -1;
        }
        
        private void AddFirstNode(T element)
        {
            var newNode = new Node<T>(element, null, null);
            head = newNode;
            tail = newNode;
            size = 1;
        }

        private T Remove(Node<T> node)
        {
            if (node.next == null)
                return RemoveLast();

            if (node.prev == null)
                return RemoveFirst();

            var prev = node.prev;
            var next = node.next;
            prev.next = next;
            next.prev = prev;

            size--;
            return node.data;
        }
    }
}